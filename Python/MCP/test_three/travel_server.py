import json
from datetime import datetime, timezone
from pathlib import Path

from mcp.server.fastmcp import FastMCP


mcp = FastMCP("TravelPlannerAssistant")
COSTS_FILE = Path(__file__).with_name("activity_costs.jsonl")


@mcp.prompt()
def plan_city_activities(city: str) -> str:
	"""
	Prompt 1: create a practical list of things to do in a city.
	"""
	return f"""
You are a travel planner.

City: {city}

Create a concise activity plan for this city with 6 to 10 things to do.
For each activity include:
- name
- short description
- suggested duration
- category (culture, food, nature, nightlife, shopping, etc.)

Return the result as a numbered list.
""".strip()


@mcp.prompt()
def estimate_activity_prices(city: str, activities: str) -> str:
	"""
	Prompt 2: estimate a general price for each planned activity.
	"""
	return f"""
You are a travel cost assistant.

City: {city}
Activities to price:
{activities}

Estimate a general price range for each activity in local currency and USD.
For each activity include:
- estimated min price
- estimated max price
- short note about what affects price

Return as a bullet list, one activity per bullet.
""".strip()


@mcp.tool()
def record_activity_cost(city: str, activity_name: str, price_summary: str) -> str:
	"""
	Cost management tool: persist one activity price entry to a local tracking file.
	"""
	entry = {
		"city": city,
		"activity_name": activity_name,
		"price_summary": price_summary,
		"created_at_utc": datetime.now(timezone.utc).isoformat(),
	}

	with COSTS_FILE.open("a", encoding="utf-8") as file_handle:
		file_handle.write(json.dumps(entry) + "\n")

	return f"Cost recorded for '{activity_name}' in {city}."


@mcp.tool()
def get_costs_resource() -> dict:
	"""
	Provides stored activity costs as a resource-like payload.
	"""
	records = []
	if COSTS_FILE.exists():
		with COSTS_FILE.open("r", encoding="utf-8") as file_handle:
			for line in file_handle:
				line = line.strip()
				if not line:
					continue
				try:
					records.append(json.loads(line))
				except json.JSONDecodeError:
					continue

	return {
		"resource_type": "costs",
		"count": len(records),
		"items": records,
		"source_file": str(COSTS_FILE),
	}


@mcp.tool()
def plan_trip_workflow(city: str) -> str:
	"""
	Orchestration tool that tells the client exactly how to run the travel workflow,
	including creating one task per activity and recording one cost per activity.
	"""
	return f"""
Follow this workflow for city "{city}":

1. Execute prompt `plan_city_activities` with argument:
	- city: "{city}"

2. Take the full output from step 1 and execute prompt `estimate_activity_prices` with arguments:
	- city: "{city}"
	- activities: <full output from step 1>

3. Parse the activity names from step 1.

4. For each activity, call the Task Management server tool `add_task` once using:
	- task_description: "[{city}] <activity name>"

5. For each activity, call this server tool `record_activity_cost` once using:
	- city: "{city}"
	- activity_name: "<activity name>"
	- price_summary: "<price line/details from step 2 for that activity>"

6. Return a final summary containing:
	- activities plan
	- estimated prices
	- list of tasks created in the task server
	- list of cost records created in `activity_costs.jsonl`

Important:
- Create exactly one task per activity.
- Create exactly one cost record per activity.
- If task creation fails for one activity, continue with the rest and report failures.
- If cost recording fails for one activity, continue with the rest and report failures.
""".strip()


@mcp.tool()
def get_trip_summary(city: str) -> str:
	"""
	Trip summary workflow tool that tells the client how to retrieve and format
	the trip summary with activities and costs.
	"""
	return f"""
Follow this workflow to generate a trip summary for "{city}":

1. Call this server tool `get_costs_resource` (no arguments) to retrieve all recorded activities and costs.

2. From the result, filter for activities where city == "{city}".

3. For each filtered activity, extract:
	- activity_name
	- price_summary

4. For each activity, format as: "<activity_name>. Cost: <price_summary>"
	- If price_summary is empty or "free", use "free" as the cost value

5. Join all formatted activities with "; " (semicolon and space).

6. Return the final summary in this format:
	Trip to {city}. Activities: <formatted activities>

Example output:
	Trip to Paris. Activities: Eiffel Tower. Cost: $20-30 USD; Louvre Museum. Cost: $15-20 USD; Seine River Cruise. Cost: free
""".strip()


if __name__ == "__main__":
	 mcp.run(transport="stdio")
