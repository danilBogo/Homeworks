module Giraffe.Parser
open Giraffe.MaybeBuilder

let parseToOperation operation =
    match operation with 
    | "plus" -> Operation.Plus |> Ok
    | "minus" -> Operation.Minus |> Ok
    | "multiply" -> Operation.Multiply |> Ok
    | "divide" -> Operation.Divide |> Ok
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
