namespace Legacy
{
    public class Register
    {
        public Person FindById(string id)
        {
            if(id == "1")
            {
                return new Person
                {
                    Id = "1",
                    Name = "Vorim"
                };
            }
            
            // allowed in legacy code
            return null;
        }
    }
}