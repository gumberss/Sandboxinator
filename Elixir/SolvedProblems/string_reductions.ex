# https://www.hackerrank.com/challenges/string-reductions/problem

defmodule Solution do
    def solve([], array), do: array
    def solve([first | tail], []), do: solve(tail, [first])
    def solve([first | tail], array) do
        case Enum.member?(array, first) do
            true -> solve(tail, array)
            false -> solve(tail, array ++ [first])
        end
    end
    def solve(line), do: 
        line 
        |> String.to_charlist 
        |> solve([])
end

line = IO.read(:all)

IO.puts Solution.solve(line)