namespace Katamari
    module MainModule =

        open System
        open Printer
        open GameData
        open Levels           

        let quit data =
            Printer.bid_adieu()
            { data with playing=false }

        let progress data =
            Printer.progress data
            data

        let invalid_level (data:GameData) =
            printfn "I'm sorry that's not an available level"
            data

        let load_level (data:GameData) (level:Level) =
            let levelCopy = { level with name="copy" }
            { data with playingLevel=true; levelName=level.name; level=Some levelCopy; location=levelCopy.location; progress=level.number }

        let try_level data =
            printf "Available levels are: "
            Levels.get_levels |> List.map (fun l -> l.name.Trim()) |> List.iter (printf "%s")
            printfn ""
                        
            match Levels.get_level (Input.request "Which level would you like to play? ") with
            | Some l -> PlayGame.play <| load_level data l
            | None -> printfn "I'm sorry that's not an available level" |> ignore; data

        let handleInput (input:string) (data:GameData) =
            match input with
            | "quit" | "q" -> quit data
            | "progress" | "pr" -> progress data
            | "play" | "pl" -> try_level data
            | _ -> printfn "play, progress, save, quit" |> ignore; data

        [<EntryPoint>]
        let main argv = 
            Printer.welcome()

            // This should be the only mutable value ever (outside of getting input from the command line)
            let mutable data = GameData.init            
            
            printfn "Time to start playing, what would you like to do? Valid commands are play, progress, save, quit"            

            while data.playing do
                let inp = Input.request "> "

                data <- handleInput inp data
#if DEBUG
            Console.ReadLine() |> ignore
#endif

            0 // return an integer exit code
