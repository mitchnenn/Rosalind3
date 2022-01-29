module ImmutableStack

type ImmutableStack<'T> = StackContents of 'T list

let EmptyStack = StackContents []

let push<'T> (x:'T) (stack:ImmutableStack<'T>) : ImmutableStack<'T> =
    let (StackContents contents) = stack
    let newContents = x::contents
    StackContents newContents
    
let pop<'T> (stack:ImmutableStack<'T>) : 'T * ImmutableStack<'T> =
    let (StackContents contents) = stack
    match contents with
    | [] ->
        failwith "Stack underflow"
    | top::rest ->
        let newStack = StackContents rest
        (top,newStack)

let all<'T> (stack:ImmutableStack<'T>) : 'T list =
    let (StackContents contents) = stack
    let rec loop rest acc =
        match rest with
        | [] -> acc
        | top::rest -> loop rest (top::acc)
    loop contents []
    
let top<'T> (stack:ImmutableStack<'T>) : 'T =
    let (StackContents contents) = stack
    match contents with
    | [] -> failwith "Stack is empty"
    | top::_ -> top

let isEmpty<'T> (stack:ImmutableStack<'T>) : bool =
    let (StackContents contents) = stack
    match contents with
    | [] -> true
    | _ -> false
