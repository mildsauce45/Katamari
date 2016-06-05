namespace Katamari
    module MainModule =

        open System
        open Printer
        open GameData
        open Levels           

        let quit () =
            Printer.bid_adieu()
            false

        let load_level (level:Level) =
            let levelCopy = level;
            GameData.init levelCopy


        let try_level () =
            printf "Available levels are: "
            Levels.get_levels |> List.map (fun l -> l.name.Trim()) |> List.iter (printf "%s ")
            printfn ""
                        
            match Levels.get_level (Input.request "Which level would you like to play? ") with
            | Some l -> PlayGame.play <| load_level l
            | None -> printfn "I'm sorry that's not an available level" |> ignore; true

        let handleInput (input:string) =
            match input with
            | "quit" | "q" -> quit()
            | "play" | "pl" -> try_level()
            | _ -> printfn "play, quit" |> ignore; true

        [<EntryPoint>]
        let main argv = 
            Printer.welcome()

            let mutable keepPlaying = true
            
            printfn "Time to start playing, what would you like to do? Valid commands are play, quit"            

            while keepPlaying do
                keepPlaying <- handleInput (Input.request "> ")

#if DEBUG
            Console.ReadLine() |> ignore
#endif

            0 // return an integer exit code
