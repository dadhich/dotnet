namespace SpecFlowDemo
{
    public class IncomeTaxCalculator
    { 
        public static void CalculateTax(Person person)
        {
            if (person.AnnualIncome <= 10000)
            {
                person.TaxPayable = 0;
                person.TaxRate = "0%";
            }
            else if (person.AnnualIncome > 10000 && person.AnnualIncome <= 20000)
            {
                person.TaxPayable = person.AnnualIncome * 0.1;
                person.TaxRate = "10%";
            }
            else if (person.AnnualIncome > 20000 && person.AnnualIncome <= 50000)
            {
                person.TaxPayable = person.AnnualIncome * 0.2;
                person.TaxRate = "20%";
            }
            else
            {
                person.TaxPayable = person.AnnualIncome * 0.3;
                person.TaxRate = "30%";
            }
        }
    }
}
