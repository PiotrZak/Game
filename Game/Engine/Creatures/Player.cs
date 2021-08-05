using System.Collections.Generic;
using Game.Engine.Creatures.Abstraction;
using Game.Engine.Quest;

namespace Game.Engine.Creatures
{
    public class Player : Creature
    {
        protected internal Player(
            int gold, 
            int experiencePoints, 
            int level, 
            int id,
            string name,
            int health,
            int currentHitPoints, 
            int maximumHitPoints
            
            ) : base(id, name, health, currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
            Inventory = new List<QuestReward>();
            Quests = new List<PlayerQuest>();
        }

        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        private int Level { get; set; }
        public Location CurrentLocation { get; set; }
        public List<QuestReward> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
    }
    
}