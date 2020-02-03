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
        public ShooterTestSharedContext newShooter(string name) 
        {
            return new ShooterTestSharedContext{Shooter = new Shooter(name)};
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

        [When(@"working with a shooter named '(.*)'")]
        public void whenGettingAShooter(string name)
        {
            testContext = testContext.newShooter(name);

        }

        [Then(@"the shooter should have the name '(.*)'")]
        public void shooterHasName(string expectedName) 
        {
            var shooterUnderTest = testContext.Shooter;
            Assert.AreEqual(expectedName, shooterUnderTest.Name);
        }
    }
}