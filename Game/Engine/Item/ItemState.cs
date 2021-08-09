namespace Game.Engine.Quest
{
    public class ItemState
    {
        public ItemState(Item.Abstraction.Item details, int quantity, 
            int? minimumDamage = null, 
            int? maximumDamage = null,
            int? maximumDefense = null, 
            int? minimumDefense = null)
        {
            Details = details;
            Quantity = quantity;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            MinimumDefense = minimumDefense;
            MaximumDefense = maximumDefense;
        }
        
        public Item.Abstraction.Item Details { get; set; }
        public int Quantity { get; set; }
        public int? MinimumDamage { get; set; }
        public int? MaximumDamage { get; set; }
        public int? MinimumDefense { get; set; }
        public int? MaximumDefense { get; set; }
    }
}