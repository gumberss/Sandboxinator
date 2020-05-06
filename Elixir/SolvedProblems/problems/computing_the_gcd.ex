# https://www.hackerrank.com/challenges/functional-programming-warmups-in-recursion---gcd/problem

defmodule Solution do

    def solve([0, result]), do: IO.puts result
    def solve([ first, second ]) do
        mod = rem(second, first)
        solve([mod, first])
    end
end

numbers = IO.read(:all)
|> String.split(" ")
|> Enum.map(&String.to_integer/1)

Solution.solve(numbers)