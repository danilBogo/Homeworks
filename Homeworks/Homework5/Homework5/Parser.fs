module Homework5.Parser
open Homework5.MaybeBuilder

let parseToOperation operation =
    match operation with 
    | "+" -> Operation.Plus |> Ok
    | "-" -> Operation.Minus |> Ok
    | "*" -> Operation.Multiply |> Ok
    | "/" -> Operation.Divide |> Ok
    | _ -> Error ErrorType.InvalidOperation
let tryParseToDecimal s = 
    try 
        s |> decimal |> Ok
    with _ -> Error ErrorType.InvalidArgument

let parseArguments (args:string[]) =
     maybe
        {
         let! parsedArg1 = args.[0] |> tryParseToDecimal 
         let! parsedArg2 =  args.[2] |> tryParseToDecimal 
         return parsedArg1, parsedArg2
        }