import unittest

from src.renting.Inventory import Inventory
from src.renting.ItemId import ItemId
from src.renting.RentUseCase import RentUseCase
from src.renting.Renter import Renter
from src.renting.Renters import Renters
from src.renting.RenterId import RenterId
from src.renting.items import AvailableItem, RentedItem


class RentUseCaseTest(unittest.TestCase):

    def test_renting_possible_when_renter_and_item_valid(self):
        # given
        item = AvailableItem(ItemId("1"), "Refactoring 2nd")
        renter = Renter(RenterId("A"), "Lisa")
        inventory = Inventory(item)
        renters = Renters(renter)
        testee = RentUseCase(inventory, renters)
        # when
        result = testee.rent(item.id, renter.id)
        # then
        self.assertTrue(result)

    def test_renting_impossible_when_item_rented(self):
        # given
        item = RentedItem(ItemId("1"), "Refactoring 2nd", RenterId("Other"))
        renter = Renter(RenterId("A"), "Lisa")
        inventory = Inventory(item)
        renters = Renters(renter)
        testee = RentUseCase(inventory, renters)
        # when
        result = testee.rent(item.id, renter.id)
        # then
        self.assertFalse(result)

    def test_renting_impossible_when_renter_unknown(self):
        # given
        item = AvailableItem(ItemId("1"), "Refactoring 2nd")
        renter = Renter(RenterId("A"), "Lisa")
        inventory = Inventory(item)
        renters = Renters()
        testee = RentUseCase(inventory, renters)
        # when
        result = testee.rent(item.id, renter.id)
        # then
        self.assertFalse(result)