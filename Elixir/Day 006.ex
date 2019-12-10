#Strings in ELixir are sequence of bytes
string = <<104,101,108,108,111>>

IO.puts string

IO.puts inspect string
IO.puts inspect string <> <<0>>


IO.puts 'hełło'
IO.puts inspect 'hełło'
#The "letter" ł is represented by bytes 197 and 130:
IO.puts inspect "hełło" <> <<0>>
# You can get the codepoint of character using '?':
IO.puts ?Z

#Graphemes e Codepoints
string2 = "\u0061\u0301"

IO.puts  string2
#Codepoints are every part of unicode characters that are represented by one or more bytes
IO.puts inspect String.codepoints string2
IO.puts inspect String.graphemes string2
