Feature: Testing process of report run

Scenario: Run report
    Given User has completed login
    When User navigate to Reports and Settings section
    And User finds Project Profitability report
    Then User run the report and verify results were returned
