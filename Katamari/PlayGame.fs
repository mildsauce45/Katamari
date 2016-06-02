namespace Katamari
    module PlayGame =
        
        open GameData
        open Printer
        open Input

        let in_bounds (place:Coords) (data:GameData) =
            place.x >= 0 && place.x < data.level.Value.dimensions.x && place.y >= 0 && place.y < data.level.Value.dimensions.y

        let getDirection d =
            match d with
            | "north" | "n" -> (0,-1)
            | "south" | "s" -> (0, 1)
            | "east" | "e" -> (1, 0)
            | "west" | "w" -> (-1, 0)
            | "here" | "h" -> (0, 0)
            | _ -> Input.invalid_command (0, 0)

        let look_at (data:GameData) (dir:int*int) =
            let x,y = dir // deconstruct the tuple into usable values
            let place = { data.location with x=data.location.x + x; y=data.location.y + y } // calculate the place to look at            

            match in_bounds place data with
            | true -> Levels.get_items_at_space place data.level.Value |> Printer.display_items |> ignore
            | false -> printfn "To that way lies the void"

        let look (data:GameData) =
            look_at data (getDirection <| Input.request "Look which direction? (N, S, E, W, Here) ")

            data

        let time (data:GameData) =
            printfn "You have %im%is left to get your katamari up to %Acm, better hurry!" (data.level.Value.time / 60) (data.level.Value.time % 60) data.level.Value.goal
            data

        let tick_time (data:GameData) =
            { data with level=Some { data.level.Value with time=data.level.Value.time - 1} }

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

        let recalc_katamari (data:GameData) =
            let volume = (data.katamari |> List.map (fun i -> 4.19 * (i.size / 2.0) ** 3.0)) @ [(4.1887 * data.level.Value.katamari) ** 3.0] |> List.reduce (+)
            ((volume / 4.1887) ** (1.0/3.0)) * 2.0

        let roll (data:GameData) =
            let place = data.location;
            let items = Levels.get_items_at_space place data.level.Value

            let inp = Input.request "Roll what? "

            let targets = items |> List.filter (fun i -> i.name.ToLower() = inp)

            let roll_up (item:Item) (rest:Item list) =
                let newItems = (items |> List.filter (fun i -> i <> item)) @ rest;
                let otherItems = data.level.Value.items |> List.filter (fun i -> i.location <> place)
                { data with katamari=data.katamari @ [item]; level=Some({ data.level.Value with items=otherItems @ (newItems |> List.map (fun i -> { item=i; location=place; })) }) }

            let smash_katamari (data:GameData) =
                match data.katamari with
                | [] -> data
                | _ -> 
                    let rand = System.Random()
                    let idx = rand.Next(data.katamari.Length)

                    let itemToDrop = data.katamari.[idx]
                    let newItems = (data.katamari |> List.take idx) @ (data.katamari |> List.skip (idx + 1))
                    { data with katamari=newItems; level=Some({data.level.Value with items=data.level.Value.items @ [{ item=itemToDrop; location=place; }]}) }

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
            | _ -> Input.invalid_command data

        let play (data:GameData) =

            Printer.transport data.level.Value
            Printer.royal_rainbow ()
            Printer.welcome_level data.level.Value

            let mutable mData = data;

            while mData.playingLevel do
                mData <- handleMainCommandInput (Input.request "> ") mData

            mData


