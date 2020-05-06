# https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/elixir

defmodule PrimesInNumbers do
  def prime_factors(n) do
    n
    |> mmc
    |> Enum.group_by(&(&1))
    |> Enum.map(&factor/1)
    |> Enum.join
  end

  def mmc(n), do: mmc(n, 2, [])
  def mmc(1, _div, divisors), do: divisors
  def mmc(n, div, divisors) when rem(n, div) != 0, do: n |> mmc(div + 1, divisors)
  def mmc(n, div, divisors), do: n / div |> round |> mmc(div, divisors ++ [div])

  def factor({key, values}) when length(values) == 1, do: "(#{key})"
  def factor({key, values}), do: "(#{key}**#{length(values)})"
end
