namespace Katamari
    module Input =
        
        open System

        let request (prompt:string) =
            let mutable inp = ""

            printf "%s" prompt

            inp <- Console.ReadLine()
            
            inp.ToLower()        
