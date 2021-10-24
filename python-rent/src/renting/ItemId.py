from dataclasses import dataclass


@dataclass(frozen=True, eq=True)
class ItemId:
    raw_value: str
