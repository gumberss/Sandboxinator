# https://www.codewars.com/kata/55fd2d567d94ac3bc9000064/train/elixir

defmodule SumOfOdd do
  def row_sum_odd_numbers(n) do
    element_even_line(n - 1)..element_even_line(n) - 1
    |> Enum.map(&(&1 * 2 + 1))
    |> Enum.sum
  end

  def element_even_line(0), do: 0
  def element_even_line(n), do: n + element_even_line(n-1)
end


# Is could be as simple as:
defmodule SumOfOdd do
  def row_sum_odd_numbers(n), do: n * n * n
end

#kkkkkkk
