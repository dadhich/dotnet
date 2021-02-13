using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowDemo
{
    [Binding]
    public class IncomeTaxCalculationSteps
    {
        private Person person;

        [Given(@"A Person")]
        public void GivenAPerson()
        {
            person = new Person("Jack");
        }

        [Given(@"The Person has Annual-Income greater than or equal to 20k But less than or equal to 50k")]
        public void GivenThePersonHasAnnual_IncomeGreaterThanOrEqualTo20kButLessThanOrEqualTo50k()
        {
            person.AnnualIncome = 50000;
        }

        [When(@"income tax is calculated for the person")]
        public void WhenIncomeTaxIsCalculatedForThePerson()
        {
            IncomeTaxCalculator.CalculateTax(person);
        }
        
        [Then(@"the income-tax-rate should be 20 percent")]
        public void ThenTheIncome_Tax_RateShouldBe20Percent()
        {
            Assert.Equal("20%", person.TaxRate);
        }
        
        [Then(@"the income-tax-amount payable by the person should be Annual-Income Multiplied by 20 Percent")]
        public void ThenTheIncome_Tax_AmountPayableByThePersonShouldBeAnnual_IncomeUltipliedBy20Percent()
        {
            Assert.Equal(person.AnnualIncome * 0.2, person.TaxPayable);
        }
    }
}
