using System;
using Game.Engine;
using Game.Engine.Creatures;

namespace Game
{
    public class Game
    {
        public Game() { }
        
        public static void Start(Player player, Location newLocation)
        {
            player.CurrentLocation = newLocation;
            Console.WriteLine(newLocation.Name);
            Console.WriteLine(newLocation.Description);

            Quest.CheckForQuestInNewLocation(newLocation);
            EnemyLocation.CheckForEnemy(newLocation);

            switch (player.Level)
            {
                case 5:
                    ChooseProffesion();
                    break;
                case 15:
                    ChooseSpecialization();
                    break;
            }
        }

        private static void ChooseSpecialization()
        {
        }

        private static void ChooseProffesion()
        {

        }
    }
}