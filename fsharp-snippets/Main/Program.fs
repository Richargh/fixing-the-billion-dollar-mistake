open Richargh.BillionDollar.Legacy
open Richargh.BillionDollar.Main.Bar
open Richargh.BillionDollar.Main.Controller

let printMaker (employee: Employee) =
    match employee.Notebook with
        | null -> printfn $"{employee.Name} has no notebook"
        | _ -> printfn $"{employee.Name}'s notebook is by {employee.Notebook.Maker}"

let testInterop =
    let employee1 = Employee(EmployeeId("1"), "Zii", null)
    let employee2 = Employee(EmployeeId("2"), "Xaat", Notebook("Bell", "Grand Tour Plus Extra"))
    printMaker employee1
    printMaker employee2
    
let createPseudoWebApp = 
    let bar = barOf([||])
    let barController = DrinkController(bar)
    ()
    
[<EntryPoint>]
let main argv =
    testInterop
    createPseudoWebApp
    0 // return an integer exit code