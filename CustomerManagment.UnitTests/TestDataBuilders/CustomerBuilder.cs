using CustomerManagementAPI.Domain;


namespace CustomerManagment.UnitTests.TestDataBuilders
{
    public class CustomerBuilder
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public CustomerBuilder()
        {
            SetDefaults();
        }

        public Customer Build()
        {
            return new Customer(this.Name, this.Email);
        }

        private void SetDefaults()
        {
            this.Name = "Walter Vinicius";
            this.Email = "walter.vlopes@gmail.com";
        }
    }
}
