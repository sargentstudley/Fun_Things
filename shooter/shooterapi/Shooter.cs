using System;

namespace shooter.shooterapi 
{
    public class Shooter 
    {
        public Shooter(string name)
        {
            this.name = name;
        }
        private readonly string name;
        public string Name
        {
            get 
            {
                return name;
            }
        }
    }
}