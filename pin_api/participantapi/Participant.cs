namespace participant.participantapi 
{
    public class Participant 
    {
        public Participant()
        {
            
        }
        public Participant(int? id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        
        public string FirstName {get; set;}
        

        public string LastName {get;set;}
        

        public int? ID {get;set;}
    }
}