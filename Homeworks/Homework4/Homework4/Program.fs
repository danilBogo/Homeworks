namespace Homework4

open Homework4.Calculator

module Program =     
    [<EntryPoint>]
    let main argv =
        let arg1, arg2 = Parser.parseArguments argv 
        let operation = Parser.parseToOperation argv.[1]
        let result = Calculate arg1 operation arg2
        printfn $"{result}"
        0 