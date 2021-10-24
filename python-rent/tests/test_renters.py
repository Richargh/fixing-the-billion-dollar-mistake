import unittest

from src.renting.Renter import Renter
from src.renting.Renters import Renters
from src.renting.RenterId import RenterId


class RentersTest(unittest.TestCase):

    def test_initially_empty(self):
        # given
        testee = Renters()
        # when
        result = testee.find_by_id(RenterId("1"))
        # then
        self.assertIsNone(result)

    def test_find_item_if_in_inventory(self):
        # given
        renter = Renter(RenterId("1"), "Lisa")
        testee = Renters(renter)
        # when
        result = testee.find_by_id(renter.id)
        # then
        self.assertEqual(renter, result)
