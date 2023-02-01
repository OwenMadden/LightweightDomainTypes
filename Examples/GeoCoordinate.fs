namespace Examples

type Longitude = private Value of float
type Latitude = private Value of float
type GeoCoordinate = {Longitude:Longitude; Latitude:Latitude}

module GeoCoordinate =
    let private IsLongitudeValid value = value <= 180.0 && value >= -180.0
    let private IsLatitudeValid value = value <= 90.0 && value >= -90.0
    
    let GetLongitude (Longitude.Value longitude) = longitude
    let GetLatitude (Latitude.Value latitude) = latitude
    
    let TryCreateLongitude longitude = if IsLongitudeValid longitude then longitude |> Longitude.Value |> Option.Some else Option.None
    let TryCreateLatitude latitude = if IsLatitudeValid latitude then latitude |> Latitude.Value |> Option.Some else Option.None
    let TryCreate longitude latitude = TryCreateLongitude longitude |> Option.bind (fun lon -> TryCreateLatitude latitude |> Option.map (fun lat -> {Longitude = lon; Latitude = lat}))
    
    let DefaultLatitude = 0.0 |> Latitude.Value 
    let DefaultLongitude = 0.0 |> Longitude.Value
    let Default = {Latitude = DefaultLatitude; Longitude = DefaultLongitude}

