namespace participant.participantapi.DataStore
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;

    public class InMemoryParticipantStore : IRepository<Participant>
    {
        private ConcurrentDictionary<int, Participant> participantList;
        private int index;
        public InMemoryParticipantStore(IEnumerable<Participant> participants = null)
        {
            participantList = new ConcurrentDictionary<int, Participant>();
            index = 0;

            if (participants != null)
            {
                foreach (var p in participants) Add(p); 
                index = participantList.Keys.OrderByDescending(k => k).First();
            }


        }
        public Participant Add(Participant item)
        {
            if (!item.ID.HasValue)
            {
                item = new Participant(Interlocked.Increment(ref index),
                                        item.FirstName,
                                        item.LastName
                                    );
            }

            participantList.AddOrUpdate(item.ID.Value,
                                        item,
                                        (id, existingVal) =>
                                        {
                                            return item;
                                        });

            return item;
        }

        public IEnumerable<Participant> Add(IEnumerable<Participant> items)
        {
            //Loop through items to be added, assign IDs to those that don't have it. 
            var participantsToAdd = items.Select(p => Add(p)).ToList();

            return participantsToAdd;
        }

        public IQueryable<Participant> All()
        {
            return participantList.Values.AsQueryable();
        }

        public IQueryable<Participant> All(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Participant, bool>> expression)
        {
            var setToRemove = participantList.Values.AsQueryable().Where(expression).Select(i => i.ID.Value).ToHashSet();

            Participant particpantRemoved;
            foreach (var i in setToRemove)
            {
                participantList.TryRemove(i, out particpantRemoved);
            }
        }

        public void Delete(Participant item)
        {
            Participant particpantRemoved;

            if (!item.ID.HasValue) throw new ArgumentException("Particpant has no ID, can't do lookup to delete");

            participantList.TryRemove(item.ID.Value, out particpantRemoved);
        }

        public void DeleteAll()
        {
            participantList.Clear();
        }

        public void Dispose()
        {
            participantList.Clear();
        }

        public Participant Single(Expression<Func<Participant, bool>> expression)
        {

            Func<Participant, bool> func = expression.Compile();

            try
            {
                return participantList.Values.Single(func);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}