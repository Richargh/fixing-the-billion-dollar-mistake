from typing import cast

from src.renting.Inventory import Inventory
from src.renting.Renters import Renters
from src.renting.ItemId import ItemId
from src.renting.RenterId import RenterId
from src.renting.items import AvailableItem


class RentUseCase:
    _inventory: Inventory
    _renters: Renters

    def __init__(self, inventory: Inventory, renters: Renters):
        self._inventory = inventory
        self._renters = renters

    def rent(self, item_id: ItemId, renter_id: RenterId):
        item = self._inventory.find_by_id(item_id)
        renter = self._renters.find_by_id(renter_id)
        if (item is None
                or renter is None
                or not isinstance(item, AvailableItem)):
            return False
        item = cast(AvailableItem, item)

        self._inventory.rent(item, renter_id)
        return True
