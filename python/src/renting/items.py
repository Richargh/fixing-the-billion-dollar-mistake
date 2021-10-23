from typing import Protocol

from src.renting.ItemId import ItemId
from src.renting.RenterId import RenterId


class Item(Protocol):
    id: ItemId
    name: str

    def printType(self) -> str:
        match self:
            case AvailableItem():
                item_type = "Available"
            case RentedItem():
                item_type = "Available"
            case None:
                item_type = "Nonexistent"
            case _:
                raise TypeError("Unknown type. No longer needed if decorator @sealed is added to the typing module")
        return item_type


class AvailableItem(Item):
    id: ItemId
    name: str

    def __init__(self, id: ItemId, name: str):
        super().__init__()
        self.id = id
        self.name = name


class RentedItem(Item):
    id: ItemId
    name: str
    rented_by: RenterId

    def __init__(self, id: ItemId, name: str, rented_by: RenterId):
        super().__init__()
        self.id = id
        self.name = name
        self.rented_by = rented_by
