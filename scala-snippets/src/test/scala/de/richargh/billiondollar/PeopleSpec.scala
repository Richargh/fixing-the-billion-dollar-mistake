package de.richargh.billiondollar
import org.junit.runner.RunWith
import org.scalatest.junit.JUnitRunner
import org.scalatest.{FunSuite, Matchers}

@RunWith(classOf[JUnitRunner])
class PeopleSpec extends FunSuite with Matchers {

  test("should not find a person when they're unknown") {
    // given
    val testee = new People()
    // when
    val result = testee.findById(PersonId("1"))
    // then
    result should be(None)
  }

  test("should find a person when they're part of the people") {
    // given
    val testee = new People()
    val person = new Person(PersonId("1"), Some("Alex"))
    // when
    testee.put(person)
    // then
    val result = testee.findById(person.id)
    result should not be(null)
  }

}
