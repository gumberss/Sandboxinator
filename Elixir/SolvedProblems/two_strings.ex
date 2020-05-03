# https://www.hackerrank.com/challenges/two-strings/problem?h_l=interview&isFullScreen=false&playlist_slugs%5B%5D%5B%5D%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D%5B%5D%5B%5D=dictionaries-hashmaps	

defmodule Solution do

    def solve([]), do: :ok
    def solve([first, second | tail]) do 

        IO.puts if has_substring?(first, second), do: "YES", else: "NO"        

        solve tail

    end

    def has_substring?(_, []), do: false
    def has_substring?([], _), do: false
    def has_substring?([first | first_tail]  = first_line, [second | second_tail] = second_line) do

        if first == second do
            true
        else
            has_substring?(first_line, second_tail) 
            or has_substring?(second_line, first_tail) 
        end

    end

end


 [count | lines] =  
    IO.read(:all)
    |> String.split("\n")
    |> Enum.map(fn x -> 
        x 
        |> String.to_charlist
        |> Enum.into(MapSet.new)
        |> MapSet.to_list
    end)
    

Solution.solve(lines)

