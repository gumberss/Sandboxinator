map = %{"Hi" => "Hello", :two => "Should be 2", :name => "Batman"}

IO.puts inspect map
IO.puts map[:name]
IO.puts map["Hi"]
IO.puts map.name #Only with atoms

%{two: otherName} = map #Look here, the Key of the right side should be equal the Key of the left side
IO.puts otherName

#update with atoms:
IO.puts inspect %{map | two: "Certainly is two"}

IO.puts Map.get(map, "Hi")

IO.puts Map.get_lazy(map, :name, fn -> "I couldn't find the key :(" end)
IO.puts Map.get_lazy(map, :unknown, fn -> "I couldn't find the key :(" end)
IO.puts Map.has_key?(map, :name)
IO.puts Map.has_key?(map, :unknown)

IO.puts inspect Map.keys(map)
IO.puts inspect Map.values(map)

ab = %{a: 1, b: 2}
ac = %{a: 1, c: 3}
IO.puts inspect Map.merge(ab, ac)
IO.puts inspect Map.pop(ab, :a)
IO.puts inspect Map.pop(ab, :unknown)

{result, newArray} = Map.pop(ab, :unknown)
IO.puts inspect result
IO.puts inspect newArray

{result, newArray} = Map.pop(ab, :unknown, "I couldn't find the key :(")
IO.puts inspect result
IO.puts inspect newArray
