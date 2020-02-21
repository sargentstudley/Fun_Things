namespace participant.participantapi_tests.unit
{
    //https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1

    using System;
    using NUnit.Framework;

    using Microsoft.AspNetCore.Mvc.Testing;
    using participantapi;
    using participantapi.DataStore;
    



    [TestFixture]
    public class StartupTests
    {
        [Test]
        public void Startup_RegistersInMemoryDataStore()
        {

            //Arrange and Act - Startup's methods get exercised on the line below by the test mvc builder. 
            var factory = new WebApplicationFactory<Startup>();

            //Fetch the service that I want to make sure is in there. Participant is a table/object I am persisting.
            var resultRepository = factory.Services.GetService(typeof(IRepository<Participant>));

            //Assert
            try
            {
                InMemoryParticipantStore repository = (InMemoryParticipantStore)resultRepository; 
                // Pretty sure there is a better way to do this.
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected repository type registered: {}", ex.Message);
            }
        }
    }
}

    


