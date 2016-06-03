namespace Katamari
    module Levels =
        
        open GameData
        open Items

        let test_level = {
            dimensions={ x=6; y=6 };
            name="test_level";
            number=0;
            location={ x=3; y=3 };
            time=3600;
            goal=12.0;
            katamari=10.0;
            items=[{ item=banana; location={x=2;y=2}}
                   { item=_match; location={x=3;y=3}}
                   { item=_match; location={x=3;y=3}}
                   { item=_match; location={x=3;y=3}}
                   { item=coin; location={x=2;y=2}}
                   { item=coin; location={x=2;y=1}}
                   { item=coin; location={x=2;y=0}}
                   { item=coin; location={x=1;y=2}}
                   { item=wcrayon; location={x=3;y=4}}
                   { item=rcrayon; location={x=4;y=4}}
                   { item=rcrayon; location={x=4;y=4}}
                   { item=rcrayon; location={x=4;y=3}}
                   { item=hairpin; location={x=1;y=1}}
                   { item=hairpin; location={x=1;y=2}}
                   { item=hairpin; location={x=1;y=3}}
                   { item=pachinko; location={x=3;y=3}}
                   { item=pachinko; location={x=3;y=3}}
                   { item=pachinko; location={x=3;y=3}}
                   { item=eraser; location={x=3;y=3}}]
        }

        let starter_house = {
            dimensions={ x=6; y=6; };
            name="starter_house";
            number=1;
            location={ x=4; y=4; }
            time=120;
            goal=15.0;
            katamari=10.0;
            items=[{item=banana; location={ x=2; y=2; }}
                   {item=wcrayon; location={ x=0; y=0; }}
                   {item=bcrayon; location={ x=0; y=0; }}
                   {item=bcrayon; location={ x=0; y=1; }}
                   {item=bcrayon; location={ x=0; y=1; }}
                   {item=bcrayon; location={ x=0; y=2; }}
                   {item=eraser; location={ x=0; y=2; }}
                   {item=eraser; location={ x=0; y=3; }}
                   {item=wcrayon; location={ x=0; y=4; }}
                   {item=wcrayon; location={ x=0; y=4; }}
                   {item=hairpin; location={ x=0; y=5; }}
                   {item=hairpin; location={ x=0; y=5; }}
                   {item=bcrayon; location={ x=1; y=0; }}
                   {item=hairpin; location={ x=1; y=1; }}
                   {item=hairpin; location={ x=1; y=1; }}
                   {item=hairpin; location={ x=1; y=2; }}
                   {item=coin; location={ x=1; y=2; }}
                   {item=coin; location={ x=1; y=2; }}
                   {item=bcrayon; location={ x=1; y=3; }}
                   {item=hairpin; location={ x=1; y=3; }}
                   {item=bcrayon; location={ x=1; y=4; }}
                   {item=bcrayon; location={ x=1; y=4; }}
                   {item=bcrayon; location={ x=1; y=4; }}
                   {item=coin; location={ x=1; y=5; }}
                   {item=coin; location={ x=2; y=0; }}
                   {item=coin; location={ x=2; y=1; }}
                   {item=coin; location={ x=2; y=2; }}
                   {item=coin; location={ x=2; y=2; }}
                   {item=coin; location={ x=2; y=3; }}
                   {item=coin; location={ x=2; y=3; }}
                   {item=strawberry; location={ x=2; y=3; }}
                   {item=bcrayon; location={ x=2; y=4; }}
                   {item=mahjong; location={ x=2; y=5; }}
                   {item=mahjong; location={ x=2; y=5; }}
                   {item=mahjong; location={ x=2; y=5; }}
                   {item=_match; location={ x=3; y=0; }}
                   {item=bcrayon; location={ x=3; y=1; }}
                   {item=_match; location={ x=3; y=2; }}
                   {item=_match; location={ x=3; y=3; }}
                   {item=_match; location={ x=3; y=3; }}
                   {item=eraser; location={ x=3; y=3; }}
                   {item=pachinko; location={ x=3; y=2; }}
                   {item=pachinko; location={ x=3; y=2; }}
                   {item=pachinko; location={ x=3; y=2; }}
                   {item=pachinko; location={ x=3; y=3; }}
                   {item=pachinko; location={ x=3; y=3; }}
                   {item=pachinko; location={ x=3; y=3; }}
                   {item=wcrayon; location={ x=3; y=4; }}
                   {item=rcrayon; location={ x=3; y=4; }}
                   {item=wcrayon; location={ x=3; y=5; }}
                   {item=wcrayon; location={ x=3; y=5; }}
                   {item=rcrayon; location={ x=4; y=0; }}
                   {item=rcrayon; location={ x=4; y=0; }}
                   {item=bcrayon; location={ x=4; y=1; }}
                   {item=bcrayon; location={ x=4; y=1; }}
                   {item=bcrayon; location={ x=4; y=2; }}
                   {item=bcrayon; location={ x=4; y=2; }}
                   {item=bcrayon; location={ x=4; y=2; }}
                   {item=rcrayon; location={ x=4; y=3; }}
                   {item=rcrayon; location={ x=4; y=3; }}
                   {item=strawberry; location={ x=4; y=3; }}
                   {item=frog; location={ x=4; y=4; }}
                   {item=mahjong; location={ x=4; y=4; }}
                   {item=bcrayon; location={ x=4; y=4; }}
                   {item=frog; location={ x=4; y=4; }}
                   {item=frog; location={ x=4; y=5; }}
                   {item=rcrayon; location={ x=5; y=0; }}
                   {item=wcrayon; location={ x=5; y=0; }}
                   {item=bcrayon; location={ x=5; y=1; }}
                   {item=rcrayon; location={ x=5; y=1; }}
                   {item=bcrayon; location={ x=5; y=2; }}
                   {item=bcrayon; location={ x=5; y=2; }}
                   {item=_match; location={ x=5; y=3; }}
                   {item=_match; location={ x=5; y=3; }}
                   {item=bcrayon; location={ x=5; y=4; }}
                   {item=screw; location={ x=5; y=5; }}
                   {item=screw; location={ x=5; y=5; }}
                   {item=screw; location={ x=5; y=5; }}]
        }

        let get_levels =
            [test_level; starter_house]

        let get_level name =
            let levels = get_levels

            try           
                let idx = levels |> List.findIndex (fun l -> l.name = name)
                Some levels.[idx]
            with
                | _ -> None

        let get_items_at_space (space:Coords) (level:Level) =
            level.items |> List.filter (fun i -> i.location = space) |> List.map (fun il -> il.item)

