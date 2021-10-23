import unittest

from src.renting.Inventory import Inventory
from src.renting.Item import Item
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
        item = Item(ItemId("1"), "Refactoring 2nd", None)
        testee = Inventory(item)
        # when
        result = testee.find_by_id(item.id)
        # then
        self.assertEqual(item, result)

    def test_mark_item_as_rented(self):
        # given
        item = Item(ItemId("1"), "Refactoring 2nd", None)
        renter_id = RenterId("A")
        testee = Inventory(item)
        # when
        testee.rent(item, renter_id)
        # then
        result = testee.find_by_id(item.id)
        self.assertTrue(result.is_rented())