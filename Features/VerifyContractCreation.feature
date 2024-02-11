Feature: Testing process of contact creation

Scenario: Create contact
    Given User is logged in
    When User navigate to Contracts tab in Sales & Marketing section
    And I create a new contact with details:
        | FirstName | LastName | Role     | Categories          |
        | John      | Doe      | Developer| Customers, Suppliers|
    Then I open the created contact and verify its data

