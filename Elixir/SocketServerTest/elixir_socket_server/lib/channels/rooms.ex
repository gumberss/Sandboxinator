defmodule ElixirSocketServerWeb.Channels.Rooms do
  use ElixirSocketServerWeb, :channel

  def join("room:test", message, socket) do

    IO.puts inspect message

    {:ok, socket}
  end
end
