#https://www.hackerrank.com/challenges/fp-reverse-a-list/

defmodule Solution do
  def method(elements) do
    elements
    |> Enum.reduce([], fn current, acc -> [current | acc] end)
    |> Enum.each(fn element -> IO.puts element end)
  end
end

input = IO.read(:stdio, :all)
|> String.split("\n")
|> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)

#______________________________________________________________________________

#https://www.hackerrank.com/challenges/fp-sum-of-odd-elements/
defmodule Solution do
  def method(elements) do
    elements
    |> Enum.filter(fn element -> rem(element, 2) != 0 end)
    |> Enum.sum
    |> IO.puts
  end

end

input = IO.read(:stdio, :all)
|> String.split("\n")
|> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)
#______________________________________________________________________________


#https://www.hackerrank.com/challenges/fp-list-length/
defmodule Solution do
  def method(elements) do
   elements
    |> Enum.reduce(0, fn element, acc -> acc + 1 end)
    |> IO.puts

  end

end

input = IO.read(:stdio, :all)
|> String.split("\n")
|> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)

#______________________________________________________________________________
