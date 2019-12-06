# I'm a comment
defmodule Greeter do
  @moduledoc """
   I'm a module comment or documentation
  """
  def hello(name) do
    "Hello, #{name}"
  end
end

defmodule Cake do
@moduledoc """
  I'm a cake
  I provide a function `hello/1` to make a cake for you
"""
  @doc """
  ## parameters
  - type: The type you'd like your cake

  Hi, this is the method that make a cake :)

  and this is a comment or documentation about that

  ## Examples
      iex> Cake.make("chocolate")
      "I made a chocolate cake"
  """
  def make(type) do
    "I made a #{type} cake"
  end
end


defmodule NoDoc do
  @moduledoc false
end
