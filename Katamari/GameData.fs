namespace Katamari
    module GameData =

        type Coords = { x: int; y: int }

        type Direction =  North | South | East | West

        type Item = { 
            description:string;
            name:string;
            size:float
        }
        
        type ItemLocation = {
            item:Item;
            location:Coords
        }

        type Level = {
            dimensions: Coords
            name: string;
            number: int;
            location: Coords; // starting location
            time: int;
            goal: float;
            katamari: float;
            items: ItemLocation list;
        }

        type GameData = {
            location: Coords;
            levelName: string;
            playing: bool;
            playingLevel: bool;
            progress: int;
            level: Level option;
            katamari: Item list;
        }

        let init =
            let minusOne = -1; // huh? but it won't compile with a -1 in the record itself
            { location={ x=minusOne; y=minusOne; }; levelName=""; playing=true; playingLevel=false; progress=minusOne; level=None; katamari=[]; }