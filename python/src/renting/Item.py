from src.renting.ItemId import ItemId
from src.renting.RenterId import RenterId


class Item:
    id: ItemId
    name: str
    rented_by: RenterId | None

    def __init__(self, id: ItemId, name: str, rented_by: RenterId | None):
        self.id = id
        self.name = name
        self.rented_by = rented_by

    def is_rented(self) -> bool:
        return self.rented_by is not None
