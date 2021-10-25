module Giraffe.MaybeBuilder

type MaybeBuilder() =
    member this.Bind(x, f) =
        match x with
        | Error e -> Error e
        | Ok a -> f a
    member this.Return(x) =
        Ok x
let maybe = MaybeBuilder()