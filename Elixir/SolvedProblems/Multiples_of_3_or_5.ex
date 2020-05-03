# https://www.codewars.com/kata/514b92a657cdc65150000006/train/elixir

defmodule Challenge do
  def solution(number) do
     1..(number - 1)
     |> Enum.to_list
     |> sum_multiples
  end

  def sum_multiples([ ]), do: 0
  def sum_multiples([ first | tail ]) do
     cond do
       rem(first, 3) == 0 -> first + sum_multiples(tail)
       rem(first, 5) == 0 -> first + sum_multiples(tail)
       true -> sum_multiples(tail)
     end
  end
end
