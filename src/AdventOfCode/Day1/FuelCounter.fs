module Day1.FuelCounter
open System.IO
open System

let private calculateFuel mass = mass / 3 - 2

let calculateFuelOfFuel moduleMass =
  let rec calculateExtraFuel (mass : int) (totalFuel : int list) =
      match calculateFuel mass with
      | extraFuel when extraFuel > 0 -> calculateExtraFuel extraFuel (extraFuel::totalFuel)
      | _ -> totalFuel
  calculateExtraFuel moduleMass []
  |> List.sum

let private calulateTotalFuelConsumption modules =
  List.sumBy calculateFuelOfFuel modules

let runFuelCalculation () =
  File.ReadAllLines "Day1/Day1PuzzleInput.txt"
  |> List.ofArray
  |> List.map Int32.Parse
  |> calulateTotalFuelConsumption