defmodule Solution do
  def positive_sum([], acc), do: acc
  def positive_sum([head | tail], acc) when head > 0, do: positive_sum(tail, acc + head)
  def positive_sum([head | tail], acc), do: positive_sum(tail, acc)
  def positive_sum(numbers), do: positive_sum(numbers, 0)
end
