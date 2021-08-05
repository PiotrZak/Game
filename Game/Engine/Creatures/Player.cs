using System.Collections.Generic;
using Game.Engine.Creatures.Abstraction;

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

        private int Gold { get; set; }
        private int ExperiencePoints { get; set; }
        private int Level { get; set; }
        
        public List<QuestReward> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
    }
    
}