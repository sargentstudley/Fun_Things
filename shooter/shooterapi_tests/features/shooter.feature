Feature: Shooter API

   Shooter API provides a data representation for shooters - people who have shot in archery. 

   Scenario: Using a shooter object to represent a shooter
   Given a shooter object user
   When working with a shooter named 'Kathleen' and ID of 1
   Then the shooter should have the name 'Kathleen'
   And the shooter should have the ID 1

   Scenario: Getting a shooter from API 
   Given a shooter api user
   When calling the get shooter method with an ID of 1
   Then the controller should return a shooter object with ID of 1

