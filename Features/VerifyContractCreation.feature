Feature: Testing process of contact creation

Scenario: Create contact
    Given I am logged in
    When I navigate to "Sales & Marketing" -> "Contacts"
    And I create a new contact with details:
        | FirstName | LastName | Role     | Categories          |
        | John      | Doe      | Developer| Customers, Suppliers|
    Then I verify the created contact details
