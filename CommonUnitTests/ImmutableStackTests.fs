module Tests

open System
open Converter
open Xunit
open Xunit.Abstractions
open FsUnit

type ``Shortest super string tests`` (output:ITestOutputHelper) =
    do new Converter(output) |> Console.SetOut

    [<Fact>]
    member _.``Test example usage of the stack`` () =
        // Arrange.
        let s = ImmutableStack.Empty
        // Act.
        let s' = s.Push 5
        let s'' = s'.Push 4
        let s''' = s''.Push 3
        output.WriteLine $"%A{s'''.All()}"
        // Arrange.
        s'''.All().Length |> should equal 3
        s'''.Top() |> should equal s''
        s'''.Pop() |> should equal 3
    
    [<Fact>]
    member _.``Test Push`` () =
        // Arrange.
        let s = ImmutableStack.Empty
        let value = 5
        // Act.
        let s' = s.Push value
        output.WriteLine $"%A{s'.All()}"
        // Assert.
        s'.IEmpty |> should equal false
        s'.Pop() |> should equal value
        
