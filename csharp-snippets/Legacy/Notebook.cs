using System.Collections.Generic;

namespace Legacy
{
    public class Notebook : ValueObject
    {

        public string Maker { get; }
        public string Model { get; }
        
        public Notebook(string maker, string model)
        {
            Model = model;
            Maker = maker;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Model;
            yield return Maker;
        }
        
        public override string ToString() =>
            $"{GetType().Name}(" +
            $"{nameof(Model)}={Model}" +
            $", {nameof(Maker)}={Maker}" +
            ")";
    }
}