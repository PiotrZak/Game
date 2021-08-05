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
        private string Name { get; set; }
        private int Health { get; set; }
        private int CurrentHitPoints { get; set; }
        private int MaximumHitPoints { get; set; }
    }
}