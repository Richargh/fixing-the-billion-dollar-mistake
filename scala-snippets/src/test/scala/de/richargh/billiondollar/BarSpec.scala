package de.richargh.billiondollar

import org.junit.runner.RunWith
import org.scalatest.junit.JUnitRunner
import org.scalatest.{FunSuite, Matchers}

@RunWith(classOf[JUnitRunner])
class BarSpec extends FunSuite with Matchers {

  test("should not find a drink when nothing is in the bar") {
    // given
    val drinks = new Bar()
    // when
    val result = drinks.findById(new DrinkId("1"))
    // then
    result should be(null)
  }

  test("should find a drink after we've place it in the bar") {
    // given
    val drinks = new Bar()
    val drink = new Drink(new DrinkId("1"), "Naildriver")
    // when
    drinks.place(drink)
    // then
    val result = drinks.findById(drink.id())
    result should not be(null)
  }

}