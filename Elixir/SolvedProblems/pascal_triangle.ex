https://www.hackerrank.com/challenges/pascals-triangle/problem

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



####################

#Another way
####################


defmodule Solution do

    def solve(1, _), do: []
    def solve(count, []) do
        IO.puts 1
        solve(count, [1])
    end
    def solve(count, old_line) do

        new_line = sum_line(old_line)
        
        IO.puts Enum.join( new_line," ")
        solve(count - 1, new_line)
    end
    
    def sum_line(list), do: sum_line( [0] ++ list, Enum.reverse(list ) ++ [0])
    def sum_line([ last ], [ last_second_list]), do: [last + last_second_list]
    def sum_line([ first | first_tail], [first_second_list | second_tail]) do
        [first + first_second_list] ++ sum_line(first_tail, second_tail)
        
    end

end

 lines = IO.read(:all)
{value, _} =  Integer.parse(lines)
Solution.solve(value, [])

