defmodule Day5Part2Test do
  use ExUnit.Case
  doctest Day5 # What I'll test

  setup_all do
    {:ok, recipient: :world}
  end

  test "Let's see if it's work", state do
    assert Day5.hello() == state[:recipient]
  end
end
