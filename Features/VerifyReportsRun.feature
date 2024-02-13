Feature: Testing process of event removal

Scenario: Run report
    Given User has completed login
    When User navigate to Reports and Settings section
    And I find Project Profitability report
    Then I run the report and verify results were returned
