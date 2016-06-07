namespace Katamari
    module Input =
        
        open System

        let request (prompt:string) =
            printf "%s" prompt

            Console.ReadLine() |> fun s -> s.ToLower().Trim()