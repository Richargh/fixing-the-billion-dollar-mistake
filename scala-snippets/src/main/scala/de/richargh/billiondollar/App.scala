package de.richargh.billiondollar

object App {

  def foo(x: Array[String]): String = x.foldLeft("")((a, b) => a + b)

  def main(args: Array[String]) {
    println("Hello World!")
    println("concat arguments = " + foo(args))
    val drinks = new Bar()
    val drink = new Drink(new DrinkId("1"), "Naildriver")
  }

}
