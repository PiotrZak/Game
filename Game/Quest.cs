using System;
using System.Linq;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Quest;

namespace Game
{
    public class Quest
    {
        private static Player _player;

        public Quest(Player player)
        {
            _player = player;
        }

        public static bool CheckForQuestInNewLocation(Location newLocation)
        {
            if(newLocation.QuestAvailableHere != null)
            {
                //CheckPlayerRequirements
                var playerAlreadyHasQuest = false;
                var playerAlreadyCompletedQuest = false;

                foreach (var playerQuest in _player.Quests
                    .Where(playerQuest => playerQuest.Details.Id == newLocation.QuestAvailableHere.Id))
                {
                    playerAlreadyHasQuest = true;

                    if(playerQuest.IsCompleted)
                    {
                        playerAlreadyCompletedQuest = true;
                    }
                }
                
                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        var isRequirementFulfilled = PlayerPersonalRevision(newLocation);
                        
                        if (isRequirementFulfilled)
                        {
                            InitiateDialog(newLocation);
                        }
                        else
                        {
                            //todo - it's possible to print, what exactly is need for this quest
                            Console.WriteLine("Not ready yet");
                        }
                    }
                }
            }
            return false;
        }

        private static bool PlayerPersonalRevision(Location newLocation)
        {
            foreach(var questReward in newLocation.QuestAvailableHere.QuestCompletionItems)
            {
                return _player.Inventory
                    .Where(j => j.Details.Id == questReward.Details.Id)
                    .Select(j => j.Quantity >= questReward.Quantity)
                    .FirstOrDefault();
            }
            return false;
        }

        private static void InitiateDialog(Location newLocation)
        {
            Console.WriteLine("Do You want start Quest? ");
            var answer = Console.ReadLine();

            if (answer == "Y")
            {
                StartQuest(newLocation);
            }
            else
            {
                Console.WriteLine("Ready - but not decided for timeline");
            }
        }

        private static void StartQuest(Location newLocation)
        {
            foreach(QuestReward qci in newLocation.QuestAvailableHere.QuestCompletionItems)
            {
                foreach (var j in _player.Inventory
                    .Where(j => j.Details.Id == qci.Details.Id))
                {
                    // Subtract the quantity from the player's inventory that was needed to complete the quest
                    j.Quantity -= qci.Quantity;
                    break;
                }
            }
            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
            _player.Gold += newLocation.QuestAvailableHere.RewardGold;
            
            // Add the reward item to the player's inventory
            bool addedItemToPlayerInventory = false;

            foreach (var i in _player.Inventory
                .Where(i => i.Details.Id == newLocation.QuestAvailableHere.RewardItem.Id))
            {
                // They have the item in their inventory, so increase the quantity by one
                i.Quantity++;
                addedItemToPlayerInventory = true;
                break;
            }
            // They didn't have the item, so add it to their inventory, with a quantity of 1
            if(!addedItemToPlayerInventory)
            {
                _player.Inventory.Add(new QuestReward(newLocation.QuestAvailableHere.RewardItem, 1));
            }
            
            foreach(PlayerQuest pq in _player.Quests)
            {
                if(pq.Details.Id == newLocation.QuestAvailableHere.Id)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    break;
                }
            }
            
        }
    }
}