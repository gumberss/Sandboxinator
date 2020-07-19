defmodule Oceanize.Repo do
  use Ecto.Repo,
    otp_app: :oceanize,
    adapter: Ecto.Adapters.Postgres

    def init(_, config) do
      config = config
        |> Keyword.put(:username, "postgres")#System.get_env("PGUSER")
        |> Keyword.put(:password, "postgres")
        |> Keyword.put(:database, "oceanize")
        |> Keyword.put(:hostname, "localhost")
        |> Keyword.put(:port, "5432" |> String.to_integer)
      {:ok, config}
    end
end
