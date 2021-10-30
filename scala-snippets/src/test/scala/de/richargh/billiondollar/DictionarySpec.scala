package de.richargh.billiondollar

import org.junit.runner.RunWith
import org.scalatest.junit.JUnitRunner
import org.scalatest.{FunSuite, Matchers}

@RunWith(classOf[JUnitRunner])
class DictionarySpec extends FunSuite with Matchers {

  test("should not find a number plate when it's not in the dictionary") {
    // given
    val numberPlates = Map("F" -> "Frankfurt", "B" -> "Berlin")
    // when
    val result = numberPlates.get("HH")
    // then
    result should be(None)
  }

  test("should find a number plate when it's in the dictionary") {
    // given
    val numberPlates = Map("F" -> "Frankfurt", "B" -> "Berlin")
    // when
    val result = numberPlates.get("F")
    // then
    result should be(Some("Frankfurt"))
  }

}
