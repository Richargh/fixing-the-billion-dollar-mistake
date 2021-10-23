import unittest

from src.renting.ItemId import ItemId


class ItemIdTest(unittest.TestCase):

    def test_equality(self):
        # given
        testee = ItemId("1")
        other = ItemId("1")
        # when
        result = testee == other
        # then
        self.assertTrue(result)

    def test_inequality(self):
        # given
        testee = ItemId("1")
        other = ItemId("2")
        # when
        result = testee == other
        # then
        self.assertFalse(result)
