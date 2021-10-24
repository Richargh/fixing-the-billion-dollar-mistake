from src.renting.RenterId import RenterId


class Renter:
    id: RenterId
    name: str

    def __init__(self, id: RenterId, name: str):
        self.id = id
        self.name = name