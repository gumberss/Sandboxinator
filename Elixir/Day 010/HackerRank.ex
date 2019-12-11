#https://www.hackerrank.com/challenges/functional-programming-warmups-in-recursion---fibonacci-numbers/problem

defmodule Fibonacci do
  def calc(1), do: 0
  def calc(2), do: 1
  def calc(n), do: calc(n-1) + calc(n-2)

  def tail(1, lastAcc, _), do: lastAcc
  def tail(n, lastAcc, acc), do: tail(n-1, acc, lastAcc + acc)
end


#IO.puts Fibonacci.calc(40)
# 5.24 sec

#IO.puts Fibonacci.tail(40, 0, 1)
#0.76 sec


input = IO.read(:stdio, :all)

input
|> Integer.parse
|> elem(0)
|> Fibonacci.calc
|> IO.puts

#_____________________________________________________-
