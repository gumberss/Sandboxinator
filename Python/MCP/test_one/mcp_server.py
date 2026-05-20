import os
import requests
import logging
from mcp.server.fastmcp import FastMCP

# Initialize the FastMCP server
mcp = FastMCP("WeatherAssistant")

@mcp.tool()
def sum_values(value1 : float, value2 : float) -> float:
    """
    sum two values
    """
    return value1 + value2

@mcp.tool()
def divide(dividend : float, divisor : float) -> float:
    """
    divide the first value by the second one
    """
    return dividend / divisor

@mcp.prompt()
def average() -> str:
    """
    This prompt will describe how to make the average of the values
    """
    return f"""
Step 1:
Call tool: sum_values
Arguments:
- value1 = first number
- value2 = second number

Step 2:
Call tool: divide
Arguments:
- dividend = result from step 1
- divisor = 2

Step 3:
Call prompt: present_result
Arguments:
- text_to_be_present = result from step 2"""


@mcp.prompt()
def present_result() -> str:
    """
    This prompt will describe how to present text to the customer
    """
    return f"""
If the customer is funny, answer as: 'You are crazy bro, this is your answer: [The text to be presented]
owtherwise present as: 'THe result is [The text to be presented]''
"""


if __name__ == "__main__":
    logging.getLogger("mcp").setLevel(logging.WARNING)
    # The server will run and listen for requests from the client over stdio
    mcp.run(transport="stdio")