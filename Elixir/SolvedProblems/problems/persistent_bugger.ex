# https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec/train/elixir
# certainly it is not the best way
defmodule PersistentBugger do

  def persistence(number)  when number < 10, do: 0
  def persistence(number) do
    (number
    |> Integer.to_string
    |> String.to_charlist
    |> Enum.map(fn x -> x - 48 end)
    |> Enum.reduce(1, fn x, acc -> x * acc end)
    |> persistence) + 1
  end
end


# better way:

defmodule PersistentBugger do

  def persistence(number, x \\ 0)
  def persistence(number, x) when number < 10, do: x
  def persistence(number, x) do
    number
    |> Integer.digits
    |> Enum.reduce(fn c, acc -> c * acc end)
    |> persistence(x + 1)
  end
end

# different way to use anonymous function:

defmodule PersistentBugger do

  def persistence(number, x \\ 0)
  def persistence(number, x) when number < 10, do: x
  def persistence(number, x) do
    number
    |> Integer.digits
    |> Enum.reduce(&(&1 * &2))
    |> persistence(x + 1)
  end
end
