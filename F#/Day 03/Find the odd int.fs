// https://www.codewars.com/kata/54da5a58ea159efa38000836/

// First Solution

let inline findOdd ( numbers: int list) = 
    numbers
    |> List.groupBy (fun x -> x)
    |> List.find (fun (k, v) -> v.Length % 2 <> 0)
    |> fst

// Using id

let inline findOdd (numbers: int list) = 
    numbers
    |> List.groupBy id
    |> List.find (fun (_, v) -> v.Length % 2 <> 0)
    |> fst
