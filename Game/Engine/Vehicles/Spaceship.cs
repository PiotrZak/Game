using System.Collections.Generic;
using Game.Engine.Creatures;
    
namespace Game.Engine
{
    //todo - abstract class of different models of spaceships
    public class Spaceship
    {
        public string Nation { get; set; }
        public string Model { get; set; }
        public int Fuel { get; set; }
        public int Damage { get; set; }
        public int ProtectiveField { get; set; }
        public int Health { get; set; }
        public decimal ShootAccuracy { get; set; }
        public int MaxCrewSize { get; set; }
        public int Speed { get; set; }
        public List<Player> Crew { get; set; }
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