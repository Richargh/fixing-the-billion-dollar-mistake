from dataclasses import dataclass


@dataclass(frozen=True, eq=True)
class RenterId:
    raw_value: str
