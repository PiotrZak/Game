using System.Collections.Generic;
using System.Linq;
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
            Inventory = new List<ItemState>();
            Quests = new List<PlayerQuest>();
        }
        
        

        public bool HasKeyToEnterLocation(Location location)
        {
            return location.RequiredKey == null ||
                   Inventory.Any(i => i.Details.Id == location.RequiredKey.Id);
        }

        public bool CompletedQuest(Quest.Quest quest)
        {
            foreach(var playerQuest in Quests)
            {
                if(playerQuest.Details.Id == quest.Id)
                {
                    return playerQuest.IsCompleted;
                }
            }
            return false;
        }
        
        public void AddItemToInventory(Item.Abstraction.Item itemToAdd)
        {
            foreach (var i in Inventory.Where(i => i.Details.Id == itemToAdd.Id))
            {
                i.Quantity++;
                return;
            }

            Inventory.Add(new ItemState(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest.Quest quest)
        {
            foreach (var pq in Quests.Where(pq => pq.Details.Id == quest.Id))
            {
                pq.IsCompleted = true;
                return;
            }
        }

        public int Id;
        public int Charisma; 
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        private int _level;
        public int Level
        {
            get => ((ExperiencePoints / 100) + 1);
            set => _level = value;
        }
        
        public Proffesion? Class { get; set; }
        public Specialization? Specialization { get; set; }
        public Location CurrentLocation { get; set; }
        public List<ItemState> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; private set; }
    }
}