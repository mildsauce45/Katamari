namespace Katamari
    module PlayGame =
        
        open GameData
        open Printer
        open Input

        // This method is not in every version of F# so i'll just add it here
        let skip count list =
            if count <= 0 then list else
            let rec loop i lst = 
                match lst with
                | _ when i = 0 -> lst
                | _::t -> loop (i-1) t
                | [] -> invalidArg "count" "value of count is invalid"
            loop count list

        // Just like skip above, this method is not in every version of F#, so this is my shim
        let take count list =
            if count <= 0 then [] else
            let rec loop i prev lst =
                match lst with
                | _ when i = 0 -> prev
                | h::_ when lst.Length = 1 -> prev @ [h]
                | h::rest -> loop (i-1) (prev @ [h]) rest
                | _ -> invalidArg "count" "something went awry"
            loop count [] list

        let recalc_katamari (data:GameData) =
            let volume = (data.katamari |> List.map (fun i -> 4.19 * ((i.size / 2.0) ** 3.0))) @ [4.19 * (data.level.katamari / 2.0) ** 3.0] |> List.reduce (+)
            ((volume / 4.19) ** (1.0/3.0)) * 2.0

        let check_win (data:GameData) =
            let size = recalc_katamari data
            size >= data.level.goal

        let quit (data:GameData) =
            let announce_win () =
                let size = recalc_katamari data
                Printer.final_size size
                match check_win data with
                | true -> Printer.win()
                | _ -> Printer.failure()

            announce_win()
            printfn "Exiting level"
            Printer.royal_rainbow()
            { data with playingLevel=false }

        let in_bounds (place:Coords) (data:GameData) =
            place.x >= 0 && place.x < data.level.dimensions.x && place.y >= 0 && place.y < data.level.dimensions.y

        let getDirection d =
            match d with
            | "north" | "n" -> (0,-1)
            | "south" | "s" -> (0, 1)
            | "east" | "e" -> (1, 0)
            | "west" | "w" -> (-1, 0)
            | "here" | "h" -> (0, 0)
            | _ -> invalidArg "d" "other pattern match should have caught this"

        let look_at (data:GameData) (dir:int*int) =
            let x,y = dir // deconstruct the tuple into usable values
            let place = { data.location with x=data.location.x + x; y=data.location.y + y } // calculate the place to look at            

            match in_bounds place data with
            | true -> Levels.get_items_at_space place data.level |> Printer.display_items |> ignore
            | false -> printfn "To that way lies the void"

        let look (data:GameData) =
            let options = "N, S, E, W, Here, or Katamari"
            let inp = Input.request <| sprintf "Look which direction? (%s) " options

            match inp with
            | "katamari" | "k" -> Printer.desc_katamari data (recalc_katamari data)
            | "north" | "n" | "south" | "s" | "east" | "e" | "west" | "w" | "here" |"h" -> look_at data <| getDirection inp
            | _ -> sprintf "Please choose a valid option, options are %s" options |> printfn "%s"

            data

        let time (data:GameData) =
            printfn "You have %im%is left to get your katamari up to %Acm, better hurry!" (data.level.time / 60) (data.level.time % 60) data.level.goal
            data

        let tick_time (data:GameData) =
            let newData = { data with level={ data.level with time=data.level.time - 1} }

            match newData.level.time with
            | t when t = 60 -> Printer.minute_warning() |> ignore; newData
            | t when t = 0 -> Printer.times_up() |> ignore; quit newData
            | _ -> newData         

        let move (dir:int*int) (data:GameData) =
            let x,y = dir
            let newLocation = { data.location with x=data.location.x + x; y=data.location.y + y }

            match in_bounds newLocation data with
            | true -> look_at data dir |> ignore; tick_time data |> (fun d -> { d with location=newLocation; })
            | false -> printfn "Ahh but you can't move there! Sorry, that's not in bounds" |> ignore; data

        let north (data:GameData) =
            Printer.move North
            move (0,-1) data

        let east (data:GameData) =
            Printer.move East
            move (1,0) data

        let south (data:GameData) =
            Printer.move South
            move (0,1) data

        let west (data:GameData) =
            Printer.move West
            move (-1,0) data        

        let roll (data:GameData) =
            let place = data.location;
            let items = Levels.get_items_at_space place data.level

            let inp = Input.request "Roll what? "

            let targets = items |> List.filter (fun i -> i.name.ToLower() = inp)

            let roll_up (item:Item) (rest:Item list) =
                let newItems = (items |> List.filter (fun i -> i <> item)) @ rest;
                let otherItems = data.level.items |> List.filter (fun i -> i.location <> place)
                { data with katamari=data.katamari @ [item]; level={ data.level with items=otherItems @ (newItems |> List.map (fun i -> { item=i; location=place; })) } }

            let smash_katamari (data:GameData) =
                match data.katamari with
                | [] -> data
                | _ -> 
                    let rand = System.Random()
                    let idx = rand.Next(data.katamari.Length)

                    let itemToDrop = data.katamari.[idx]
                    let newItems = (data.katamari |> take idx) @ (data.katamari |> skip (idx + 1))
                    { data with katamari=newItems; level={data.level with items=data.level.items @ [{ item=itemToDrop; location=place; }]} }

            let report_status (data:GameData) =
                Printer.status <| recalc_katamari data
                data

            let try_roll (item:Item) (rest:Item list) =
                match recalc_katamari data with
                | i when i / 2.0 >= item.size -> Printer.pickup item |> ignore; roll_up item rest |> report_status
                | _ -> Printer.fail item |> ignore; smash_katamari data

            match targets with
            | [] -> printfn "I'm sorry, I don't see that item here" |> ignore; data
            | x::rest -> try_roll x rest |> tick_time

        let handleMainCommandInput input (data:GameData) =
            match input with
            | "look" | "l" | "examine" -> look data
            | "time left" | "time" | "t" -> time data
            | "north" | "n" -> north data
            | "east" | "e" -> east data
            | "south" | "s" -> south data
            | "west" | "w" -> west data
            | "roll" | "r" -> roll data
            | "quit" | "q" -> quit data
            | _ -> printfn "look, time, north, east, south, west, roll, quit" |> ignore; data

        let play (data:GameData) =

            Printer.transport data.level
            Printer.royal_rainbow ()
            Printer.welcome_level data.level

            let mutable mData = data;

            while mData.playingLevel do
                mData <- handleMainCommandInput (Input.request "> ") mData

            true


