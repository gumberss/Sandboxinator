# https://www.hackerrank.com/challenges/string-mingling/problem

defmodule Solution do
    def solve([first_line, second_line]) do

        first_characters = String.split(first_line, "")
        second_characters = String.split(second_line, "")

        IO.puts print_together(first_characters, second_characters)
    end

    def print_together([x], [y]), do: x <> y
    def print_together([x | first_tail], [y | second_tail]) do
        x <> y <> print_together(first_tail, second_tail)
    end
end

 lines = 
    IO.read(:all)
    |> String.split("\n")

Solution.solve(lines)
