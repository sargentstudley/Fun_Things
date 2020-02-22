Feature: Participant API

   Participant API provides a data representation for Participants - people who have shot in archery. 

   Scenario: Using a Participant object to represent a Participant
   Given a Participant object user
   When working with a Participant with the first name 'John', the last name 'Doe', and ID of 1
   Then the Participant should have the first name 'John'
   And the Participant should have the last name 'Doe'
   And the Participant should have the ID 1

   Scenario: Getting a Participant from API 
   Given a participant with ID of 1, first name 'John', and last name 'Doe' exists already
   When calling the get Participant method with an ID of 1
   Then the controller should return a Participant object with ID of 1

   Scenario: Getting a Participant from API that doesn't exist
   Given a participant with ID of 12345, first name 'John', and last name 'Doe' doesn't exist
   When calling the get Participant method with an ID of 12345
   Then the controller get should return not found.

   Scenario: Inserting a Participant from API
   Given 'John' 'Doe' is not persisted
   When  participant 'John' 'Doe' is sent to the api using the put method
   Then  participant 'John' 'Doe' is persisted to the data store

   Scenario: Getting all Participants from API 
   Given a participant with ID of 1, first name 'John', and last name 'Doe' exists already
   When calling the get Participant method
   Then the controller should return a list of Participants
   And the first participant's ID is 1

