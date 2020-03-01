Feature: PinLookup
   PinLookup provides a base dataset representation for pins and what is needed to get one.

   Scenario: Using a PinLookup object to represent a PinLookup
      Given a PinLookup is instanciated
      Then the PinLookup should not be null
      Then the PinLookup Data should not be null
      Then the PinLookup Data.PinGroups should not be null
      Then the PinLookup Data.PinGroups should have 12 groups

