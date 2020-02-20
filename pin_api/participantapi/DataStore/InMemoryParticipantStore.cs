namespace participant.participantapi.DataStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class InMemoryParticipantStore : IRepository<Participant>
    {
        private List<Participant> participantList;
        private int index;
        public InMemoryParticipantStore(IEnumerable<Participant> participants = null)
        {
            if (participants == null) 
            {
                participantList = new List<Participant>();
                index = 0;
            }
            else
            {
                participantList = participants.ToList();
                index = participantList.Select(p => p.ID.Value).Max();
            }

            
        }
        public void Add(Participant item)
        {
            if (item.ID.HasValue)
            {
                participantList.RemoveAll(p => p.ID == item.ID);
            }
            else
            {
                item = new Participant(++index, 
                                        item.FirstName,
                                        item.LastName
                                    );
                                    
            }
            
            participantList.Add(item);
        }

        public void Add(IEnumerable<Participant> items)
        {
            HashSet<int> participantIds = new HashSet<int>(items.Select(p => p.ID.GetValueOrDefault()));

            //Loop through items to be added, assign IDs to those that don't have it. 
            var participantsToAdd = items.Select(p => p.ID.HasValue ? p 
                                        : new Participant(++index,p.FirstName,p.LastName)).ToHashSet();

            //Loop through all existing items, remove existing duplicates from local store found in hash set. 
            participantList.RemoveAll(p => participantIds.Contains(p.ID.Value));
            
            //Add new items. 
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
            
            Func<Participant,bool> func = expression.Compile();
            return participantList.Single(func);
        }
    }
}