# https://www.codewars.com/kata/5bb904724c47249b10000131/train/elixir
defmodule TotalPoints do

  def points([]), do: 0
  def points([first | tail]) do
    [first, second] = String.split(first, ":")
    [x, y] = [String.to_integer(first), String.to_integer(second)]

    (cond do
      x > y -> 3
      x == y -> 1
      true -> 0
    end) + points(tail)
end
end
