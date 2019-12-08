IO.puts String.length "Hello"

IO.puts String.replace("batman", "man", "car")

IO.puts inspect String.split("Hello batman")

# Check anagrams
# isAnagram "super" "perus" == true

defmodule Anagram do
    def anagrams?(a,b) when is_binary(a) and is_binary(b) do
      sort_string(a) == sort_string(b)
    end

    def sort_string(string) do
        string
        |> String.downcase()
        |> String.graphemes()
        |> Enum.sort()
    end
end

IO.puts Anagram.anagrams?("super", "perus")
IO.puts Anagram.anagrams?("Batman", "iron man")
IO.puts Anagram.anagrams?("Maria", "imara")
