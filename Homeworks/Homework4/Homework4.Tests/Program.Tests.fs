module Homework4.Tests.Program_Tests
open System
open Homework4
open Xunit

[<Fact>]
let ``Program_CorrectValues_ZeroReturned``() =
    let result = Program.main [|"12";"+";"3"|]
    Assert.Equal(0,result)

