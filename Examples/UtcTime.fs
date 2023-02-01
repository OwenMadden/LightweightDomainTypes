namespace Examples

open System

type UtcTime = private Time of DateTime

module UtcTime =
    let private CheckTimeIsValid onValid onInvalid (time: DateTime) =
        if time.Kind = DateTimeKind.Utc then
           onValid time
        else
           onInvalid()
    
    let DateTime (Time time) = time
    
    let Create (time: DateTime) =
        time |> CheckTimeIsValid UtcTime.Time (fun () -> failwith "Passed non-UTC time when creating UtcTime")
        
    let TryCreate (time: DateTime) = time |> CheckTimeIsValid (fun t -> t |> UtcTime.Time |> Option.Some) (fun () -> Option.None)
    
    //This style of TryCreate is more awkward in C#
    