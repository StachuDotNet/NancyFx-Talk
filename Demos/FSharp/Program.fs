
module HelloFsNancy =
 
  open System
  open Nancy
  open Nancy.Hosting.Self
 
  type HelloModule() as self = 
    inherit NancyModule()
    do
      self.Get.["/"] <- 
        fun _ -> "Hello" :> obj
 
  [<EntryPoint>]
  let main args = 
    let nancyHost = new NancyHost(new Uri("http://localhost:8888/nancy/"), new Uri("http://127.0.0.1:8888/nancy/"))
    nancyHost.Start()
    printfn "ready..."
    Console.ReadKey() |> ignore
    nancyHost.Stop()
    0