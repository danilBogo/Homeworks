module Homework5.Tests.Parser_Tests
open System
open Homework5
open Homework5.ErrorType
open Xunit
open FailTest

 
let checkCorrectArgsParse (args:string[], expectedRes1:decimal, expectedRes2:decimal) =
    let result = Parser.parseArguments args
    match result with
    | Ok result' -> Assert.Equal((expectedRes1 |> decimal,expectedRes2 |> decimal),result')
    | Error e -> fail

let checkInvalidParse (args:string[]) =
    let result = Parser.parseArguments args
    match result with
    | Ok result' -> fail
    | Error e -> Assert.Equal(InvalidArgument,e) 

let checkCorrectOperationParse operation expected =
    let result = Parser.parseToOperation operation
    match result with
    | Ok o -> Assert.Equal(expected,o)
    | Error e -> fail
    
[<Fact>]
let ``parseArguments_CorrectValues``() =
    checkCorrectArgsParse ([|"213";"+";"123"|],213.m,123.m)
    
[<Fact>]
let ``parseArguments_IvalidOperation_CorrectParse``() =
    checkCorrectArgsParse ([|"22";"x";"22"|],22.m,22.m)
    
[<Fact>]
let ``parseArguments_InvalidArgument1``() =
    checkInvalidParse([|"x";"+";"12"|])
    
[<Fact>]
let ``parseArguments_InvalidArgument2``() =
    checkInvalidParse([|"23";"+";"z"|])

[<Fact>]
let ``parseArguments_InvalidArgumentBoth``() =
    checkInvalidParse([|"23";"+";"z"|])

[<Fact>]
let ``parseToOperation_CorrectOperation``() =
    checkCorrectOperationParse "+" Operation.Plus
    checkCorrectOperationParse "-" Operation.Minus
    checkCorrectOperationParse "*" Operation.Multiply
    checkCorrectOperationParse "/" Operation.Divide
 
[<Fact>]
let ``parseToOperation_InvalidOperation``() =
    let result = Parser.parseToOperation "x"
    match result with
    | Ok o -> fail
    | Error e -> Assert.Equal(InvalidOperation,e)
    