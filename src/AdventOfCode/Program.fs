open System
open Day1

[<EntryPoint>]
let main argv =
  FuelCounter.calculateFuelOfFuel 1969 |> printfn "%i"
  FuelCounter.runFuelCalculation () |> printfn "%i"
  0