namespace shooter.shooterapi 
{
    public class Shooter 
    {
        private readonly string name;

        private readonly int id;

        public Shooter(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        
        public string Name
        {
            get 
            {
                return name;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
        }
    }
}