using System;
using System.Threading.Tasks;
using Game.Engine;
using Game.Engine.Creatures;

namespace Game
{
    public class GameLoop
    {
        public static Game _game;
        private static bool Running { get; set; }
        
        public static async void Start()
        {
            if (_game == null)
                throw new ArgumentException("Game not loaded!");
            
            //todo - load player from save or start from beggining
            var player = new Player(
                10,
                10,
                20,
                0,
                "You",
                100,
                5,
                10);
            
            
            Game.Start(player, World.LocationById(World.LocationMachinery));
            Running = true;
            
            
            var previousGameTime = DateTime.Now;

            while (Running)
            {
                var gameTime = DateTime.Now - previousGameTime;
                previousGameTime += gameTime;
                
                //decide if graphical interface or just CLI
                const string move = "north";
                Update(move, player);
                await Task.Delay(8);
            }
        }

        private static void Update(string move, Player player)
        {
            switch (move)
            {
                case "north":
                    Location.MoveTo(player.CurrentLocation.LocationToNorth);
                    break;
                case "east":
                    Location.MoveTo(player.CurrentLocation.LocationToEast);
                    break;
                case "south":
                    Location.MoveTo(player.CurrentLocation.LocationToSouth);
                    break;
                case "west":
                    Location.MoveTo(player.CurrentLocation.LocationToWest);
                    break;
            }
        }

        private static void End()
        {
            Console.WriteLine("You are dead");
        }
        
        public static void Restart()
        {
            Running = false;
            End();
            Start();
        }
    }
}