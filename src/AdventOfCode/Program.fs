open System
open Day1
open Day2

[<EntryPoint>]
let main argv =
  //FuelCounter.runFuelCalculation () |> printfn "%i"
  ProgramAlarm.runIntProgram() |> printfn "%i"
  0