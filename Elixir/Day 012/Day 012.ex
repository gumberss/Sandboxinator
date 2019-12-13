

msgs = [
  "72ff1d14-756a-4549-9185-e60e326baf1b,kind,created,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "af745f6d-d5c0-41e9-b04f-ee524befa425,kind2,added,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "450951ee-a38d-475c-ac21-f22b4566fb29,kind2,added,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "450951ee-a38d-475c-ac21-f22b4566fb29,kind2,updated,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "450951ee-a38d-475c-ac21-f22b4566fb29,kind2,removed,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "450951ee-a38d-475c-ac21-f22b4566fb29,kind3,updated,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "450951ee-a38d-475c-ac21-f22b4566fb29,kind3,removed,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7",
  "66882b68-baa4-47b1-9cc7-7db9c2d8f823,kind3,added,2018-12-15T18:13:46Z,80921e5f-4307-4623-9ddb-5bf826a31dd7"
]

defmodule Solution do
 def process_messages(messages) do

   messages
   |> Enum.each(fn msg ->
     [event_id | data] = String.split(msg, ",")
     [schema | data] = data
     [action | data]  = data

     full_action = "#{schema}.#{action}"

     process(full_action, data)
   end)


 end

 def process("kind.created", data) do
     IO.puts "kind.created with #{inspect(data)}"
 end

 def process("kind.updated", data) do
     IO.puts "kind.updated with #{inspect(data)}"
 end

  def process("kind.deleted", data) do
     IO.puts "kind.deleted with #{inspect(data)}"
 end

 def process("kind2.added", data) do
     IO.puts  "kind2.added with #{inspect(data)}"
 end

 def process("kind2.updated", data) do
     IO.puts  "kind2.updated with #{inspect(data)}"
 end

 def process("kind2.removed", data) do
     IO.puts  "kind2.removed with #{inspect(data)}"
 end

 def process("kind3.added", data) do
     IO.puts  "kind3.added with #{inspect(data)}"
 end

 def process("kind3.updated", data) do
     IO.puts  "kind3.updated with #{inspect(data)}"
 end

 def process("kind3.removed", data) do
     IO.puts  "kind3.removed with #{inspect(data)}"
 end
end


Solution.process_messages(msgs)
