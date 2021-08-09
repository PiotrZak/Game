using Game.Engine.Quest;

namespace Game.Engine.Item
{
    public class LootItem
    {
        public Abstraction.Item Details { get; set; }
        public int DropPercentage { get; set; }
        public bool IsDefaultItem { get; set; }
 
        public LootItem(Abstraction.Item details, int dropPercentage, bool isDefaultItem)
        {
            Details = details;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}