Feature: Testing process of event removal

Scenario: Run report
    Given I am logged in
    When I navigate to "Reports & Settings" -> "Reports"
    And I find "Project Profitability" report
    Then I run the report and verify results were returned
