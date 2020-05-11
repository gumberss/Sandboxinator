defmodule Discuss.User do
  use Discuss.Web, :model

  schema "users" do
    field :emil,:string
    field :provider, :string
    field :token, :string

    timestamps()
  end

  def changeset(struct, params\\%{}) do
    struct
    |> cast(params, [:emaill, :provider, :token])
    |> validate_required([:email, :provider, :token])
  end
end
