using System.Collections.Generic;
using Game.Engine.Creatures;

namespace Game.Engine
{
    
    public enum StrategyObjective
    {
        Navigator,
        Transport,
    }

    public enum Formation
    {
        Corps,
        Division,
        Brigade,
        Unknown
    }
    
    public class Fleet
    {
        public Fleet(
            Nation nation, 
            Player general,
            List<Player> captains,
            Formation formation,
            StrategyObjective strategyObjective,
            List<Spaceship> spaceships
        )
        {
            Nation = nation;
            General = general;
            Captains = captains;
            Formation = formation;
            StrategyObjective = strategyObjective;
            Spaceships = spaceships;
        }
        
        public Nation Nation { get; set; }
        public Player General { get; set; }
        public List<Player> Captains { get; set; }
        public Formation Formation;
        public StrategyObjective StrategyObjective;
        public List<Spaceship> Spaceships { get; set; }
        
    }
}