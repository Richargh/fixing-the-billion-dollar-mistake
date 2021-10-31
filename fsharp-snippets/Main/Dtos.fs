namespace Richargh.BillionDollar.Main.Dtos

open Richargh.BillionDollar.Main.Bar

type DrinkDto(id: string, name: string) =
    member val Id = id
    member val Name = name

module DtoConverter =
    let DrinkToDto(drink: Drink option): Result<DrinkDto, string> =
        match drink with
            | None -> Error "Could not find drink with that id"
            | Some drink -> Ok(DrinkDto(
                                id = drink.Id.RawValue,
                                name = drink.Name))
