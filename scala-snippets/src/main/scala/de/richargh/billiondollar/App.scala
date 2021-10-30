package de.richargh.billiondollar

object App {

  def foo(x: Array[String]): String = x.foldLeft("")((a, b) => a + b)

  def main(args: Array[String]) {
    println("Hello World!")
    println("concat arguments = " + foo(args))
    val person = new Person(PersonId("1"), Some("Alex"))
    val people = new People(person)
    val result = people.findById(person.id)
    println("Person "+result)
  }

}
