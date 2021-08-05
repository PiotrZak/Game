using System.Collections.Generic;

namespace Game.Engine.Quest
{
    public class Quest
    {
        public Quest(int id, string name, string description, int rewardExperiencePoints, int rewardGold)
        {
            Id = id;
            Name = name;
            Description = description;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
        }

        public int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public List<QuestReward> QuestCompletionItems { get; set; }
        public Item.Abstraction.Item RewardItem { get; set; }
    }
}