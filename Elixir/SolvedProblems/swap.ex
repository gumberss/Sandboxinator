#https://www.hackerrank.com/challenges/string-o-permute/problem
defmodule Solution do

    def solve([]), do: []
    def solve([current| tail]) do
        swap_array current
        solve tail
    end

    def swap_array(data) do
        data
        |> String.to_charlist
        |> swap
        |> List.to_string
        |> IO.puts
    end
    
    def swap([]), do: []
    def swap([first, second | tail]) do
        [second, first] ++ swap(tail)
    end
end

[_ | rest] = IO.read(:all) 
    |> String.split("\n")

Solution.solve(rest)
