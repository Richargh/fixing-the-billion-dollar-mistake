import unittest
import pytest

from src.renting.items import AvailableItem, Item


class InventoryTest(unittest.TestCase):

    def test_cannot_instantiate_item_protocol(self):
        # given
        # when, then
        with pytest.raises(TypeError):
            Item()

    def test_cannot_instantiate_available_item_without_parameters(self):
        # given
        # when, then
        with pytest.raises(TypeError):
            AvailableItem()
