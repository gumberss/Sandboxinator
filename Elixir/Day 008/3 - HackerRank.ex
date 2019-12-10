#https://www.hackerrank.com/challenges/fp-filter-array/problem
defmodule Solution do
  def method(n, elements) do
      Enum.filter(elements, fn current -> current < n end)
      |> Enum.each(fn current -> IO.puts current end)
  end
end

input = IO.read(:stdio, :all)
|> String.split("\n")
|> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

[n | elements] = input
Solution.method(n, elements)

#__________________________________________

#https://www.hackerrank.com/challenges/fp-filter-positions-in-a-list/problem?h_r=next-challenge&h_v=zen
defmodule Solution do
  def method(n, elements) do
    Enum.take_every(elements, 2)
    |> Enum.each(fn x -> IO.puts x end)

  end
end

input = IO.read(:stdio, :all)
|> String.split("\n")
|> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

[n | elements] = input
Solution.method(n, elements)

#__________________________________________

#https://www.hackerrank.com/challenges/fp-array-of-n-elements/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
defmodule Solution do
  def method(n, elements) do

    #IO.puts inspect(limit: :infinity) Enum.to_list(1..n)
     1..n |> Enum.to_list  |> inspect(limit: :infinity) |> IO.puts
    #IO.puts inspect(limit: :infinity) Enum.into 1..n, []
  end
end

input = IO.read(:stdio, :all)
|> String.split("\n")
|> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

[n | elements] = input
Solution.method(n, elements)

#__________________________________________
