using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemo2
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

        public void CalculateTax()
        {
            if (AnnualIncome <= 10000)
            {
                TaxPayable = 0;
                TaxRate = "0%";
            }
            else if (AnnualIncome > 10000 && AnnualIncome <= 20000)
            {
                TaxPayable = AnnualIncome * 0.1;
                TaxRate = "10%";
            }
            else if (AnnualIncome > 20000 && AnnualIncome <= 50000)
            {
                TaxPayable = AnnualIncome * 0.2;
                TaxRate = "20%";
            }
            else
            {
                TaxPayable = AnnualIncome * 0.3;
                TaxRate = "30%";
            }
        }
    }

    public class IncomeTaxCalculator
    {
        
    }
}
