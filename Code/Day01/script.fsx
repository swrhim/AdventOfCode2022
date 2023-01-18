open System.IO
open System
 
let split = [| "\n\n" |]
let split2 = [| "\n" |]
let text = Path.Combine(__SOURCE_DIRECTORY__, "input.txt") |> File.ReadAllText
let elves (input : string) = 
    input.Split(split, StringSplitOptions.None) 
    |> Array.map(fun x -> 
        x.Split(split2, StringSplitOptions.None) 
        |> Array.sumBy(fun z -> int z)
    )

let getMostCalories = 
    elves text
    |> Array.max

let getTopThree =
    elves text
    |> Array.sortDescending
    |> Array.take 3
    |> Array.sum

printf "%i" getMostCalories
printf "%i" getTopThree
