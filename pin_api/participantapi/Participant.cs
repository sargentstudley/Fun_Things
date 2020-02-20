namespace participant.participantapi 
{
    public class Participant 
    {
        private readonly string firstName;

        private readonly string lastName;

        private readonly int? id;

        public Participant(int? id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        
        public string FirstName
        {
            get 
            {
                return firstName;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
        }

        public int? ID
        {
            get
            {
                return id;
            }
        }
    }
}