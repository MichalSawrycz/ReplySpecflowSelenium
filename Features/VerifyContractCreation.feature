Feature: Testing process of contact creation

Scenario: Create contact
    Given User is logged into app
    When User navigate to Contracts tab in Sales & Marketing section
    And User create a new contact
    Then User open the created contact and verify its data

