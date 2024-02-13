Feature: Testing process of raport run

Scenario: Remove events from activity log
    Given User is login into app
    When I navigate to Reports & Settings
    And I select the first 3 items in the table
    Then I click Actions Amd Delete and verify if items were removed
