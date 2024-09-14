Feature: Portfolio Visitor

Scenario Outline:  Visit and Verify portfolio
	Given Driver is initiated for portfolio website
	When Verify the portfolio page is open for the '<SITE>'
	Then Verify the portfolio page content

	Examples:
	|SITE|
	|portfolioURL|