Feature: Testing process of events removal

Scenario: Remove events from activity log
    Given User is login into app
    When User navigate to Reports & Settings
    And User select the first 3 items in the table
    Then User click Actions Amd Delete and verify if items were removed
