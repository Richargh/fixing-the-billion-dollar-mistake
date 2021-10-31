module BarTests

open Richargh.BillionDollar.Main.Bar
open Xunit

[<Fact>]
let ``should not find a drink when the bar is empty`` () =
    // given
    let bar = barOf([||])
    // when
    let result = bar.FindById {RawValue = "1"}
    // then
    match result with
        | Some _ -> Assert.False true
        | None -> Assert.True true

[<Fact>]
let ``should find a drink when we've place it in the bar`` () =
    // given
    let drink: Drink = {Id = {RawValue = "1"}; Name = "Naildriver"; CreatorId = None}
    let bar = barOf([|drink|])
    // when
    let result = bar.FindById drink.Id
    // then
    Assert.Equal(Some(drink), result)