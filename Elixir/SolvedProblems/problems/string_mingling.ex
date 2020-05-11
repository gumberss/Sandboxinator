# https://www.hackerrank.com/challenges/string-mingling/problem

defmodule Solution do
    def solve([first_line, second_line]) do

        first_characters = String.split(first_line, "")
        second_characters = String.split(second_line, "")

        IO.puts print_together(first_characters, second_characters)
    end

    def print_together([x], [y]), do: x <> y
    def print_together([x | first_tail], [y | second_tail]) do
        x <> y <> print_together(first_tail, second_tail)
    end
end

 lines =
    IO.read(:all)
    |> String.split("\n")

Solution.solve(lines)

# Other way:
defmodule Solution do
    def solve([first_line, second_line]) do

        first_line_chars = String.codepoints(first_line)
        second_line_chars = String.codepoints(second_line)

        print_together(first_line_chars, second_line_chars)
    end

    def print_together(tail, []), do: tail
    def print_together([], tail), do: tail
    def print_together([x | first_tail], [y | second_tail]) do
        [x, y | print_together(first_tail, second_tail)]
    end
end

# and another two ways:

defmodule Solution do
    def solve([first_line, second_line]) do

        first_line_chars = String.codepoints(first_line)
        second_line_chars = String.codepoints(second_line)

        Stream.zip(first_line_chars, second_line_chars)
        |> Stream.map(fn {left, right} -> left <> right end)
        |> Enum.join
    end
end

defmodule Solution do
    def solve(lines) do
        lines
        |> Stream.map(&(String.codepoints &1))
        |> Stream.zip
        |> Stream.map(fn {x, y} -> x <> y end)
        |> Enum.join
    end
end
