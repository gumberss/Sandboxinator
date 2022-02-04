open System

let changeLetter (action: char -> char) (word : string) =
    match (Seq.toList word) with  
    | head :: tail -> String(List.toArray(action(head) :: tail))
    | _ -> word

let toCamelCase (text : string) =
    text.Split[|'_'; '-'|]
    |> Array.map (changeLetter Char.ToUpper)
    |> String.Concat
    |> changeLetter (fun _ -> text[0])


Console.WriteLine (toCamelCase "the-stealth-warrior")
exit 1

type Breather = {
    description : string
}

type Person = {
    descriptions: string
}

type Dog = {
    happiness: string
}

type Thing = {
    forWhat: string
}


type Something =
    | Breather of Breather
    | Thing of Thing

let what something = 
    match something with
    | Breather(s) -> $"Breather {s.description}"
    | Thing(s) -> $"Thing {s.forWhat}"

let whatF = function
    | Breather(s) -> $"Breather {s.description}"
    | Thing(s) -> $"Thing {s.forWhat}"


let b = {description = "123"} 
System.Console.WriteLine (what (Something.Breather b))
System.Console.WriteLine (what (Something.Thing {forWhat = "Make someone happy"}))