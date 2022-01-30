module ImmutableQueue

type ImmutableQueue<'T> = QueueContents of 'T list

let EmptyQueue = QueueContents []

let enqueue<'T> (x:'T) (queue:ImmutableQueue<'T>) : ImmutableQueue<'T> =
    let (QueueContents contents) = queue
    let newContents = contents@[x]
    QueueContents newContents

let peek<'T> (queue:ImmutableQueue<'T>) : 'T =
    let (QueueContents contents) = queue
    match contents with
    | [] -> failwith "Queue is empty on peek"
    | _ -> contents |> List.head

let dequeue<'T> (queue:ImmutableQueue<'T>) : 'T * ImmutableQueue<'T> =
    let (QueueContents contents) = queue
    match contents with
    | [] -> failwith "Queue is empty on dequeue"
    | first::rest -> (first,QueueContents rest)

let isEmpty<'T> (queue:ImmutableQueue<'T>) : bool =
    let (QueueContents contents) = queue
    match contents with
    | [] -> true
    | _ -> false

let all<'T> (queue:ImmutableQueue<'T>) : 'T list =
    let (QueueContents contents) = queue
    let rec loop rest acc =
        match rest with
        | [] -> acc
        | first::rest -> loop rest (acc@[first])
    loop contents []

