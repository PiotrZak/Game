namespace Game.Engine.Item.Abstraction
{
    public abstract class Item
    {
        protected Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        private string Name { get; set; }
    }
}