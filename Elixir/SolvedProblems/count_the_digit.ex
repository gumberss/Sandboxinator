# https://www.codewars.com/kata/566fc12495810954b1000030/train/elixir

defmodule Countdigit do
  def nb_dig([]), do: []
  def nb_dig([head | tail]) do
    (head
    |> :math.pow(2)
    |> round
    |> Integer.digits)
    ++
    nb_dig(tail)
  end
  def nb_dig(n, d) do
    0..n
    |> Enum.to_list
    |> nb_dig
    |> Enum.count(&(&1 == d))
  end
end

# A better way:
defmodule Countdigit do
  def nb_dig(n, d) do
    0 .. n
      |> Stream.flat_map(&(Integer.digits(&1 * &1)))
      |> Enum.count(&(&1 == d))
  end
end

# Enum is eager load
# Stream is lazy load

# the first solution create an array and iterate on that.
# the second one is lazy so only create the array when calls Enum.count

# and of course &1 * &1 is very simple then :math.pow(2) |> round...
