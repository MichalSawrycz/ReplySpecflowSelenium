Feature: Testing process of raport run

Scenario: Remove events from activity log
    Given I am logged in
    When I navigate to "Reports & Settings" -> "Activity log"
    And I select the first 3 items in the table
    And I click "Actions" -> "Delete"
    Then I verify that items were deleted
