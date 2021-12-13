module Homework4.Tests.CalculatorTests
open System
open Homework4.Calculator
open Xunit
open Homework4

[<Fact>]
let ``Calculate_220Plus8_228Returned`` () =
     Assert.Equal(Calculate 220. Operation.Plus 8., 228.)
[<Fact>]
let ``Calculate_1401Minus64_1337Returned``() =
     Assert.Equal(Calculate 1401. Operation.Minus 64., 1337.)
[<Fact>]
let ``Calculate_4Multiply372_1488Returned``() =
     Assert.Equal(Calculate 4. Operation.Multiply 372. , 1488.)
[<Fact>]
let ``Calculate_359Divide4_89dot75Returned``() =
     Assert.Equal(Calculate 359. Operation.Divide 4., 89.75)
     
[<Fact>]
let ``Calculate_UnknownOperation_ThrowException``() =
     let res() = printf $"%f{Calculate 2. Operation.Unknown 1.}"
     Assert.Throws<ArgumentException>(Action res)
    
[<Fact>]
let ``Calculate_DivideByZero_ThrowException``() =
     let res() = printf $"%f{Calculate 121. Operation.Divide 0.}"
     Assert.Throws<DivideByZeroException>(Action res)
     
     
