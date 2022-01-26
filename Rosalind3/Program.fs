open Rosalind3
open parse_fasta

open System.IO

let dataDir = Path.Combine(__SOURCE_DIRECTORY__, "data")

printfn "%A" (parseFastaEntries (Path.Combine(dataDir, "PerfectMatchRnaSecStructure-Example.txt")))

