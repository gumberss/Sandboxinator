defmodule Cards do
  @moduledoc """
  Documentation for Cards.
  """

  @doc """
  Hello world.

  ## Examples

      iex> Cards.hello()
      :world

      Comand: iex -S mix
  """
  def create_deck do
    values = ["Ace", "Two", "Three", "Four", "five"]
    suits = ["Spades", "Clubs", "Heards", "Diamonds"]

      for suit <- suits do # this method is a map method.
        for value <- values do
          value <> " " <> suit
        end
      end
  end

  def shuffle(deck) do
    Enum.shuffle(deck)
  end

  def contains?(deck, card) do
    Enum.member?(deck, card)
  end
end
