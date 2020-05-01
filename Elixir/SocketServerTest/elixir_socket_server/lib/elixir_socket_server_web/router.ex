defmodule ElixirSocketServerWeb.Router do
  use ElixirSocketServerWeb, :router


  pipeline :api do
    plug :accepts, ["json"]
  end

  scope "/api", ElixirSocketServerWeb do
    pipe_through :api
  end
end
