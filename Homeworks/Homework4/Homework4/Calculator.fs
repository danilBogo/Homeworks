module Homework4.Calculator
open System
let Calculate val1 operation val2 =
    if operation = Operation.Divide && val2 = 0. then
        raise (DivideByZeroException $"can`t divide by zero!")
    let result =
        match operation with
        | Plus -> val1 + val2
        | Minus -> val1 - val2
        | Multiply -> val1 * val2
        | Divide -> (double)val1 / val2
        | Unknown -> raise (ArgumentException $"{operation}is not correct argument")
    result     