# https://www.hackerrank.com/challenges/fp-reverse-a-list/

defmodule Solution do
  def method(elements) do
    elements
    |> Enum.reduce([], fn current, acc -> [current | acc] end)
    |> Enum.each(fn element -> IO.puts(element) end)
  end
end

input =
  IO.read(:stdio, :all)
  |> String.split("\n")
  |> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)

# ______________________________________________________________________________

# https://www.hackerrank.com/challenges/fp-sum-of-odd-elements/
defmodule Solution do
  def method(elements) do
    elements
    |> Enum.filter(fn element -> rem(element, 2) != 0 end)
    |> Enum.sum()
    |> IO.puts()
  end
end

input =
  IO.read(:stdio, :all)
  |> String.split("\n")
  |> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)
# ______________________________________________________________________________

# https://www.hackerrank.com/challenges/fp-list-length/
defmodule Solution do
  def method(elements) do
    elements
    |> Enum.reduce(0, fn element, acc -> acc + 1 end)
    |> IO.puts()
  end
end

input =
  IO.read(:stdio, :all)
  |> String.split("\n")
  |> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)

# ______________________________________________________________________________

# https://www.hackerrank.com/challenges/fp-update-list/
defmodule Solution do
  def method(elements) do
    elements |> Enum.map(fn element -> IO.puts(abs(element)) end)
  end
end

input =
  IO.read(:stdio, :all)
  |> String.split("\n")
  |> Enum.map(fn x -> Integer.parse(x) |> elem(0) end)

Solution.method(input)

# ______________________________________________________________________________

# https://www.hackerrank.com/challenges/eval-ex/
defmodule Solution do
  def method(n, elements) do
    elements
    |> Enum.map(fn element ->
      Enum.reduce(1..9, 1, fn x, acc -> pow(element, x) / factorial(x) + acc end)
    end)
    |> Enum.map(fn element -> IO.puts(Float.floor(element, 4)) end)
  end

  def pow(n, k), do: pow(n, k, 1)
  def pow(_, 0, acc), do: acc
  def pow(n, k, acc), do: pow(n, k - 1, n * acc)

  def factorial(1, acc), do: acc
  def factorial(n, acc), do: factorial(n - 1, acc * n)
  def factorial(n), do: factorial(n, 1)
end

input =
  IO.read(:stdio, :all)
  |> String.split("\n")
  |> Enum.filter(fn x -> x != "" end)
  |> Enum.map(fn x -> Float.parse(x) |> elem(0) end)

[n | elements] = input
Solution.method(n, elements)

# ______________________________________________________________________________
