using TechTalk.SpecFlow;
using System;
using NUnit.Framework;

namespace shooter.shooterapi_tests.steps 
{
    [Binding]
    public class SanityTestSteps 
    {
        [Given(@"comparing Booleans")]
        public void comparingBooleans() 
        {
            Console.WriteLine("When Comparing booleans");
        }

        [When(@"testing true equals true")]
        public void testingTrueEqualsTrue()
        {
            Console.WriteLine("When testing true equals true");
        }

        [Then(@"the test should pass")]
        public void theTestShouldPass()
        {
            Assert.AreEqual(true,true);
        }

        [When(@"testing true equals false")]
        public void testingTrueEqualsFalse()
        {
            Console.WriteLine("When testing true equals false");
        }

        [Then(@"the test should fail")]
        public void theTestShouldFail()
        {
            try 
            {
                Assert.AreEqual(false,true);
            }
            catch (AssertionException assertEx) 
            {
                Assert.IsNotNull(assertEx);
                Assert.Pass();
            }
        }
    }
}