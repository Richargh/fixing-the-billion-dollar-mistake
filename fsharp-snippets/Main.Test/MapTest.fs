module MapTests

open System
open Richargh.BillionDollar.Main.Bar
open Xunit

[<Fact>]
let ``should be able to create a map from a tuple list`` () =
    // given
    let capitals: Map<string, string> =
          [ "Argentina", "Buenos Aires";
          "France ", "Paris";
          "Chili", "Santiago";
          "Malaysia", " Kuala Lumpur";
          "Switzerland", "Bern" ]
          // when
          |> Map.ofList
    // then
    Assert.True(capitals.Count = 5)

