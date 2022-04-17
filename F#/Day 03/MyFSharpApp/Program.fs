open System


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