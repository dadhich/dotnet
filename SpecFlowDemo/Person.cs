namespace SpecFlowDemo
{
    public class Person
    {
        public string PersonName { get; set; }

        public double AnnualIncome { get; set; }

        public double TaxPayable { get; set; }

        public string TaxRate { get; set; }

        public Person(string name)
        {
            PersonName = name;
        }
    }
}
