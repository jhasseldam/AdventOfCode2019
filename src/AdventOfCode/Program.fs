open System
open Day1

[<EntryPoint>]
let main argv =
  FuelCounter.runFuelCalculation () |> printfn "%i"
  0