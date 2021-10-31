namespace Richargh.BillionDollar.Main.Controller

open Richargh.BillionDollar.Main.Bar

type DrinkController (bar: IBar) =
    let createDrinkId drinkId: DrinkId =
        {RawValue = $"{drinkId}"}
    
    member this.Get(drinkId:int) : Drink option =
        drinkId
        |> createDrinkId
        |> bar.FindById