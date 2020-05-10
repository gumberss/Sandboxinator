# https://www.codewars.com/kata/5426d7a2c2c7784365000783/train/elixir

  @doc """
  ## Examples
      iex> Kata.balanced_parens(2)
      ["(())", "()()"]

      iex> Kata.balanced_parens(3)
      ["((()))", "(()())", "(())()", "()(())", "()()()"]

  """
defmodule Kata do

    def balanced_parens(0, 0, char_array), do: [List.to_string char_array]
    def balanced_parens(0, c, char_array), do: [ balanced_parens(0, c-1, char_array ++ [41]) ]
    def balanced_parens(o, c, char_array) when o == c, do: [balanced_parens(o-1, c, char_array ++ [40])]
    def balanced_parens(open, close, char_array) do
        [balanced_parens(open-1, close, char_array ++ [40])] ++ [balanced_parens(open, close-1, char_array ++ [41])]
    end
    def balanced_parens(n), do: List.flatten(balanced_parens(n, n, []))
end

# tail recursion (little less memory and processing used)

defmodule KataTail do

    def balanced_parens(0, 0, char_array, tail), do: [List.to_string(char_array)] ++ tail
    def balanced_parens(0, n, char_array, tail), do: [ balanced_parens(0, n-1, char_array ++ [41], tail) ]
    def balanced_parens(o, c, char_array, tail) when o == c, do: [balanced_parens(o-1, c, char_array ++ [40], tail)]
    def balanced_parens(open, close, char_array, tail) do
        balanced_parens(open, close-1, char_array ++ [41], balanced_parens(open-1, close, char_array ++ [40], tail))
    end
    def balanced_parens(n), do: List.flatten(balanced_parens(n, n, [], []))
end

IO.inspect KataTail.balanced_parens(5)
