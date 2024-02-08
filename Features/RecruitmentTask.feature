Feature: Testing various functionalities of the application

Scenario: Create contact
    Given I am logged in
    When I navigate to "Sales & Marketing" -> "Contacts"
    And I create a new contact with details:
        | FirstName | LastName | Role     | Categories          |
        | John      | Doe      | Developer| Customers, Suppliers|
    Then I verify the created contact details

Scenario: Run report
    Given I am logged in
    When I navigate to "Reports & Settings" -> "Reports"
    And I find "Project Profitability" report
    Then I run the report and verify results were returned

Scenario: Remove events from activity log
    Given I am logged in
    When I navigate to "Reports & Settings" -> "Activity log"
    And I select the first 3 items in the table
    And I click "Actions" -> "Delete"
    Then I verify that items were deleted