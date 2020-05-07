defmodule Kata do
  def digital_root(n) when n < 10, do: n
  def digital_root(n), do: n |> Integer.digits |> Enum.sum |> digital_root
end
