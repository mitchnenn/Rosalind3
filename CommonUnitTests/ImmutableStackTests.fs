module ImmutableStackTests

open System
open Converter
open Xunit
open Xunit.Abstractions
open FsUnit
open ImmutableStack

type ``Immutable stack tests`` (output:ITestOutputHelper) =
    do new Converter(output) |> Console.SetOut

    [<Fact>]
    member _.``Test example usage of the stack`` () =
        // Arrange.
        let s = EmptyStack
        // Act.
        let s' = s |> push 5 |> push 4 |> push 3
        output.WriteLine $"%A{all s'}"
        // Arrange.
        (all s').Length |> should equal 3
        top s' |> should equal 3
        let v,newStack = pop s'
        v |> should equal 3
        top newStack |> should equal 4
        (all newStack).Length |> should equal 2
    
    [<Fact>]
    member _.``Test Push`` () =
        // Arrange.
        let s = EmptyStack
        let value = 5
        // Act.
        let s' = push value s
        output.WriteLine $"%A{all s'}"
        // Assert.
        (all s').Length |> should equal 1
        isEmpty s' |> should equal false
        top s' |> should equal 5
        let v,newStack = pop s'
        v |> should equal value
        (all s').Length |> should equal 1
        (all newStack).Length |> should equal 0
        
