open System
open System.IO

let text = Path.Combine(__SOURCE_DIRECTORY__, "input.txt")
let readFile input = input |> File.ReadAllText

let calculate (c : char) =
    let num = (int)(c-'a')
    if num > 26 then
        (int)((char) (c.ToString().ToLower()) - 'a') + 27
    else num + 1

let solve1 input =
    let text = readFile input
    text.Split('\n', StringSplitOptions.None)
    |> Array.map(fun line ->
        let half = line.Length / 2
        let left,right = line.ToCharArray() |> Array.splitAt half
        let a = left |> Set.ofArray
        let b = right |> Set.ofArray
        let result = a |> Set.intersect b 
        let c = result |> Set.toArray |> Array.head
        calculate c    
    )
    |> Array.sum

solve1 text

let getCommon (arr : char [][]) =
    arr
    |> Array.map(fun line ->
        line |> Set.ofArray
    )
    |> Set.ofArray
    |> Set.intersectMany

let solve2 input =
    let text = readFile input
    let arr = text.Split('\n', StringSplitOptions.None)
    arr
    |> Array.chunkBySize 6
    |> Array.map(fun chunk ->
        
        let left, right = chunk|> Array.splitAt 2
        left
        (*
        let leftC = left |> Array.map(fun l -> l.ToCharArray())
        let rightC = right |> Array.map(fun l -> l.ToCharArray())
        let leftSet = getCommon leftC
        let rightSet = getCommon rightC
        (calculate (leftSet |> Set.toArray |> Array.head)) + (calculate (rightSet |> Set.toArray |> Array.head))
        *)
    )
    

solve2 text