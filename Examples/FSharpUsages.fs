module Examples.FSharpUsages

let DivisionExample dividend (PositiveDouble divisor) = dividend / divisor



type AThingThatHappened =
    {
        When : UtcTime
        Where : GeoCoordinate
        What : string
    }