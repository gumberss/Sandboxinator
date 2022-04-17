let spinWords (str : string) = 
    str.Split[|' '|]
    |> Array.map (fun x -> if x.Length > 4 then System.String(Array.rev(x.ToCharArray())) else x)
    |> String.concat " "
    
System.Console.WriteLine (spinWords "lalapo top zaraaa")