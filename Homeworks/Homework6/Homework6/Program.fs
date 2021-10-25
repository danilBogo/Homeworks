module Giraffe.App
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe.Parser
open Giraffe.Calculator
open Giraffe.MaybeBuilder
open Microsoft.Extensions.Logging
open Giraffe

[<CLIMutable>]
type Values =
    {
        V1:string
        Op:string
        V2:string
    }
    
let calculateHandler:HttpHandler =
    fun next ctx ->
        let values = ctx.TryBindQueryString<Values>()
        match values with
        | Ok v ->
            let result =
                maybe{
                    let! arg1, arg2 = [|v.V1;v.Op;v.V2|] |> parseArguments
                    let! operation = v.Op |> parseToOperation
                    let! result = Calculate (arg1, operation, arg2)
                    return result
                }
            match result with
            | Ok result' ->
                (setStatusCode 200 >=> json result') next ctx
            | Error e -> (setStatusCode 400 >=> text($"{e}")) next ctx
        | Error e ->
            (setStatusCode 400 >=> text($"{e}")) next ctx            
let webApp =
    choose [
        GET >=>
            choose [
                route "/calculate" >=> calculateHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]
    
type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                        (_ : IHostEnvironment)
                        (_ : ILoggerFactory) =
        app.UseGiraffe webApp
        
[<EntryPoint>]
let main args =
    Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .UseStartup<Startup>()
                        |> ignore)
        .Build()
        .Run()
    0