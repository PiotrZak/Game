using System.Collections.Generic;
using Game.Engine.Creatures;

namespace Game.Engine
{
    public class Spaceship
    {
        public string Nation { get; set; }
        public string Model { get; set; }
        public int Fuel { get; set; }
        public int Damage { get; set; }
        public int ShootAccuracy { get; set; }
        public int MaxCrewSize { get; set; }
        public int Speed { get; set; }
        private List<Player> Crew { get; set; }
        public Player Captain { get; set; }
        
        public void PromoteNewCaptain(Player player)
        {
            Captain = player;
        }
        
        public void AddPlayerToSpaceship(Player player)
        {
            Crew.Add(player);
        }
        
        public void RemovePlayerFromSpaceship(Player player)
        {
            Crew.Remove(player);
        }
        
    }
}