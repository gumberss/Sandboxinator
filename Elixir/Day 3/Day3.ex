
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

IO.puts Hi2.hello("Batman")


