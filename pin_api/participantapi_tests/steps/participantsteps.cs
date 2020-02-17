namespace participant.participantapi_tests.steps 
{
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using participant.participantapi;
    using participant.participantapi.Controllers;

    public class ParticipantTestSharedContext
    { 
        private Participant participant;
        private ParticipantController participantController;
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
        public ParticipantTestSharedContext newParticipant(int id, string name) 
        {
            return new ParticipantTestSharedContext{Participant = new Participant(id, name)};
        }
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

        [When(@"working with a Participant named '(.*)' and ID of (.*)")]
        public void whenGettingAShooter(string name, int id)
        {
            testContext = testContext.newParticipant(id,name);

        }

        [Then(@"the Participant should have the name '(.*)'")]
        public void shooterHasName(string expectedName) 
        {
            var participantUnderTest = testContext.Participant;
            Assert.AreEqual(expectedName, participantUnderTest.Name);
        }

        [Then(@"the Participant should have the ID (.*)")]
        public void participantShouldHaveIDOf(int id)
        {
            var participantunderTest = testContext.Participant;
            Assert.AreEqual(id,participantunderTest.ID);
        }

        [Given(@"a Participant api user")]
        public void givenAnApiConsumer() 
        {
            var participantControllerUnderTest = new ParticipantController();
            testContext.ParticipantControllerUnderTest = participantControllerUnderTest;
        }
        [When(@"calling the get Participant method with an ID of (.*)")]
        public void whenCallingGetShooterWithId(int id)
        {
            var controllerUnderTest = testContext.ParticipantControllerUnderTest;
            testContext.Participant = controllerUnderTest.Get(id);
            
        }
        [Then(@"the controller should return a Participant object with ID of (.*)")]
        public void controllerShouldReturnParticipantWithID(int id)
        {
            Assert.AreEqual(id, testContext.Participant.ID);
        }
    }
}