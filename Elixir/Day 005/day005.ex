# mix test # run the tests

#Comprehensions
list = [1,3,5,7,2,4,6,8]
IO.puts inspect for x <- list, do: x*x

map = %{ hello: "Hello",batman: "Batman", Thanos: "He is really cool" }

IO.puts inspect for {key, value} <- map, do: "#{key} " <> value

IO.puts inspect for <<c <- "String" >>, do: <<c>>

#generators use pattern matching, so if an match between
#left and right sides of the expression don't ware found,
#the value is ignored. see it:
IO.puts inspect for {:ok, val} <- [ok: "This value match", error: "This value is ignored", ok: "This value match too"], do: val

even = [2,4,6]
odd = [1,3,5]

IO.puts inspect for x <- even, y <-odd, do: "x: #{x} and y: #{y}. x + y = #{x + y}"


#Comprehensions Filters

import Integer
even2 = for x <- list, is_even(x), do: x
IO.puts inspect even2
odd2 = for x <- list, is_odd(x), do: x
IO.puts inspect odd2

IO.puts inspect for x <- list,
    is_even(x),
    rem(x, 4) == 0,
    do: x


IO.puts inspect for x <- list, y <- list,
    is_even(x),
    rem(x, 4) == 0,
    is_odd(y),
    y > 3,
    do: "x: #{x} + y: #{y} = #{x + y}"

listKeyValue = [key: "value", key2: 3, key3: "Batman"]
newMap = for {key, value} <- listKeyValue, into: %{}, do: {key, value}

IO.puts inspect newMap

helloArray = [72,101,108,108,111]
hello = for letter <- helloArray, into: "", do: <<letter>>

IO.puts hello




