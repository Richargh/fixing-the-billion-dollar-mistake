module Richargh.BillionDollar.Main.Bar

open System

type CreatorId = {
    RawValue: string
}

[<NoEquality; NoComparison>]
type Creator = {
    Id: CreatorId
    Name: string
}

type DrinkId = {
    RawValue: string
}

[<NoEquality; NoComparison>]
type Drink = {
    Id: DrinkId
    Name: string
    CreatorId: CreatorId option 
}

type IBar =
    abstract All: unit -> Drink list
    abstract FindById: DrinkId -> Drink option
    abstract Put: Drink -> unit

type InMemoryBar([<ParamArray>] drinks: Drink[]) =
    
    let mutable allDrinks: Map<DrinkId, Drink> =
            drinks
            |> Array.map (fun drink -> (drink.Id, drink))
            |> Map.ofArray 

    interface IBar with
        member this.All() = 
            allDrinks
            |> Map.toList
            |> List.map(fun (_, drink) -> drink)

        member this.FindById id = 
            allDrinks.TryFind id

        member this.Put (drink: Drink) = 
            allDrinks <- allDrinks.Add(drink.Id, drink)
            
let barOf ([<ParamArray>] drinks: Drink[]): IBar = upcast InMemoryBar(drinks)