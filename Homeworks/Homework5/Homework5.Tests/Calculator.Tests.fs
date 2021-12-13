module Homework5.Tests.Calculator_Tests
open System
open Homework5.Calculator
open Homework5.ErrorType
open Xunit
open Homework5
open FailTest

let checkCorrectCalculate val1 operation val2 expected =
    let result = Calculate(val1,operation,val2)
    match result with
    | Ok result' -> Assert.Equal(expected,result')
    | Error e -> fail
    
[<Fact>]
let ``calculate_CorrectArguments_CorrectResultReturned``() =
    checkCorrectCalculate 220.m Operation.Plus 8.m 228.m 
    checkCorrectCalculate 1500.m Operation.Minus 2.m 1498.m
    checkCorrectCalculate 22.m Operation.Multiply 3.m 66.m
    checkCorrectCalculate 25.m Operation.Divide 4.m 6.25m


[<Fact>]
let ``calculate_DivideByZero_ErrorReturned``() =
    let result = Calculate (23.m, Operation.Divide, 0.m)
    match result with
    | Ok result' -> fail
    | Error e -> Assert.Equal(DivideByZero,e)