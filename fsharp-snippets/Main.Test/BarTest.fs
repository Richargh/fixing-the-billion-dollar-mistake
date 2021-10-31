module BarTests

open Richargh.BillionDollar.Main.Bar
open Xunit

[<Fact>]
let ``My test`` () =
    // given
    let drink: Drink = {Id = {RawValue = "1"}; Name = "Naildriver"; CreatorId = None}
    let bar = barOf([|drink|])
    // when
    let result = bar.FindById drink.Id
    // then
    Assert.Equal(Some(drink), result)