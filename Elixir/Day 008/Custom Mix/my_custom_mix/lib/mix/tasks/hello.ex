
defmodule Mix.Tasks.Hello do
  use Mix.Task
  @shortdoc "Simply runs the Hello.say/0 function"
  def run(_) do
    MyCustomMix.say()
  end
end
