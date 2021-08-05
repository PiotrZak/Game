namespace Game.Engine.Item
{
    public class Weapon : Abstraction.Item
    {
        public Weapon(int id, string name, int minimumDamage, int maximumDamage) : base(id, name)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }

        private int MinimumDamage { get; set; }
        private int MaximumDamage { get; set; }
    }
}