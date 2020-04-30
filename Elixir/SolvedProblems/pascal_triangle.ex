defmodule Solution do

    def solve(1, _), do: []
    def solve(count, []) do
        IO.puts 1
        solve(count, [1])
    end
    def solve(count, old_line) do

        new_line = sum_line(old_line, [])
        
        IO.puts Enum.join( new_line," ")
        solve(count - 1, new_line)
    end
    
    def sum_line([ last ], new_line), do: [1] ++ new_line ++  [ last ]
    def sum_line([first, second | tail], new_line) do
        sum_line([ second ] ++ tail, new_line ++ [ first + second ])
    end

end

 lines = IO.read(:all)
{value, _} =  Integer.parse(lines)
Solution.solve(value, [])