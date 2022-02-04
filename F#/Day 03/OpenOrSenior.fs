//https://www.codewars.com/kata/5502c9e7b3216ec63c0001aa

let OpenOrSenior xs = 
    xs
    |> List.map (function [a;b] -> (if a > 55 && b > 7 then  "Senior" else "Open") | _ -> "None")
		
let OpenOrSenior = List.map (function
    | [age; handicap] when age >= 55 && handicap > 7 -> "Senior"
    | _ -> "Open")
		
