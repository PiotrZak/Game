using System.Collections.Generic;
using System.Linq;
using Game.Engine.Creatures;
using Game.Engine.Item;

namespace Game.Engine
{
    public static class World
    {
        public static readonly List<Item.Abstraction.Item> Items = new List<Item.Abstraction.Item>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        public static readonly List<Quest.Quest> Quests = new List<Quest.Quest>();
        public static readonly List<Location> Locations = new List<Location>();
        
        public const int ItemIdBook = 1;
        public const int ItemIdTalisman = 2;
        public const int ItemIdKey = 3;
        
        public const int QuestIdMachinery = 1;
        public const int QuestIdSpaceship = 2;

        
        public const int FriendId = 1;
        public const int EnemyParamourId = 2;
        public const int EnemyRenegade = 3;
        
        public const int LocationBridge = 1;
        public const int LocationHeadquarters = 2;
        public const int LocationSpaceship = 3;
        public const int LocationAdminPanel = 4;
        public const int LocationMachinery = 5;
        
        static World()
        {
            PopulateItems();
            PopulateEnemies();
            PopulateQuests();
            PopulateLocations();
        }

        //todo - prepare map
        private static void PopulateLocations()
        {
            var bridge = new Location(LocationBridge, "Bridge", "desc");

            var headQuarter = new Location(LocationHeadquarters, "HeadQuarter", "desc");

            var spaceship = new Location(LocationSpaceship, "Spaceship", "desc")
            {
                QuestAvailableHere = QuestById(QuestIdSpaceship)
            };

            var adminPanel = new Location(LocationAdminPanel, "AdminPanel", "desc")
            {
                EnemyLivingHere = EnemyById(FriendId)
            };

            var machinery = new Location(LocationMachinery, "Machinery", "desc")
            {
                QuestAvailableHere = QuestById(QuestIdMachinery)
            };
            
            bridge.LocationToNorth = spaceship;
            bridge.LocationToSouth = adminPanel;
            bridge.LocationToEast = headQuarter;
            bridge.LocationToWest = machinery;
            
            Locations.Add(bridge);
            Locations.Add(spaceship);
            Locations.Add(adminPanel);
            Locations.Add(headQuarter);
            Locations.Add(machinery);
            
        }

        private static void PopulateQuests()
        {
            var spaceShipQuest =
                new Quest.Quest(
                    QuestIdSpaceship,
                    "Mission I",
                    "Make a research about spaceship and explore the room", 20, 10);

            spaceShipQuest.QuestCompletionItems.Add(new QuestReward(ItemById(ItemIdBook), 3));
            spaceShipQuest.RewardItem = ItemById(ItemIdBook);

            var machineryQuest =
                new Quest.Quest(
                    QuestIdMachinery,
                    "Mission II",
                    "Check all available machines to work property.", 20, 20);

            machineryQuest.QuestCompletionItems.Add(new QuestReward(ItemById(EnemyParamourId), 3));
            machineryQuest.RewardItem = ItemById(ItemIdTalisman);

            Quests.Add(machineryQuest);
            Quests.Add(machineryQuest);
        }

        private static void PopulateEnemies()
        {
            var friend = new Enemy(FriendId, "Dragon", 1600, 200, 200, 40, 120);
            var paramour = new Enemy(EnemyParamourId,  "Paramour", 3200, 800, 500, 70, 180);
            var renegade = new Enemy(EnemyRenegade, "Renegade", 4800, 1200, 1200, 120, 400);

            friend.LootTable.Add((new LootItem(ItemById(ItemIdBook), 20, false)));
            paramour.LootTable.Add((new LootItem(ItemById(ItemIdTalisman), 20, false)));
            renegade.LootTable.Add((new LootItem(ItemById(ItemIdKey), 20, false)));
            
            Enemies.Add(friend);
            Enemies.Add (paramour);
            Enemies.Add(renegade);
            
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ItemIdBook, "Dragon Sword", 10, 50));
            Items.Add(new Armor(ItemIdTalisman,  "Paramour Talisman", 5, 10));
            Items.Add(new Armor(ItemIdKey, "Renegade key", 15, 25));
        }
        

        public static Item.Abstraction.Item ItemById(int id)
        {
            return Items.FirstOrDefault(item => item.Id == id);
        }
        
        public static Enemy EnemyById(int id)
        {
            return Enemies.FirstOrDefault(monster => monster.Id == id);
        }
        
        public static Quest.Quest QuestById(int id)
        {
            return Quests.FirstOrDefault(quest => quest.Id == id);
        }

        public static Location LocationById(int id)
        {
            return Locations.FirstOrDefault(location => location.Id == id);
        }
    }
}