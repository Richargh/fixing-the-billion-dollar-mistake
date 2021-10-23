from src.renting.Item import Item
from src.renting.ItemId import ItemId
from src.renting.RenterId import RenterId


class Inventory:
    _items: dict[ItemId, Item] = {}

    def __init__(self, *items: Item):
        self._items = {item.id: item for item in items}

    def find_by_id(self, item_id: ItemId) -> Item | None:
        return self._items.get(item_id, None)

    def rent(self, item: Item, renter_id: RenterId) -> None:
        rented_item = Item(item.id, item.name, renter_id)
        self._items[rented_item.id] = rented_item
