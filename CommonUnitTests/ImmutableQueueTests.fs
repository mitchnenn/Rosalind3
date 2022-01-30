module ImmutableQueueTests

open System
open Converter
open Xunit
open Xunit.Abstractions
open FsUnit
open ImmutableQueue

type ``Immutable queue tests`` (output:ITestOutputHelper) =
    do new Converter(output) |> Console.SetOut
    
    [<Fact>]
    member _.``Test example usage of immutable queue`` () =
        // Arrange.
        let q = EmptyQueue
        // Act.
        let q' = q |> enqueue 5 |> enqueue 4 |> enqueue 3
        output.WriteLine $"%A{all q'}"
        // Assert.
        isEmpty q |> should equal true
        isEmpty q' |> should equal false
        all q' |> should equal [5;4;3]
        peek q' |> should equal 5
        (all q').Length |> should equal 3
        
    [<Fact>]
    member _.``Test immutable queue dequeue`` () =
        // Arrange.
        let q = EmptyQueue |> enqueue 5 |> enqueue 4 |> enqueue 3
        // Act.
        let i,q' = dequeue q
        output.WriteLine $"%i{i} %A{q'}"
        // Assert.
        i |> should equal 5
        q' |> should equal (QueueContents [4;3])
        
