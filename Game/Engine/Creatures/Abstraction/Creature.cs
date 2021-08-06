namespace Game.Engine.Creatures.Abstraction
{
    public abstract class Creature
    {
        protected Creature(int id, string name, int health, int currentHitPoints, int maximumHitPoints)
        {
            Id = id;
            Name = name;
            Health = health;
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }
    }
}