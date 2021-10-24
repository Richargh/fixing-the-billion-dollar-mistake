using Richargh.BillionDollar.Main;

namespace Richargh.BillionDollar
{
    class Program
    {
        static void Main(string[] args)
        {
            InitUsages();
        }

        private static void InitUsages()
        {
            var renter = new Letter
            {
                Sender = "Bob",
                Text = "Hey Alice, it's Bob."
            };
        
            var address = new Address(City:"Trakei", Street:null);
        }
    }
}
