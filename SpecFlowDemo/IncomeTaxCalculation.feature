Feature: IncomeTaxCalculation
	Calculate Income Tax

Scenario: Calculate Income-Tax for Annual-Income Ranging Between $20,000 and $50,000
	Given A Person 
	Given The Person has Annual-Income greater than or equal to 20k But less than or equal to 50k
	When income tax is calculated for the person
	Then the income-tax-rate should be 20 percent
	And the income-tax-amount payable by the person should be Annual-Income Multiplied by 20 Percent