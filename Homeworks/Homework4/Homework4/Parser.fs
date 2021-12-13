module Homework4.Parser
open System

let parseToOperation operation =
    match operation with
    | "+" -> Operation.Plus
    | "-" -> Operation.Minus
    | "*" -> Operation.Multiply
    | "/" -> Operation.Divide
    | _ -> Operation.Unknown

let parseArguments (args:string[]) =
     let parsedArg1 = 
        try
          args.[0] |> double
        with
        | _ -> raise (ArgumentException $"{args.[0]}is not correct argument")
     let parsedArg2 =
        try
            args.[2] |> double
        with
        | _ -> raise (ArgumentException $"{args.[1]}is not correct argument")
        
     parsedArg1, parsedArg2
    