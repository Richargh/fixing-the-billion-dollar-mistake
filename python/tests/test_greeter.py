from src.greet.greeter import Greeter

def test_sqrt():
    # given
    testee = Greeter()
    # when
    result = testee.greet("Ben")
    # then
    assert result == "Hello Ben!"
