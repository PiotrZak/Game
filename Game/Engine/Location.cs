using System;
using System.Linq;
using Game.Engine.Creatures;

namespace Game.Engine
{
    public class Location
    {
        private static Player _player;
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string AccessCode { get; set; }
        public Item.Abstraction.Item RequiredKey { get; set; }
        
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

        private Item.Abstraction.Item ItemRequiredToEnter { get; set; }
        public Quest.Quest QuestAvailableHere { get; set; }
        public Enemy EnemyLivingHere { get; set; }
        
        public Location(
            int id,
            string name,
            string description,
            Item.Abstraction.Item itemRequiredToEnter = null,
            Quest.Quest questAvailableHere = null,
            Enemy monsterLivingHere = null)
        {
            Id = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            EnemyLivingHere = monsterLivingHere;
        }
        
        public static void MoveTo(Location newLocation)
        {
            if (newLocation.AccessCode != null)
            {
                //todo - implement AccessCode mechanism also protection level, based on experience
            }

            if (newLocation.RequiredKey != null)
            {
                var playerHasKey = _player.Inventory.Cast<Item.Abstraction.Item>().Any(key => key.Id == newLocation.RequiredKey.Id);

                if (!playerHasKey)
                {
                    //todo - configure writeln to RichTextBox if graphical
                    Console.WriteLine("Must have a " + newLocation.RequiredKey.Name + " to enter this location." + Environment.NewLine);
                    return;
                }
            }
            
        }
    }
}