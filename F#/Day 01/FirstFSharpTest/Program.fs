// Learn more about F# at http://fsharp.org

open System

let printNames names  = 
    
    for name in names do
        printfn $"Oi {name}"

let names = 10

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    printNames ["Jarbas"; "Zorio"]
    0 // return an integer exit code
