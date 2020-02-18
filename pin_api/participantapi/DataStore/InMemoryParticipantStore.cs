namespace participant.participantapi.DataStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class InMemoryParticipantStore : IRepository<Participant>
    {
        private List<Participant> participantList;
        public InMemoryParticipantStore(IEnumerable<Participant> participants = null)
        {
            if (participants == null) 
            {
                participantList = new List<Participant>();
            }
            else
            {
                participantList = participants.ToList();
            }
        }
        public void Add(Participant item)
        {
            participantList.RemoveAll(p => p.ID == item.ID);
            participantList.Add(item);
        }

        public void Add(IEnumerable<Participant> items)
        {
            HashSet<int> participantIds = new HashSet<int>(items.Select(p => p.ID));
            participantList.RemoveAll(p => participantIds.Contains(p.ID));
            participantList.AddRange(items);
        }

        public IQueryable<Participant> All()
        {
            return participantList.AsQueryable();
        }

        public IQueryable<Participant> All(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Participant, bool>> expression)
        {
            var setToRemove = participantList.AsQueryable().Where(expression).ToHashSet();
            participantList.RemoveAll(p => setToRemove.Contains(p));
        }

        public void Delete(Participant item)
        {
            participantList.Remove(item);
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
            return participantList.AsQueryable().Single(expression);
        }
    }
}