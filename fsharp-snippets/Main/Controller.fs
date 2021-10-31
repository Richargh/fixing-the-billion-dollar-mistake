namespace Richargh.BillionDollar.Main.Controller

open Richargh.BillionDollar.Main.Bar
open Richargh.BillionDollar.Main.Dtos

type DrinkController (bar: IBar) =
    let createDrinkId drinkId: DrinkId =
        {RawValue = $"{drinkId}"}
    
    member this.Get(drinkId:int) : Result<DrinkDto, string> =
        drinkId
        |> createDrinkId
        |> bar.FindById
        |> DtoConverter.DrinkToDto