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
            foreach(ItemState qci in newLocation.QuestAvailableHere.QuestCompletionItems)
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
            
            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);
            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);
        }
    }
}