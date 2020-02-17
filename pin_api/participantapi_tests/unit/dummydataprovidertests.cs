using System;
using NUnit.Framework;
using participant.participantapi;
using participant.participantapi.DataStore;
namespace participant.participantapi_tests.unit 
{

    [TestFixture]
    public class InMemoryParticipantStoreTests
    {
        [Test]
        public void InMemoryParticipantStore_DefaultConstructs()
        {
            IRepository<Participant> dummystorage = new InMemoryParticipantStore();       
        }
    }


}