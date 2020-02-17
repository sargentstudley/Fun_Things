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
            participantList.Add(item);
        }

        public void Add(IEnumerable<Participant> items)
        {
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
            throw new NotImplementedException();
        }

        public void Delete(Participant item)
        {
            participantList.Remove(item);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
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