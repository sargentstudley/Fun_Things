Feature: Specflow/Nunit Test Framework

   In order to ensure the test framework is working correctly
   As a test runner
   I want to run basic tests to ensure tests work
   So that we don't troubleshoot code when the tests aren't working right.

   Scenario: Basic Sanity Test Passing
   Given comparing Booleans
   When testing true equals true 
   Then the test must pass

   Scenario: Basic Sanity Test Failure
   Given comparing Booleans
   When testing true equals false 
   Then the test must fail