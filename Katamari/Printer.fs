namespace Katamari
    open GameData

    module Printer =

        open System

        let banner () =
            Console.ForegroundColor <- ConsoleColor.Red
            printfn "______ __      _____                                _____"
            printfn "___  //_/_____ __  /______ _______ _________ __________(_)"
            Console.ForegroundColor <- ConsoleColor.Yellow
            printfn "__  ,<  _  __ `/  __/  __ `/_  __ `__ \  __ `/_  ___/_  /"
            printfn "_  /| | / /_/ // /_ / /_/ /_  / / / / / /_/ /_  /   _  /"
            Console.ForegroundColor <- ConsoleColor.Green
            printfn "/_/ |_| \__,_/ \__/ \__,_/ /_/ /_/ /_/\__,_/ /_/    /_/"
            printfn "________"
            Console.ForegroundColor <- ConsoleColor.Blue
            printfn "___  __ \_____ _______ _________ ___________  __"
            printfn "__  / / /  __ `/_  __ `__ \  __ `/  ___/_  / / /"
            Console.ForegroundColor <- ConsoleColor.White
            printfn "_  /_/ // /_/ /_  / / / / / /_/ // /__ _  /_/ /"
            printfn "/_____/ \__,_/ /_/ /_/ /_/\__,_/ \___/ _\__, /"
            printfn "                                       /____/"

        let royal_rainbow () =
            let handleChar char =
                match char with
                | 'r' -> Console.ForegroundColor <- ConsoleColor.Red
                | 'y' -> Console.ForegroundColor <- ConsoleColor.Yellow
                | 'g' -> Console.ForegroundColor <- ConsoleColor.Green
                | 'b' -> Console.ForegroundColor <- ConsoleColor.Blue
                | 'w' -> Console.ForegroundColor <- ConsoleColor.White
                | _ -> printf "%c" char

            let handleLine line =
                line |> Seq.iter handleChar; printfn ""

            "                          yRgOYAL RAINbBOW" |> handleLine
            "                         yRRgOYAL RAINbBOWW" |> handleLine
            "                        yRROgOYAL RAINbBOOWW" |> handleLine
            "                       yRROOgYYAL RAINbBBOOWW" |> handleLine
            "                      yRROOYgYAAL RAINbNBBOOWW" |> handleLine
            "                     yRROOYYgAALL RAIIbNNBBOOWW" |> handleLine
            "                    yRRROOYYgAALL RAAIbINNBBOOWW" |> handleLine
            "                   yRRROOOYYgAALL RRAAbIINNBBOOWW" |> handleLine
            "                  yRRROOOYYYgAALL RRAAbIINNBBOOWWW" |> handleLine
            "                 rRyRROOOYYYAgAALL RRAAbIINNBBOOOWWwW" |> handleLine
            "                rRRyROOOYYYAAgALLL RRAAbIINNBBBOOOWwWW" |> handleLine
            "               rRRRyROOOYYYAAgALLL RRAAbIINNNBBBOOOwWWW" |> handleLine
            "              rRRRRyOOOOYYYAAgALLL RRAAbIIINNNBBBOOwOWWW" |> handleLine
            "             rRRRROyOOOYYYYAAgALLL RRAAbAIIINNNBBBOwOOWWW" |> handleLine
            "            rRRRROOyOOYYYYAAAgALLL RRRAbAAIIINNNBBBwOOOWWW" |> handleLine
            "           rRRRROOOyOYYYYAAAAgLLLL RRRAbAAIIINNNBBBwOOOWWWW" |> handleLine
            "          rRRRRROOOyOYYYYAAAAgLLLL RRRAbAAIIINNNBBBwOOOOWWWW" |> handleLine
            "         rRRRRROOOOyOYYYYAAAAgLLLL RRRAbAAIIINNNBBBwBOOOOWWWW" |> handleLine
            "        rRRRRROOOOOyYYYYYAAAAgLLLL RRRAbAAIIINNNNBBwBBOOOOWWWW" |> handleLine
            "       rRRRRROOOOOYyYYYYAAAAAgLLLL RRRAbAAIIIINNNNBwBBBOOOOWWWW" |> handleLine
            "      rRRRRROOOOOYYyYYYAAAAALgLLLL RRRAbAAAIIIINNNNwBBBBOOOOWWWW" |> handleLine
            printfn ""
            "r ___  _____   ___y   _      g___    _   b___ _  _ w___  _____      __" |> handleLine
            @"r| _ \/ _ \ \ / /y_\ | |    g| _ \  /_\ b|_ _| \| |w _ )/ _ \ \    / /" |> handleLine
            @"r|   / (_) \ V /y _ \| |__  g|   / / _ \ b| || .` |w _ \ (_) \ \/\/ /" |> handleLine
            @"r|_|_\\___/ |_/y_/ \_\____| g|_|_\/_/ \_\b___|_|\_|w___/\___/ \_/\_/" |> handleLine

        let welcome () =
            banner()
            printfn ""
            printfn "Na na nanana na na Katamari Damacy!"

        let welcome_level (level:Level) =
            printfn "Welcome to %s! You have %i minutes to get your katamari from %Acm to %Acm, better hurry!" level.name (level.time/60) level.katamari level.goal

        let move dir =
            printf "You push hard and roll your katamari "

            match dir with
            | North -> printfn "north"
            | South -> printfn "south"
            | East -> printfn "east"
            | West -> printfn "west"

        let bid_adieu () =
            printfn "Sorry to see you go, play again soon!"

        let minute_warning () =
            printfn "Only one minute left! Better hurry!"

        let times_up () =
            printfn "That's all the time you have, time to see how you did"

        let win () =
            printfn "My what a beautiful katamari! I am very pleased with you"

        let failure () =
            printfn "NOT BIG ENOUGH! I AM VERY DISAPPOINTED"

        let fail (item:Item) =
            printfn "You slam your katamari into the %s and bounce right back off losing some items! Oh no!" item.name

        let pickup (item:Item) =
            printfn "Nice! You now have a %s stuck to your katamari!" item.name

        let transport (level:Level) =
            printfn "Transporting you to %s" level.name

        let status size =
            printfn "Your katamari is %Acm" size

        let final_size size =
            printfn "Your final katamari size is %Acm" size

        let display_items (items:Item list) =
            match items with
            | [] -> printfn "There is nothing there."
            | _ -> printfn "There are %i items" items.Length

            items |> List.map (fun i -> i.name) |> List.iter (printfn "You see a %s")

        let desc_katamari (data:GameData) size =
            printfn "What a beautiful katamari!"
            printfn "Your katamari is %Acm" size

            match data.katamari with
            | [] -> printfn "You katamari is totally empty! It's a blank slate!"
            | _ -> printfn "Your katamari is made up of %s" (System.String.Join(", ", data.katamari |> List.map (fun i -> i.name )))

            match size with
            | s when s > data.level.goal -> printf ""
            | _ -> printfn "Move with N, S, E, W, and use Roll Up to add items to your Katamari"
