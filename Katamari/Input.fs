namespace Katamari
    module Input =
        
        open System

        let request (prompt:string) =
            let mutable inp = ""

            printf "%s" prompt

            inp <- Console.ReadLine()
            
            inp.ToLower()

        let invalid_command obj =
            printfn "I'm sorry thats not a valid command"
            obj
