open Richargh.BillionDollar.Legacy

let printMaker (employee: Employee) =
    match employee.Notebook with
        | null -> printfn $"{employee.Name} has no notebook"
        | _ -> printfn $"{employee.Name}'s notebook is by {employee.Notebook.Maker}"

[<EntryPoint>]
let main argv =
    let employee1 = Employee(EmployeeId("1"), "Zii", null)
    let employee2 = Employee(EmployeeId("2"), "Xaat", Notebook("Bell", "Grand Tour Plus Extra"))
    printMaker employee1
    printMaker employee2
    0 // return an integer exit code