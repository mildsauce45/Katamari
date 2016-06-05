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
            playingLevel: bool;
            level: Level;
            katamari: Item list;
        }

        let init (level:Level) =
            { location={ x=level.location.x; y=level.location.y }; levelName=level.name; playingLevel=true; level=level; katamari=[]; }