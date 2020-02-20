using System;
using System.Linq;
using System.Collections.Generic;
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

        [Test]
        public void InMemoryParticipantStore_ConstructsWithExistingList()
        {
            //Setup
            List<Participant> originalList = new List<Participant>();
            originalList.Add(new Participant(1, "Bob","Smith"));
            originalList.Add(new Participant(2, "Joe", "Snape"));

            //Run test
            IRepository<Participant> store = new InMemoryParticipantStore(originalList);

            //Assert Results
            Assert.That(store.All().ToList(), Is.EquivalentTo(originalList));
        }

        [Test]
        public void InMemoryParticipantStore_CanLookup()
        {
            //Setup
            List<Participant> originalList = new List<Participant>();
            var expectedParticipant = new Participant(1, "Bob", "Smith");
            originalList.Add(expectedParticipant);
           
            IRepository<Participant> store = new InMemoryParticipantStore(originalList);

            var result = store.Single(p => p.ID == expectedParticipant.ID);

            //Assert Results
            Assert.That(result, Is.EqualTo(expectedParticipant));
        }

        [Test]
        public void InMemoryParticipantStore_canAdd()
        {
            var participantAdded = new Participant(1, "Bob","Smith");
            IRepository<Participant> store = new InMemoryParticipantStore();
            store.Add(participantAdded);
            var resultParticipant = store.Single(a => a.ID == participantAdded.ID);

            Assert.That(resultParticipant, Is.EqualTo(participantAdded));
        }

        [Test]
        public void InMemoryParticipantStore_canUpsert()
        {
            var participantAdded = new Participant(1, "Bob", "Smith");
            IRepository<Participant> store = new InMemoryParticipantStore();
            store.Add(participantAdded);

            var updatedParticipant = new Participant(1,"Joe", "Smith");
            store.Add(updatedParticipant);

            var resultParticipant = store.Single(a => a.ID == participantAdded.ID);

            Assert.That(resultParticipant, Is.EqualTo(updatedParticipant));
        }

        [Test]
        public void InMemoryParticipantStore_canUpsertMany()
        {
            var original1 = new Participant(1, "Bob", "Smith");
            var original2 = new Participant(2, "Joe", "Smith");

            var originalList = new List<Participant>() {original1, original2};

            IRepository<Participant> store = new InMemoryParticipantStore(originalList);

            var changed1 = new Participant(1, "Sarah","Jane");
            var changed2 = new Participant(2, "Jane", "Smith");

            var changedList = new List<Participant>(){changed1, changed2};


            store.Add(changedList);

            var resultList = store.All().ToList();

            Assert.That(resultList, Is.EquivalentTo(changedList));
        }

        [Test]
        public void InMemoryParticipantStore_CanDelete()
        {
            //Setup
            List<Participant> originalList = new List<Participant>();
            var participantToDelete = new Participant(1, "Bob", "Smith");
            var secondParticipant = new Participant(2, "Joe", "Doe");
            originalList.Add(participantToDelete);
            originalList.Add(secondParticipant);
           
            IRepository<Participant> store = new InMemoryParticipantStore(originalList);

            store.Delete(p => p.ID == participantToDelete.ID);

            var resultList = store.All().ToList();
            var remainingParticipant = resultList.SingleOrDefault(p => p.ID == secondParticipant.ID);

            //Assert Results
            Assert.That(resultList.Count, Is.EqualTo(1));
            Assert.That(remainingParticipant, Is.Not.Null);
            
        }

        [Test]
        public void InMemoryParticipantStore_canUpsertAndThenSelect()
        {
            var participantAdded = new Participant(null, "Bob", "Smith");
            IRepository<Participant> store = new InMemoryParticipantStore();
            store.Add(participantAdded);

            var resultParticipant = store.Single(a => a.FirstName == participantAdded.FirstName);

            Assert.That(resultParticipant.FirstName, Is.EqualTo(participantAdded.FirstName));
            Assert.That(resultParticipant.ID, Is.Not.Null);
        }

        [Test]
        public void InMemoryParticipantStore_canUpsertManyAndThenSelect()
        {
            var participant1 = new Participant(null, "Bob", "Smith");
            var participant2 = new Participant(null, "John", "Doe");
            var participantArray = new Participant[] {participant1, participant2};

            IRepository<Participant> store = new InMemoryParticipantStore();
            store.Add(participantArray);

            var resultParticipant = store.Single(a => a.FirstName == participant1.FirstName);

            Assert.That(resultParticipant.FirstName, Is.EqualTo(participant1.FirstName));
            Assert.That(resultParticipant.ID, Is.Not.Null);
        }
    }


}