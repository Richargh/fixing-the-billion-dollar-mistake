namespace Richargh.BillionDollar.Main

module DictionaryExample =
    // needed to reference IDictionary
    open System.Collections.Generic

    // create a dictionary from a list of pairs
    let myDict = [ (1,"a"); (2,"b") ] |> dict

    /// get a value from a dictionary, with dictionary as LAST parameter
    let tryGetValue key (dict:IDictionary<_,_>) =
        match dict.TryGetValue(key) with
        | true, value -> Some value
        | false,_ -> None

    // this style is used when piping the dictionary into a key check
    myDict |> tryGetValue 1
    myDict |> tryGetValue 42


    /// get a value from a dictionary, with dictionary as FIRST parameter
    let tryGetValue2 (dict:IDictionary<_,_>) key =
        match dict.TryGetValue(key) with
        | true, value -> Some value
        | false,_ -> None

    // this style is used when you want to bake in the dictionary
    // in a helper function and then pass the keys in later
    let lookup = tryGetValue2 myDict
    lookup 1
    lookup 42