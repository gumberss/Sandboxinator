
list = [1,2,3,4,5]
defmodule Sayings.Greetings do
    def basic(name), do: "Hello, #{name}"
end

defmodule Sayings.Farewells do
    def bye(name), do: "Bye, " <> name
end

#defmodule Example do
    #alias Sayings.{Greetings, Farewells}

#    def sayEverthing(name) do
#        Greetings.basic(name) <> " " <> Farewells.bye(name)
#    end
#end
#IO.puts Example.sayEverthing "Batman"

import List
IO.puts last(list)

import List, only: [last: 1] #importa apenas a função last do módulo
#IO.puts first(list) #error
IO.puts last list

#import List, except: [last: 1] #importa todos as funções menos a função last

#IO.puts last(list) #error

#import List, only: :functions
#import List, only: :macros

defmodule Test do
    #require SuperMacros

    #SuperMacros.do_stuff
end


defmodule Hello do
    defmacro __using__(_opts) do
        quote do
            def hello(name), do: "Hi, #{name}"
        end
    end
end

defmodule Hi do
    use Hello
end

IO.puts Hi.hello("Batman")

defmodule Hello2 do
    defmacro __using__(opts) do
        greeting = Keyword.get(opts, :greeting, "Hi")
        quote do
            def hello(name), do: unquote(greeting) <> ", " <> name
        end
    end
end

defmodule Hi2 do
    use Hello2, greeting: "Olá"
end

IO.puts Hi2.hello("Batman")d

# iex -S mix #compila o codigo??
# mix compile #compila o projeto
# mix deps.get #buscar dependencias definidas
# MIX_ENV=prod mix compile # onde e como usar??

#c e C são utilizados pararepresentar caracteres
#c = permite fazer interpolação de string
#C = NÃO permite fazer interpolação de string
IO.puts ~c/2 + 7 = #{2 + 7}/
IO.puts ~c(2 + 7 = #{2 + 7})
IO.puts ~C/2 + 7 = #{2 + 7}/

#r e R são utilizados para representar expressões regulares

re = ~r/elixir/
IO.puts "Elixir" =~ re
IO.puts "elixir" =~ re
re = ~r/[Ee]lixir/
IO.puts "Elixir" =~ re
IO.puts "elixir" =~ re

string_number = "100_000_000"

IO.puts inspect Regex.split(~r/_/, string_number)

IO.puts ~s{Hello my friend}
IO.puts ~s(How are you?)
IO.puts ~s|How are you doing?|
bat = "Batman"
IO.puts ~s|How are you doing #{bat}?|
IO.puts ~S|How are you doing #{bat}?|

lol = "hahaha"

IO.puts inspect ~w/I know everthing i'm doing now #{lol}/
IO.puts inspect ~W/I know everthing i'm doing now #{lol}/


~w/I know everthing i'm doing now #{lol}/
|> Enum.reverse |> inspect |> IO.puts

#IO.puts NaiveDateTime.from_iso8601("2015-01-23 23:50:07") == {:ok, ~N[2015-01-23 23:50:07]}

@doc """
defmodule MyFirstSigil do
    def sigil_u(string, []), do: String.upcase(string)
end

import MyFirstSigil

IO.puts ~u(Everthing in upper case \o/)
"""







