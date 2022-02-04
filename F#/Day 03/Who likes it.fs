// https://www.codewars.com/kata/5266876b8f4bf2da9b000362

//; $ is not acepted :(
let likes (names: string list) : string  = 
    match names with 
        | [x] -> $"{x} likes this"
        | [x; y] -> $"{x} and {y} like this"
        | [x; y; z] -> $"{x}, {y} and {z} like this"
        | x :: y :: tail -> $"{x}, {y} and {tail.Length} others like this"
        | _ -> "no one likes this"


let likes (names: string list) : string  = 
    match names with 
        | [x] -> x + " likes this"
        | [x; y] -> x + " and " + y + " like this"
        | [x; y; z] -> x + ", " + y + " and " + z + " like this"
        | x :: y :: tail -> x + ", " + y + " and " + tail.Length.ToString() + " others like this"
        | _ -> "no one likes this"
