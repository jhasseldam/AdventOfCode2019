module Day2.ProgramAlarm
open System.IO
open System

// Ineffective swap, but solved using an immutable data structure
let swapValue index newValue list =
  List.mapi (fun i v -> if i = index then newValue else v) list

// As defined in the exercice
let setInitialState intCodeProgram =
  swapValue 1 12 intCodeProgram
  |> swapValue 2 2

let processOpcode opcode param1 param2 =
  match opcode with
  | 1 -> param1 + param2
  | 2 -> param1 * param2
  | i -> failwith (sprintf "Sorry did not understand opcode: %i" i)

let rec processInstructions offset intCodeProgram =
  match List.skip offset intCodeProgram with
  | 99::_ -> List.head intCodeProgram
  | opcode::param1Pos::param2Pos::writePos::_ ->
     let param1 = List.item param1Pos intCodeProgram
     let param2 = List.item param2Pos intCodeProgram
     let result = processOpcode opcode param1 param2
     let intCodeProgram' = swapValue writePos result intCodeProgram
     processInstructions (offset + 4) intCodeProgram'
  | _ -> failwith "Unexpected instruction"

let runIntProgram () =
  File.ReadAllText "Day2/Day2PuzzleInput.txt"
  |> fun s -> s.Split ","
  |> List.ofArray
  |> List.map Int32.Parse
  |> setInitialState
  |> processInstructions 0