// https://www.codewars.com/kata/56747fd5cb988479af000028
let getMiddle (str : string) =
    match str.Length with
        | l when l % 2 = 0 -> str.Substring(l / 2 - 1, 2)
        | l -> str.Substring(l/2, 1)
