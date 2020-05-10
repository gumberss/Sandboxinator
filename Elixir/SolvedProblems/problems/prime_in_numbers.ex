# https://www.codewars.com/kata/54d512e62a5e54c96200019e/train/elixir

defmodule PrimesInNumbers do
  def prime_factors(n) do
    n
    |> lcm
    |> Enum.group_by(&(&1))
    |> Enum.map(&factor/1)
    |> Enum.join
  end

  def lcm(n), do: lcm(n, 2, [])
  def lcm(1, _div, divisors), do: divisors
  def lcm(n, div, divisors) when rem(n, div) != 0, do: n |> lcm(div + 1, divisors)
  def lcm(n, div, divisors), do: n / div |> round |> lcm(div, [div | divisors])

  def factor({key, values}) when length(values) == 1, do: "(#{key})"
  def factor({key, values}), do: "(#{key}**#{length(values)})"
end


# My better way (adding limit to calculate):

defmodule PrimesInNumbers do
  def prime_factors(n) do
    n
    |> lcm
    |> Enum.group_by(&(&1))
    |> Enum.map(&factor/1)
    |> Enum.join
  end

  def lcm(n), do: lcm(n, 2, [], :math.sqrt(n))
  def lcm(n, div, divisors, _limit) when div == n, do: [n] ++ divisors
  def lcm(n, div, divisors, limit) when div > limit, do: n |> lcm(n, divisors, limit)
  def lcm(n, div, divisors, limit) when rem(n, div) != 0, do: n |> lcm(div + 1, divisors, limit)
  def lcm(n, div, divisors, limit), do: n / div |> round |> lcm(div, [div | divisors], limit)

  def factor({key, values}) when length(values) == 1, do: "(#{key})"
  def factor({key, values}), do: "(#{key}**#{length(values)})"
end

