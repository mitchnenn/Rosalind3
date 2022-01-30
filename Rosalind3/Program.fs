open Rosalind3
open ParseFasta

open System.IO

let dataDir = Path.Combine(__SOURCE_DIRECTORY__, "data")

let exampleFasta = parseFastaEntries (Path.Combine(dataDir, "PerfectMatchRnaSecStructure-Example.txt"))
printfn "%A" exampleFasta

