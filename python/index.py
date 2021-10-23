import sys
from src.greet.greeter import Greeter


if __name__ == "__main__":
    name = sys.argv[1] if(len(sys.argv) > 1) else "Ben"
    greeter = Greeter()
    print(greeter.greet(name))