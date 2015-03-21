open System
open Nancy
open Nancy.Hosting.Self

module HelloFsNancy =
 
    type HelloModule() as self = 
        inherit NancyModule()
        do
            self.Get.["/"] <- fun _ -> "Hello" :> obj
 
    [<EntryPoint>]
    let main args = 
        let uris = 
            [|"http://localhost:8888/nancy/"; "http://127.0.0.1:8888/nancy/"|] 
            |> Array.map (fun (s:string) -> new Uri(s))

        let nancyHost = new NancyHost(uris)
        nancyHost.Start()
        printfn "ready..."
        Console.ReadKey() |> ignore
        nancyHost.Stop()
        0