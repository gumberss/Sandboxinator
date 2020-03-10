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

      #cards = for suit <- suits do # this method is a map method.
        #for value <- values do
         # "#{value} of #{suit}"
        #end
      #end
      #List.flatten(cards)

      for suit <- suits, value <- values do # do the same thing of the commented code above, but with a better syntax
          "#{value} of #{suit}"
        end
  end

  def shuffle(deck) do
    Enum.shuffle(deck)
  end

  def contains?(deck, card) do
    Enum.member?(deck, card)
  end

  def deal(deck, hand_size) do
    Enum.split(deck, hand_size)
  end
end
