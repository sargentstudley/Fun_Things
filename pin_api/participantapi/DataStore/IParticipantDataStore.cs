namespace participant.participantapi.DataStore 
{
    using System.Collections.Generic;
    public interface IParticipantDataStore
    {
        public List<Participant> Get(Participant participant = null);
    }
}