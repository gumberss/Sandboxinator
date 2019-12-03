IO.puts is_number(14)

IO.puts "oi
meu amigo
legal"

IO.puts 2 - 1
IO.puts 2 + 1
IO.puts 2 * 2
IO.puts 2 / 2
IO.puts rem(10, 3)

IO.puts 2 / 2 == div(2,2)
IO.puts 2 / 2 === div(2,2)


hero = "Batman"
IO.puts "Hello #{hero}"

IO.puts "Hello " <> hero

list = [3.14,:haha, "Batman", "Other"]
list2 = ["Iron man","Thanos", "Jean Gray", 2]
list3 = list ++ list2

# prepending
    IO.puts inspect(["first" | list])
    # O(1)


# apending
    IO.puts inspect(list ++ ["last"])
    # O(n)
    
IO.puts inspect([1,2,3,4,5] -- [3,4,5])

#get header, first element
    IO.puts hd [3.14, :haha, "Batman"]

#get tail, other elements
    IO.puts inspect(tl [3.14, :haha, "Batman"])
    
#tuple
IO.puts inspect({10,"Thanos", 2.14})
IO.puts inspect([hero: "Batman", badGuy: "Thanos"])

#map
map = %{:hero => "Batman", "badGuy" => "Thanos", hero => hero}
IO.puts map[:hero]
IO.puts map["badGuy"]
IO.puts map[hero]
#only with atom
    IO.puts map.hero
    IO.puts inspect(%{map | hero: "Iron Man"})


IO.puts inspect(Map.put(map, :anotherKey, "another"))

IO.puts Enum.all?(list, fn(s) -> s != nil end)
IO.puts Enum.any?(list, fn(s) -> s == nil end)

#IO.puts inspect(Enum.chunk_every(list,2))
IO.puts inspect(Enum.chunk_by(list, fn(x) -> x == "Batman" end))
IO.puts ""
IO.puts "map every"
Enum.map_every(list3, 3, fn(x) -> IO.puts x end )
IO.puts "end map every"
IO.puts ""
IO.puts "each method"
Enum.each(list3, fn(x) -> IO.puts x end)
IO.puts "end each method"
IO.puts ""
IO.puts "each method"
IO.inspect(Enum.map(list3, fn(x) -> inspect(x) end))

IO.puts "end each method"
IO.puts ""


IO.puts Enum.min list
IO.puts Enum.min [], fn -> 0 end

IO.puts Enum.max list
IO.puts Enum.max [], fn -> 0 end

IO.puts inspect Enum.filter list3, fn(x) -> is_number(x) end

integerList = [1,3,5,7,2,4,6,8]

IO.puts Enum.reduce integerList, fn(x, acc) -> acc + x end

IO.puts Enum.reduce integerList, 100, fn(x, acc) -> acc + x end

IO.puts inspect Enum.sort integerList

IO.puts inspect  Enum.sort integerList, fn(x, y) -> x > y end

duplicatedIntegerList = integerList ++ integerList

IO.puts inspect duplicatedIntegerList
IO.puts inspect Enum.uniq duplicatedIntegerList

IO.puts inspect Enum.uniq_by duplicatedIntegerList, fn(x) -> x end

x = 5
y = 3
{x,y} = {y,x}
IO.puts x
IO.puts y


hello = "hello"

greet = fn
    (^hello,name) -> "Hi my friend #{name}"
    (hello,name) -> "#{hello} my friend #{name}"
end

IO.puts greet.("hello", "batman")

IO.puts greet.("Mornin'", "batman")

IO.puts greet.("hello", "batman")

IO.puts ""
IO.puts "___________control structures___________"

if "string value" do
    IO.puts "string value valid"
else
    IO.puts "invalid"
end

unless is_integer("string") do
    IO.puts "Not an integer"
end

case {:ok, "Hello"} do
    {:ok, result} -> IO.puts result
    {:error} -> IO.puts "Uh oh!"
    _ -> IO.puts"Catch all"
end

anotherHero = "batman"

case "Iron man" do
    ^anotherHero -> IO.puts "Batman is good"
    hero -> IO.puts "#{hero} is good too"
end


case {1,2,3} do
    {1,x,3} when x > 1 -> IO.puts "Yeahhh!!"
    _ -> IO.puts "Not so good"
end


cond do
    2 + 2 === 5 ->
    IO.puts "Never"
    
    2 * 5 === 8 ->
    IO.puts "Are you kidding me?"
    
    4 + 4 === 8 -> 
    IO.puts "Ok, you are right"
end

cond do
    1 + 1 === 3  -> IO.puts "Whatt??"
    1 + 3 === 6 -> IO.puts "No, try again"
    true -> IO.puts "Why are you using hack?"
end

maybeBatman = %{ first: "Bruce", last: "Wayne" }


with {:ok, first} <- Map.fetch(maybeBatman, :first),
{:ok, last} <- Map.fetch(maybeBatman, :last),
do: IO.puts "Problably batman: " <> first <> " " <> last

import Integer

m = %{ a: 2, b: 3 }
IO.puts inspect Map.fetch(m, :b)

 with {:ok, number} <- Map.fetch(m, :c),
        true <- is_even(number) do
        IO.puts "#{number} divided by 2 is #{div(number, 2)}"
        :even
    else
        :error -> 
            IO.puts "This item is not in the map"
            :error
        
    _ -> IO.puts "It is odd number" 
end


whoAreYou = 
%{
    "batman" => fn(yourName) -> "#{yourName} is the batman!" end,
    thanos: fn(yourName) -> "#{yourName} is Thanos" end
}

youAreThanos = whoAreYou[:thanos]
youAreBatman = whoAreYou["batman"]

IO.puts youAreThanos.("Thanos")
IO.puts youAreBatman.("Batman")
    
