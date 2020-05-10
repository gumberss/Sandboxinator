# https://www.codewars.com/kata/5656b6906de340bd1b0000ac/train/elixir

defmodule TwoToOne do
  def longest(a, b) do
    String.to_charlist(a) ++ String.to_charlist(b)
      |> MapSet.new
      |> MapSet.to_list
      |> List.to_string
  end
end
