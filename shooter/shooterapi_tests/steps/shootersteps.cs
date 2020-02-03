using TechTalk.SpecFlow;
using System;
using NUnit.Framework;

using shooter.shooterapi;

namespace shooter.shooterapi_tests.steps 
{
    public class ShooterTestSharedContext
    { 
        private Shooter shooter;
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

        [Given(@"an api consumer")]
        public void givenAnApiConsumer() 
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
    }
}