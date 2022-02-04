module Starter

open System
open Learning



type Friend = {
    name : string
    likeFSharp: bool
}
let friendNames = ["seminino"; "Renanzinho"; "Pirinho"]

let mutable myFriends = 
    List.map (fun x -> {name = x;  likeFSharp = false}) friendNames

let findOtherFriends (peoples : Friend list) =
    myFriends <- (List.filter (fun x -> x.likeFSharp) peoples)
    
//(findOtherFriends )


type String50 = String50 of string

let createString50 (s : string) = 
    if s.Length <= 50
    then Some (String50 s)
    else None

let aww = createString50 "123"
let kkkkk = [
    1
    2
]

let hj = 
    kkkkk
    |> List.map (fun a -> a + a) 
    |> List.sum

Console.WriteLine hj


let likes (names: string list) : string  = 
    match names with 
        | [x] -> $"{x} likes this"
        | [x; y] -> $"{x} and {y} like this"
        | [x; y; z] -> $"{x}, {y} and {z} like this"
        | x :: y :: tail -> $"{x}, {y} and {tail.Length} others like this"
        | _ -> "no one likes this"

Console.WriteLine (likes ["Alex"; "Jacob"; "Mark"; "Max"])

let getMiddle (str : string) =
    match str.Length with
        | l when l % 2 = 0 -> str.Substring(l / 2 - 1, 2)
        | l -> str.Substring(l/2, 1)

Console.WriteLine (getMiddle "lalapo")
Console.WriteLine (getMiddle "lalpo")

type Order = {
    Name : string;
    Cost: decimal
}

let orders = [
    {Name = "Food"; Cost = 10.09M}
    {Name = "Drink"; Cost= 2.34M}
]


let sum = List.sumBy (fun item -> item.Cost) orders
Console.WriteLine $"{sum}" 

Console.WriteLine $"{Sum2 sum}" 

exit 1

let input =  [[18; 20]; [45; 2]; [61; 12]; [37; 6]; [21; 21]; [78; 9]]


let OpenOrSenior xs = 
    xs
    |> List.map (function [a;b] -> (if a > 55 && b > 7 then  "Senior" else "Open") | _ -> "a")
    |> String.concat " "

let a xs =
    List.map (function
                | [a;b] when a > 55 && b > 7 -> "Senior"
                | _ -> "Open") xs

System.Console.WriteLine  (OpenOrSenior input)


// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"


let jarba = "jarba"
//jarba <- "not allowed"
let mutable lala = "100"
lala <- "123"

let snum = "100"
let num = int snum
let num2 = System.Int32.Parse snum


let sn = System.Console.ReadLine()

let n = int sn

if n >= 10 
    then System.Console.WriteLine "maior ou igual a 10"
    else System.Console.WriteLine "menos que 10"


let resp = 
    if n > 10  then "maior que 10" 
    elif n < 10 then "menos que 10" 
    else "é 10"
System.Console.WriteLine resp

let list = [0 .. n]

for i in list do
    printf "%d," i

printfn ""

for i = 0 to n do
    System.Console.Write $"{i},"

System.Console.WriteLine()

for i = n downto 0 do
    printf $"{i},"

let add a b = 
    printfn $"add: {a} - {b} "
    a + b;

let addAndMultiply a b c =
    (add a b) * c

let k = addAndMultiply 2
let k2 = k 2
let k3 = k2 5
printfn $"k3: {k3}"

let multiply a b = 
    printfn $"multiply: {a} - {b}"
    a * b

let compAddMult a b c = 
    a
    |> add b 
    |> multiply c

System.Console.WriteLine $"Que {compAddMult 1 2 3}"

let krr = List.sum list



// lists

let cards = ["Sce"; "King"; "Queen"]

let addedItem = "new" :: cards

let almostApend = ["lala"; "po"] @ ["other"; "List"]

let fullList = 
    ["first"]  
    |> List.append ["second"]
    |> List.append ["Third"] 


let byIndex = fullList.Item 2 // Third

let drawCard (tuple: int list * int list) = 
    let deck = fst tuple
    let draw = snd tuple
    let firstCard = deck.Head
    let hand = 
        draw
        |> List.append [firstCard]

    (deck.Tail, hand)

