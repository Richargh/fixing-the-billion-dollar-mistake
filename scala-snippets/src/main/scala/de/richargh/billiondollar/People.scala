package de.richargh.billiondollar

class People(people: Person*) {
  private var allPeople: Map[PersonId, Person] = people.map(p => (p.id, p)).toMap

  def findById(id: PersonId): Option[Person] = allPeople.get(id)

  def put(person: Person): Unit = {
    allPeople += (person.id -> person)
  }
}
