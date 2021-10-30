package de.richargh.billiondollar

import org.junit.runner.RunWith
import org.scalatest.junit.JUnitRunner
import org.scalatest.{FunSuite, Matchers}

@RunWith(classOf[JUnitRunner])
class BarSpec extends FunSuite with Matchers {

  test("should not find a drink when nothing is in the bar") {
    // given
    val testee = new Bar()
    // when
    val result = testee.findById(new DrinkId("1"))
    // then
    result shouldBe null
  }

  test("should find a drink after we've place it in the bar") {
    // given
    val testee = new Bar()
    val drink = new Drink(new DrinkId("1"), "Naildriver")
    // when
    testee.place(drink)
    // then
    val result = testee.findById(drink.id())
    result should not be(null)
  }

}