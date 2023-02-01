namespace Examples

[<Struct>]
type PositiveDouble = private PositiveDouble of float

module PositiveDouble =
    let Unwrap (PositiveDouble value) = value
    let Create value = if value > 0.0 then value |> PositiveDouble.PositiveDouble else failwith $"Passed non-positive value {value} when creating PositiveDouble"
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //More idiomatic F# to pass in function to use value
    let Apply f (PositiveDouble value) = f value