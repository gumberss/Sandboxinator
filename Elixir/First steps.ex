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

















    