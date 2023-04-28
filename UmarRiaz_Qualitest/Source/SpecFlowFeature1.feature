    Feature: Add and Remove Items from Cart
    As a user of the Katalon demo website
    I want to be able to add and remove items from my cart
    So that I can verify the correct number of items in my cart

    Scenario: Add four random items to cart
        Given I am on the Katalon demo website
        When I add four random items to my cart
        And I view my cart
        Then I find total four items listed in my cart

    Scenario: Remove lowest price item from cart
        Given I am on the Katalon demo website
        When I add four random items to my cart
        And I view my cart
        When I search for lowest price item
        And I am able to remove the lowest price item from my cart
        Then I am able to verify three items in my cart
