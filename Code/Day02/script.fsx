open System
open System.IO

let text = Path.Combine(__SOURCE_DIRECTORY__, "input.txt")
let readFile input = input |> File.ReadAllText

type Moves = 
    | Rock
    | Paper
    | Scissor

type Outcome =
    | Win
    | Lose
    | Tie

let convertInputToMove (row : string) =
    let opponent = match row.[0] with | 'A' -> Rock | 'B' -> Paper | 'C' -> Scissor | _ -> failwith "Error opponent"
    let myMove = match row.[2] with | 'X' -> Rock | 'Y' -> Paper | 'Z' -> Scissor | _ -> failwith "Error myMove"

    myMove, opponent

let convertInputToMoveAndOutcome (row : string) =
    let opponent = match row.[0] with | 'A' -> Rock | 'B' -> Paper | 'C' -> Scissor | _ -> failwith "Error opponent"
    let outcome = match row.[2] with | 'X' -> Lose | 'Y' -> Tie| 'Z' -> Win | _ -> failwith "Error myMove"

    opponent, outcome 


let gameScore (moves : Moves * Moves) =
    match moves with
    | Rock, Paper | Paper, Scissor | Scissor, Rock -> 6
    | Rock, Rock | Paper, Paper | Scissor, Scissor -> 3
    | Rock, Scissor | Paper, Rock | Scissor, Paper -> 0

let moveValue (moves : Moves) =
    match moves with
    | Rock -> 1
    | Paper -> 2
    | Scissor -> 3

let solve1 input =
    (readFile input).Split("\n", StringSplitOptions.None)
    |> Array.fold(fun state iter -> 
        let myMove, opponent = convertInputToMove iter
        gameScore (opponent, myMove) + moveValue (myMove) + state
    ) 0

solve1 text

//opponent, outcome
let determineMyMove ( moves : Moves * Outcome) =
    let myMove = 
        match moves with
        | Paper, Win | Scissor, Tie | Rock, Lose -> Scissor
        | Paper, Tie | Scissor, Lose | Rock, Win -> Paper
        | Paper, Lose | Scissor, Win | Rock, Tie -> Rock

    myMove

let solve2 input =
    (readFile input).Split("\n", StringSplitOptions.None)
    |> Array.fold(fun state iter ->
        let opponent, outcome= convertInputToMoveAndOutcome iter
        let myMove = determineMyMove (opponent, outcome)
        gameScore (opponent, myMove) + moveValue (myMove) + state
    ) 0

solve2 text