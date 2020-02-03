Feature: Shooter API

   Shooter Object provides a data representation for shooters - people who have shot in archery. 
   Scenario: Using a shooter object to represent a shooter
   Given an api consumer
   When working with a shooter named 'Kathleen' and ID of 1
   Then the shooter should have the name 'Kathleen'
   And the shooter should have the ID 1