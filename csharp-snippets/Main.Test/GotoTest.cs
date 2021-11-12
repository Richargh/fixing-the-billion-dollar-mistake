using Xunit;
using Xunit.Abstractions;

namespace Richargh.BillionDollar.Main.Test
{
    public class GotoTest
    {
        private readonly ITestOutputHelper _output;

        public GotoTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "We should never ever use the goto statement, even for simple stuff, it is very harmful, but note that in C# you can")]
        void SimpleGotoExample()
        {
            var repeatCount = 0;
            repeat:
            if(repeatCount > 3)
                goto end;
            _output.WriteLine("Repeat");
            repeatCount++;
            goto repeat;

            end:
            _output.WriteLine("End");
        }

        [Fact(DisplayName = "We should never ever use the goto statement, it is very harmful, but note that in C# you can")]
        void ComplexGotoExample()
        {
            _output.WriteLine("I'd wager this is hard to understand");
            var isDone = false;
            var repeatCount = 0;
            
            start:
            if (isDone)
                goto end;
            _output.WriteLine("First");
            
            repeat: 
            if(repeatCount > 3)
            {
                isDone = true;
                goto start;
            }
            _output.WriteLine("Repeat");
            repeatCount++;
            goto repeat;
            
            end:
            _output.WriteLine("End");
        }
    }
}