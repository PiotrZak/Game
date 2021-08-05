namespace Game.Engine
{
    public class QuestReward
    {
        public Item.Abstraction.Item Details { get; set; }
        public int Quantity { get; set; }
 
        public QuestReward(Item.Abstraction.Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}