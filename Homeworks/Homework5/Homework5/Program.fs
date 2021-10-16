module Homework5.Program

open System
open Homework5.Calculator
open Homework5.MaybeBuilder
open Homework5.Parser
    
[<EntryPoint>]
let main argv =
    let result = 
        maybe{
            let! arg1, arg2 = argv |> parseArguments
            let! operation = argv.[1] |> parseToOperation
            let! result = Calculate (arg1, operation, arg2)
            return result
        }
    match result with
    | Ok result' ->
        let expression = String.Join(" ",argv)
        printfn $"{expression} = {result'}"
        0
    | Error e ->
         printfn $"Error:  {e}"
         1