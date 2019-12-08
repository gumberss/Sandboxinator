defmodule MyCustomMixTest do
  use ExUnit.Case
  doctest MyCustomMix

  test "greets the world" do
    assert MyCustomMix.hello() == :world
  end
end
