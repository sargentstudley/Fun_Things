namespace shooter.shooterapi_tests.steps 
{
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using shooter.shooterapi;
    using shooter.shooterapi.Controllers;

    public class ShooterTestSharedContext
    { 
        private Shooter shooter;
        private ShooterController shooterController;
        public ShooterTestSharedContext()
        {
            
        }

        public Shooter Shooter
        {
            get 
            {
                return shooter;
            }
            set
            {
                shooter = value;
            }
        }

        public ShooterController ShooterControllerUnderTest
        {
            get
            {
                return shooterController;
            }
            set
            {
                shooterController = value;
            }
        }
        public ShooterTestSharedContext newShooter(int id, string name) 
        {
            return new ShooterTestSharedContext{Shooter = new Shooter(id, name)};
        }
    }

    [Binding]
    public class ShooterTestSteps 
    {
        private ShooterTestSharedContext testContext;
        public ShooterTestSteps(ShooterTestSharedContext sharedTestContext)
        {
            testContext = sharedTestContext;
        }

        [Given(@"a shooter object user")]
        public void givenAShooterObjectUser() 
        {
            
        }

        [When(@"working with a shooter named '(.*)' and ID of (.*)")]
        public void whenGettingAShooter(string name, int id)
        {
            testContext = testContext.newShooter(id,name);

        }

        [Then(@"the shooter should have the name '(.*)'")]
        public void shooterHasName(string expectedName) 
        {
            var shooterUnderTest = testContext.Shooter;
            Assert.AreEqual(expectedName, shooterUnderTest.Name);
        }

        [Then(@"the shooter should have the ID (.*)")]
        public void shootShouldHaveIDOf(int id)
        {
            var shooterunderTest = testContext.Shooter;
            Assert.AreEqual(id,shooterunderTest.ID);
        }

        [Given(@"a shooter api user")]
        public void givenAnApiConsumer() 
        {
            var shooterControllerUnderTest = new ShooterController();
            testContext.ShooterControllerUnderTest = shooterControllerUnderTest;
        }
        [When(@"calling the get shooter method with an ID of (.*)")]
        public void whenCallingGetShooterWithId(int id)
        {
            var controllerUnderTest = testContext.ShooterControllerUnderTest;
            testContext.Shooter = controllerUnderTest.Get(id);
            
        }
        [Then(@"the controller should return a shooter object with ID of (.*)")]
        public void controllerShouldReturnShooterWithID(int id)
        {
            Assert.AreEqual(id, testContext.Shooter.ID);
        }
    }
}