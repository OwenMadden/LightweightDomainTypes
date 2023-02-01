namespace Examples

type PositiveDouble = PositiveDouble of float

module PositiveDouble =
    let Unwrap (PositiveDouble value) = value
    let Create value = if value > 0.0 then value |> PositiveDouble.PositiveDouble else failwith $"Passed non-positive value {value} when creating PositiveDouble"