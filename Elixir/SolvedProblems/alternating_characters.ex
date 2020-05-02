# https://www.hackerrank.com/challenges/alternating-characters/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings

defmodule Solution do

    def solve([]), do: [] 
    def solve([ current | tail ]) do

        current
        |>String.to_charlist
        |> alternate
        |> IO.puts

        solve(tail)

    end

    def alternate([last]), do: 0
    def alternate([first, second | tail]) do

        case first == second do
            true -> 1 + alternate([second] ++ tail)
            false -> alternate([second] ++ tail)
        end

    end

end

[count | lines] = 
    IO.read(:all)
    |> String.split("\n")

#Solution.solve(lines)

lines |> Solution.solve
