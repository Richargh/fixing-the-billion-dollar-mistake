import unittest

from src.renting.Inventory import Inventory
from src.renting.items import AvailableItem, RentedItem
from src.renting.ItemId import ItemId
from src.renting.RenterId import RenterId


class InventoryTest(unittest.TestCase):

    def test_initial_inventory_empty(self):
        # given
        testee = Inventory()
        # when
        result = testee.find_by_id(ItemId("1"))
        # then
        self.assertIsNone(result)

    def test_find_item_if_in_inventory(self):
        # given
        item = AvailableItem(ItemId("1"), "Refactoring 2nd")
        testee = Inventory(item)
        # when
        result = testee.find_by_id(item.id)
        # then
        self.assertEqual(item, result)

    def test_mark_item_as_rented(self):
        # given
        item = AvailableItem(ItemId("1"), "Refactoring 2nd")
        renter_id = RenterId("A")
        testee = Inventory(item)
        # when
        testee.rent(item, renter_id)
        # then
        result = testee.find_by_id(item.id)
        self.assertIsInstance(result, RentedItem)