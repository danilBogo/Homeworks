module Homework5.Tests.Program_Test

open Homework5
open Xunit

[<Fact>]
let ``program_CorrectValues_ZeroReturned``() =
    let result = Program.main [|"12";"+";"3"|]
    Assert.Equal(0,result)
    
let args =
    [|
        [|"x";"-";"2"|]
        [|"10";"+";"z"|]
        [|"x";"+";"z"|]
        [|"11";"x";"123"|]
        [|"12";"/";"0"|]
    |]
    
[<Fact>]
let ``program_InvalidArguments_Error1Returned``() =
    args |> Array.iter(fun arg-> Assert.Equal(Program.main arg,1))
