import asyncio
import os
from pathlib import Path

from langgraph.graph import END, START, StateGraph
from langgraph.graph.message import AnyMessage, add_messages
from langgraph.checkpoint.memory import MemorySaver
from langgraph.prebuilt import ToolNode, tools_condition
from typing import Annotated, List
from typing_extensions import TypedDict

from langchain_openai import ChatOpenAI
from langchain_core.prompts import ChatPromptTemplate, MessagesPlaceholder
from langchain_mcp_adapters.client import MultiServerMCPClient

try:
    from dotenv import load_dotenv
except ImportError:
    load_dotenv = None


if load_dotenv:
    # Try local .env first, then fallback to Python/MCP/.env
    current_dir_env = Path(__file__).with_name(".env")
    parent_env = Path(__file__).resolve().parent.parent / ".env"
    if current_dir_env.exists():
        load_dotenv(current_dir_env)
    elif parent_env.exists():
        load_dotenv(parent_env)
    else:
        load_dotenv()


server_configs = {
    "travel": {
        "command": "py",
        "args": ["-3.14", "travel_server.py"],
        "transport": "stdio",
    },
    "tasks": {
        "command": "py",
        "args": ["-3.14", "task_management_server.py"],
        "transport": "stdio",
    },
}


class State(TypedDict):
    messages: Annotated[List[AnyMessage], add_messages]


def create_graph(tools: list):
    openai_api_key = os.getenv("OPENAI_API_KEY")
    if not openai_api_key:
        raise ValueError("OPENAI_API_KEY is not set. Add it to .env or your environment.")

    llm = ChatOpenAI(model="gpt-4o-mini", temperature=0, api_key=openai_api_key)
    llm_with_tools = llm.bind_tools(tools)

    prompt_template = ChatPromptTemplate.from_messages([
        (
            "system",
            "You are a travel planning assistant. Use available tools to help the user. "
            "When user asks to plan a trip for a city, use the travel workflow tool and "
            "ensure tasks are created through the task management server for each activity.",
        ),
        MessagesPlaceholder("messages"),
    ])

    chat_llm = prompt_template | llm_with_tools

    def chat_node(state: State) -> State:
        response = chat_llm.invoke({"messages": state["messages"]})
        return {"messages": [response]}

    graph = StateGraph(State)
    graph.add_node("chat_node", chat_node)
    graph.add_node("tool_node", ToolNode(tools=tools))
    graph.add_edge(START, "chat_node")
    graph.add_conditional_edges(
        "chat_node",
        tools_condition,
        {
            "tools": "tool_node",
            "__end__": END,
        },
    )
    graph.add_edge("tool_node", "chat_node")

    return graph.compile(checkpointer=MemorySaver())


async def main():
    client = MultiServerMCPClient(server_configs)
    all_tools = await client.get_tools()

    agent = create_graph(all_tools)

    print("Travel MCP client is ready (travel + task servers connected).")

    while True:
        user_input = input("\nYou: ").strip()
        if user_input.lower() in {"exit", "quit", "q"}:
            break

        try:
            response = await agent.ainvoke(
                {"messages": [("user", user_input)]},
                config={"configurable": {"thread_id": "travel-planner-session"}},
            )
            print("AI:", response["messages"][-1].content)
        except Exception as e:
            print("Error:", e)


if __name__ == "__main__":
    asyncio.run(main())
