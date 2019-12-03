numberList = [1,3,5,7,2,4,6,8]

defmodule Length do
    def of([]), do: 0
    def of([_ | tail]), do: 1 + of(tail)
    
end

IO.puts Length.of numberList

defmodule Greeter do
    def hello(), do: "Hello, anonymous person!"
    def hello(%{name: name}), do: "Hello map person named " <> name
    def hello(name), do: "Hello #{name}"
    def hello(name, dog_name), do: "Hello #{name} and your beautiful dog " <> dog_name
end

IO.puts Greeter.hello()
IO.puts Greeter.hello("Batman")
IO.puts Greeter.hello("batman", "Batdog")

batman = %{
    name: "Batman", 
    favorite_color: "black",
    super_power: "money",
    pet: "Batdog"
}

IO.puts Greeter.hello(batman)


defmodule Greeter2 do
    def hello(%{name: person_name} = person) do
        "Hello, #{person_name}. You are: " <> inspect person
    end
end

IO.puts Greeter2.hello(batman)

defmodule Greeter3 do
    def hello(%{name: person_name} = person = %{pet: pet_name}) do
        "Hello, #{person_name} and pet #{pet_name}. You are: " <> inspect person
    end
    def hello(%{name: person_name, car: car} = person) do 
        "Hello, #{person_name}. You have a: #{car} and you have are " <> inspect person
    end
    def hello(person = %{name: person_name}) do 
        "Hello, #{person_name}. You are: " <> inspect person
    end
end

IO.puts Greeter3.hello(batman) 

batman_without_pet = %{
    name: "Batman", 
    favorite_color: "black",
    super_power: "money",
}
IO.puts Greeter3.hello(batman_without_pet) 

batman_withcar = %{
    name: "Batman", 
    favorite_color: "black",
    super_power: "money",
    car: "batmovel"
}
IO.puts Greeter3.hello(batman_withcar) 

IO.puts ""


defmodule Email do
    def get(title), do: phrase <> title
    defp phrase, do: "Retrieving "
end

IO.puts Email.get "My beautiful email"

defmodule GreeterHero do
    def hello(names) when is_list(names) do
        names 
        |> Enum.join(", ") 
        |> hello
    end
    
    def hello(name) when is_binary(name), do: phrase() <> name
    
    defp phrase, do: "Hello, "
end

IO.puts GreeterHero.hello(["Iron man", "Batman"])

defmodule Window do
    def open(name, language_code \\ "en") do
        phrase(language_code) <> name
    end
    defp phrase("en"), do: "Opened by "
    defp phrase("pt"), do: "Aberto por "
end

IO.puts Window.open "Batman"
IO.puts Window.open "Batman", "en"
IO.puts Window.open "Batman", "pt"

defmodule Window2 do
    def open(name, language_code \\ "en")
    
    def open(names, language_code) when is_list(names) do
        names
        |> Enum.join(", ")
        |> open(language_code)
    end
    
    def open(name, language_code) when is_binary(name) do
        phrase(language_code) <> name
    end
    
    defp phrase("en"), do: "Opened by "
    defp phrase("pt"), do: "Aberto por "
end

IO.puts Window2.open(["Iron man", "batman", "Thanos"])

IO.puts ""
IO.puts "_____Pipe Operator_____"
IO.puts ""

"Batman is a very cool guy, what a pity he can't see joker"
|> String.split(" ") |> Enum.filter(fn(word) -> String.length(word) > 3 end) |> Enum.join(", ") |> IO.puts

"Batman is a very cool guy, what a pity he can't see joker"
|> String.split(" ")
|> Enum.filter(fn(word) -> String.length(word) > 3 end ) 
|> Enum.reverse
|> Enum.join(", ")
|> String.upcase
|> IO.puts


IO.puts ""
IO.puts "_____Module_____"
IO.puts ""

defmodule Example do
    @greeting "Hello"
    
    def greeting(name) do
        ~s(#{@greeting} #{name}) <> ~s( other way to create a string)
    end
end

IO.puts Example.greeting "Batman"

IO.puts ""
IO.puts "_____Structs_____"
IO.puts ""

defmodule User do
    defstruct name: "Batman", friends: []
end

#defmodule Example.User do
  #@derive{Inspect, only: [:name]}
  #@derive{Inspect, except: [:roles]}
  #defstruct name: "Sean", roles: []
#end

#IO.puts inspect %Example.User{}


defmodule Sayings.Greetings do
    def hello(name), do: "Hi, #{name}"
end

defmodule Test do
    alias Sayings.Greetings
    def greeting(name), do: Greetings.hello(name)
end

IO.puts Test.greeting("Batman")

defmodule Test2 do
    alias Sayings.Greetings, as: Hi
    
    def greeting(name), do: Hi.hello(name)
end

IO.puts Test2.greeting("Robin")
