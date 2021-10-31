module ListTests

open Xunit

[<Fact>]
let ``should be able to create a list`` () =
    // given
    let countries: string list =
          [ "Argentina";
          "France";
          "Chili";
          "Malaysia";
          "Switzerland"]
    // then
    Assert.True(countries.Length = 5)
    
[<Fact>]
let ``should be able create a ranged list`` () =
    // given
    let numbers: int list =
          [1..100]
    // then
    Assert.True(numbers.Length = 100)
    
[<Fact>]
let ``should be able to map numbers to strings`` () =
    // given
    let numbers: string list =
          [1; 2; 3; 4; 5]
          |> List.map (fun num -> $"{num}")
    // then
    Assert.True(numbers.Length = 5)
    
[<Fact>]
let ``should be able filter all numbers larger than 3`` () =
    // given
    let numbers: int list =
          [1; 2; 3; 4; 5]
          |> List.filter (fun num -> num > 3)
    // then
    Assert.True(numbers.Length = 2)