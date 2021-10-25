module Giraffe.Calculator

let Calculate (val1: decimal, operation, val2: decimal) =
    match operation with
    | Divide ->
        match val2 with
        | 0m -> Error ErrorType.DivideByZero
        | _ ->  val1 / val2 |> Ok 
    | Plus -> val1 + val2 |> Ok
    | Minus -> val1 - val2 |> Ok
    | Multiply -> val1 * val2 |> Ok