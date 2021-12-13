module Homework4.Tests.Parser_Tests
open System
open Homework4
open Xunit

[<Fact>]
let ``ParseArguments_CorrectValues``() =
    Assert.Equal((12.,11.),Parser.parseArguments [|"12";"*";"11"|])
    Assert.Equal((213.,1234.),Parser.parseArguments [|"213";"x";"1234"|])
    
[<Fact>]
let ``ParseArguments_InvalidArgument1``() =
    let res() =
        let arg1 = Parser.parseArguments[|"x";"*";"11"|]
        printfn $"{arg1}"
    Assert.Throws<ArgumentException>(Action res)
    
[<Fact>]
let ``ParseArguments_InvalidArgument2``() =
    let res() =
        let arg1,arg2 = Parser.parseArguments[|"123";"*";"z"|]
        printfn $"{arg1}{arg2}"
    Assert.Throws<ArgumentException>(Action res)
    
[<Fact>]
let ``ParseToOperation_CorrectOperations``() =
    Assert.Equal(Operation.Plus,Parser.parseToOperation "+")
    Assert.Equal(Operation.Minus,Parser.parseToOperation "-")
    Assert.Equal(Operation.Multiply,Parser.parseToOperation "*")
    Assert.Equal(Operation.Divide,Parser.parseToOperation "/")
    
[<Fact>]
let ``ParseToOperation_UnknownOperation``() =
    Assert.Equal(Operation.Unknown,Parser.parseToOperation "x")

