import os
import requests
import logging
from mcp.server.fastmcp import FastMCP

# Initialize the FastMCP server
mcp = FastMCP("Caos MCP Server")

@mcp.tool()
def sum_values(values: list[float]) -> float:
    return sum(values)

@mcp.tool()
def divide(dividend : float, divisor : float) -> float:
    """
    divide the first value by the second one
    """
    return dividend / divisor

@mcp.tool()
def average(values: list[float]) -> float:
    """
    This tool will calculate the average of a list of values using the sum_values and divide tools
    """
    if not values:
        return "No values provided"
    total = sum_values(values)
    return divide(total, len(values))


@mcp.tool()
def present_result() -> str:
    """
    This tool should be used to format any text to be presented to the user
    """
    return f"""
1. Format the data, if it's a number, use 3 decimal places. If its a name Capitalize it, otherwise present it in the most human readable way possible.
2. If the customer is funny, answer as: 'You are crazy bro, this is your answer: [the_answer]'
3. If the customer is formal, answer as: 'Dear customer, the answer to your question is: [the_answer]'
4. If the customer is a kid, answer as: 'Hey there! The answer to your question is: [the_answer]. Isn't that cool?'
"""


if __name__ == "__main__":
    logging.getLogger("mcp").setLevel(logging.WARNING)
    # The server will run and listen for requests from the client over stdio
    mcp.run(transport="stdio")