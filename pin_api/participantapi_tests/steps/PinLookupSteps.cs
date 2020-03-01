namespace participantapi.PinLookup.PinLookup_tests.steps
{
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using participantapi.Lookups;

    public class PinLookupTestSharedContext
    {
        public PinLookup PinLookup { get; set; }

        public PinLookupTestSharedContext()
        { }
    }

    [Binding]
    public class PinLookupTestSteps
    {
        private PinLookupTestSharedContext testContext;
        public PinLookupTestSteps(PinLookupTestSharedContext sharedTestContext)
        {
            testContext = sharedTestContext;
        }

        [Given(@"a PinLookup is instanciated")]
        public void PinLookupIsInstanciated()
        {
            testContext.PinLookup = new PinLookup();
        }

        [Then(@"the PinLookup should not be null")]
        public void ThenPinLookupNotNull()
        {
            Assert.IsNotNull(testContext.PinLookup);
        }

        [Then(@"the PinLookup Data should not be null")]
        public void ThenPinLookupDataNotNull()
        {
            Assert.IsNotNull(testContext.PinLookup.Data);
        }

        [Then(@"the PinLookup Data.PinGroups should not be null")]
        public void ThenPinLookupDataPinGroupsNotNull()
        {
            Assert.IsNotNull(testContext.PinLookup.Data.PinGroups);
        }

        [Then(@"the PinLookup Data.PinGroups should have 12 groups")]
        public void ThenPinLookupDataPinGroupsHasElements()
        {
            Assert.AreEqual(12, testContext.PinLookup.Data.PinGroups.Count);
        }
    }
}