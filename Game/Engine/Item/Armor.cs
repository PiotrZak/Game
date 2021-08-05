namespace Game.Engine.Item
{
    public class Armor : Abstraction.Item
    {
        public Armor(int id, string name, int minimumDefense, int maximumDefense) : base(id, name)
        {
            MinimumDefense = minimumDefense;
            MaximumDefense = maximumDefense;
        }

        private int MinimumDefense { get; set; }
        private int MaximumDefense { get; set; }
    }
}