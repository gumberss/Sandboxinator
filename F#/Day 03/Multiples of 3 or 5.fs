//https://www.codewars.com/kata/514b92a657cdc65150000006

let solve n = 
    [3; 5]
    |> Seq.collect(fun k -> [k .. k .. n - 1])
    |> Seq.distinct
    |> Seq.sum
