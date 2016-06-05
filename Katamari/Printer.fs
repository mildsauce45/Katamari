namespace Katamari
    open GameData

    module Printer =

        open System

        let banner () =
            printfn "______ __      _____                                _____"
            printfn "___  //_/_____ __  /______ _______ _________ __________(_)"
            printfn "__  ,<  _  __ `/  __/  __ `/_  __ `__ \  __ `/_  ___/_  /"
            printfn "_  /| | / /_/ // /_ / /_/ /_  / / / / / /_/ /_  /   _  /"
            printfn "/_/ |_| \__,_/ \__/ \__,_/ /_/ /_/ /_/\__,_/ /_/    /_/"
            printfn "________"
            printfn "___  __ \_____ _______ _________ ___________  __"
            printfn "__  / / /  __ `/_  __ `__ \  __ `/  ___/_  / / /"
            printfn "_  /_/ // /_/ /_  / / / / / /_/ // /__ _  /_/ /"
            printfn "/_____/ \__,_/ /_/ /_/ /_/\__,_/ \___/ _\__, /"
            printfn "                                       /____/"

        let royal_rainbow () =
            printfn "                          ROYAL RAINBOW"
            printfn "                         RROYAL RAINBOWW"
            printfn "                        RROOYAL RAINBOOWW"
            printfn "                       RROOYYAL RAINBBOOWW"
            printfn "                      RROOYYAAL RAINNBBOOWW"
            printfn "                     RROOYYAALL RAIINNBBOOWW"
            printfn "                    RRROOYYAALL RAAIINNBBOOWW"
            printfn "                   RRROOOYYAALL RRAAIINNBBOOWW"
            printfn "                  RRROOOYYYAALL RRAAIINNBBOOWWW"
            printfn "                 RRROOOYYYAAALL RRAAIINNBBOOOWWW"
            printfn "                RRROOOYYYAAALLL RRAAIINNBBBOOOWWW"
            printfn "               RRRROOOYYYAAALLL RRAAIINNNBBBOOOWWW"
            printfn "              RRRROOOOYYYAAALLL RRAAIIINNNBBBOOOWWW"
            printfn "             RRRROOOOYYYYAAALLL RRAAAIIINNNBBBOOOWWW"
            printfn "            RRRROOOOYYYYAAAALLL RRRAAAIIINNNBBBOOOWWW"
            printfn "           RRRROOOOYYYYAAAALLLL RRRAAAIIINNNBBBOOOWWWW"
            printfn "          RRRRROOOOYYYYAAAALLLL RRRAAAIIINNNBBBOOOOWWWW"
            printfn "         RRRRROOOOOYYYYAAAALLLL RRRAAAIIINNNBBBBOOOOWWWW"
            printfn "        RRRRROOOOOYYYYYAAAALLLL RRRAAAIIINNNNBBBBOOOOWWWW"
            printfn "       RRRRROOOOOYYYYYAAAAALLLL RRRAAAIIIINNNNBBBBOOOOWWWW"
            printfn "      RRRRROOOOOYYYYYAAAAALLLLL RRRAAAAIIIINNNNBBBBOOOOWWWW"
            printfn ""
            printfn " ___  _____   ___   _      ___    _   ___ _  _ ___  _____      __"
            printfn @"| _ \/ _ \ \ / /_\ | |    | _ \  /_\ |_ _| \| | _ )/ _ \ \    / /"
            printfn @"|   / (_) \ V / _ \| |__  |   / / _ \ | || .` | _ \ (_) \ \/\/ /"
            printfn @"|_|_\\___/ |_/_/ \_\____| |_|_\/_/ \_\___|_|\_|___/\___/ \_/\_/"

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
