# https://www.codewars.com/kata/52c31f8e6605bcc646000082/solutions/elixir

defmodule TwoSum do
  def two_sum(numbers, target) do

    numbers
    |> Enum.with_index
    |>  sum(target)

  end

  def sum(numbers, target), do: sum(numbers, Enum.reverse(numbers), target)
  def sum( [_last], [], _) , do: nil
  def sum([_first, second | tail], [], target), do: sum([second] ++ tail, tail, target)
  def sum([{x, i} | _first_tail] = first_list, [{y, iy} | second_tail], target) do
    cond  do
       x + y == target -> {i, iy}
      true -> sum(first_list, second_tail, target)
    end
  end
end
