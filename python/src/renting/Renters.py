from src.renting.Renter import Renter
from src.renting.RenterId import RenterId


class Renters:
    _renters: dict[RenterId, Renter] = {}

    def __init__(self, *renters: Renter):
        self._renters = {renter.id: renter for renter in renters}

    def find_by_id(self, item_id: RenterId) -> Renter | None:
        return self._renters.get(item_id, None)
