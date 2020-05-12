defmodule Discuss.TopicController do

  use Discuss.Web, :controller
  alias Discuss.Topic
  #plug Discuss.Plugs.RequireAuth when action in [ :new, :create, ]


  def index(conn, _params) do
    topics = Repo.all(Topic)

    render conn, "index.html", topics: topics
  end

  def new(conn, _params) do
    changeset = Topic.changeset( %Topic{}, %{})

    render conn, "new.html", changeset: changeset
  end

  def create(conn, %{"topic" => topic}) do

    changeset = Topic.changeset(%Topic{}, topic)

    case Repo.insert(changeset) do
      { :ok, _post } ->
        conn
        |> put_flash(:info, "Topic Created")
        |> redirect(to: topic_path(conn, :index))
      { :error, changeset } ->
        render conn, "new.html", changeset: changeset
    end
  end

  def edit(conn, %{"id" => topic_id}) do

  end

end
