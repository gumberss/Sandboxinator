
defmodule Fibonacci do
  def fibonacci(n), do: fibonacci(0, 1, n)
  def fibonacci(result, _, 0), do: result
  def fibonacci(before, current, count), do: fibonacci(current, before + current  , count-1)
end
