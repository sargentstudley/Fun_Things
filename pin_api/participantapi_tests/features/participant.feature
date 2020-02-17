Feature: Participant API

   Participant API provides a data representation for Participants - people who have shot in archery. 

   Scenario: Using a Participant object to represent a Participant
   Given a Participant object user
   When working with a Participant named 'Kathleen' and ID of 1
   Then the Participant should have the name 'Kathleen'
   And the Participant should have the ID 1

   Scenario: Getting a Participant from API 
   Given a Participant api user
   When calling the get Participant method with an ID of 1
   Then the controller should return a Participant object with ID of 1

