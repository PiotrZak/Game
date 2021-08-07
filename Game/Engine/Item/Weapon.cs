namespace Game.Engine.Item
{
    public class Weapon : Abstraction.Item
    {
        public Weapon(int id, string name, int minimumDamage, int maximumDamage) : base(id, name)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public object this[int i]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}