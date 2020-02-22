namespace participant.participantapi_tests.steps
{
    using Microsoft.AspNetCore.Mvc;
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using participant.participantapi;
    using participant.participantapi.Controllers;
    using participantapi.DataStore;

    public class ParticipantTestSharedContext
    {
        private Participant participant;
        private ParticipantController participantController;

        private InMemoryParticipantStore testDataStore;
        public ParticipantTestSharedContext()
        {

        }

        public Participant Participant
        {
            get
            {
                return participant;
            }
            set
            {
                participant = value;
            }
        }

        public Participant[] Participants { get; set; }

        public InMemoryParticipantStore TestDataStore
        {
            get
            {
                return testDataStore;
            }
            set
            {
                testDataStore = value;
            }
        }

        public ParticipantController ParticipantControllerUnderTest
        {
            get
            {
                return participantController;
            }
            set
            {
                participantController = value;
            }
        }
        public ParticipantTestSharedContext newParticipant(int id, string firstName, string secondName)
        {
            return new ParticipantTestSharedContext { Participant = new Participant(id, firstName, secondName) };
        }

        public ActionResult Result {get;set;}
    }

    [Binding]
    public class ParticipantTestSteps
    {
        private ParticipantTestSharedContext testContext;
        public ParticipantTestSteps(ParticipantTestSharedContext sharedTestContext)
        {
            testContext = sharedTestContext;
        }

        [Given(@"a Participant object user")]
        public void givenAShooterObjectUser()
        {

        }

        //working with a Participant with the first name 'John', the last name 'Doe', and ID of 1
        [When(@"working with a Participant with the first name '(.*)', the last name '(.*)', and ID of (.*)")]
        public void whenGettingAShooter(string firstName, string lastName, int id)
        {
            testContext = testContext.newParticipant(id, firstName, lastName);

        }

        [Then(@"the Participant should have the first name '(.*)'")]
        //the Participant should have the first name 'John'
        public void participantHasFirstName(string expectedName)
        {
            var participantUnderTest = testContext.Participant;
            Assert.AreEqual(expectedName, participantUnderTest.FirstName);
        }

        [Then(@"the Participant should have the last name '(.*)'")]
        public void participantHasLastName(string expectedName)
        {
            var participantUnderTest = testContext.Participant;
            Assert.That(participantUnderTest.LastName, Is.EqualTo(expectedName));
        }

        [Then(@"the Participant should have the ID (.*)")]
        public void participantShouldHaveIDOf(int id)
        {
            var participantunderTest = testContext.Participant;
            Assert.AreEqual(id, participantunderTest.ID);
        }

        [Given(@"a participant with ID of (.*), first name '(.*)', and last name '(.*)' exists already")]
        public void givenADatabaseWithParticipant(int id, string firstName, string lastName)
        {
            var testDataStore = new InMemoryParticipantStore();
            var participantControllerUnderTest = new ParticipantController(testDataStore);
            var expectedParticipant = new Participant(id, firstName, lastName);
            testDataStore.Add(expectedParticipant);
            testContext.ParticipantControllerUnderTest = participantControllerUnderTest;
            testContext.TestDataStore = testDataStore;
        }

        [Given(@"'(.*)' '(.*)' is not persisted")]
        public void setupEmptyDatabase(string firstname, string lastName)
        {
            //Or just make an empty database.
            var testDataStore = new InMemoryParticipantStore();
            var participantControllerUnderTest = new ParticipantController(testDataStore);
            testContext.ParticipantControllerUnderTest = participantControllerUnderTest;
            testContext.TestDataStore = testDataStore;
        }

        [When(@"calling the get Participant method")]
        public void whenCallingGetAllParticipants()
        {
            //Adding the participant into the data store. 
            var controllerUnderTest = testContext.ParticipantControllerUnderTest;
            testContext.Participants = controllerUnderTest.Get().Value;
        }

        [When(@"calling the get Participant method with an ID of (.*)")]
        public void whenCallingGetShooterWithId(int id)
        {
            //Adding the participant into the data store. 
            //var expectedParticipant = new Participant(id, "John", "Doe");

            var controllerUnderTest = testContext.ParticipantControllerUnderTest;
            
            testContext.Participant = controllerUnderTest.Get(id).Value;
        }
        [Then(@"the controller should return a Participant object with ID of (.*)")]
        public void controllerShouldReturnParticipantWithID(int id)
        {
            Assert.AreEqual(id, testContext.Participant.ID);
        }

        [Then(@"the controller get should return not found.")]
        public void controllerGetReturnsNotFound()
        {
            Assert.That(testContext.Participant, Is.Null);
        }

        [When(@"participant '(.*)' '(.*)' is sent to the api using the put method")]
        public void whenUpsertingANewParticipant(string firstName, string lastName)
        {
            var expectedParticipant = new Participant(null, firstName, lastName);

            Participant[] participantsToSubmit = new Participant[] {
                expectedParticipant
            };
            testContext.ParticipantControllerUnderTest.Put(participantsToSubmit);
        }

        [Then(@"participant '(.*)' '(.*)' is persisted to the data store")]
        public void dataStoreHasParticipant(string firstName, string lastName)
        {
            Assert.That(testContext.TestDataStore.Single(
                p => p.FirstName.Equals(firstName)
                 && p.LastName.Equals(lastName)),
                Is.Not.Null);
        }
        [Then(@"the controller should return a list of Participants")]

        public void verifyReturnType()
        {
            Assert.That(testContext.Participants, Is.TypeOf(typeof(Participant[])));
        }

        [Then(@"the first participant's ID is (.*)")]
        public void verifyFirstParticipantId(int id)
        {
            Assert.That(testContext.Participants[0].ID.Value, Is.EqualTo(id));
        }

        [Given(@"a participant with ID of (.*), first name '(.*)', and last name '(.*)' doesn't exist")]
        public void setupParticipantThatDoesNotExists(int id, string firstName, string lastName)
        {
            var testDataStore = new InMemoryParticipantStore();
            var participantControllerUnderTest = new ParticipantController(testDataStore);
            testContext.ParticipantControllerUnderTest = participantControllerUnderTest;
            testContext.TestDataStore = testDataStore;
        }

        
    }
}