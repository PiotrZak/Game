using System.Collections.Generic;
using Game.Engine.Creatures;

namespace Game.Engine
{
    public class Fleet
    {
        public Player General { get; set; }
        
        public List<Player> Captains { get; set; }

        public string Formation;

        public string StrategyObjective;
        
        public List<Spaceship> Spaceships { get; set; }
        
        private List<Nation> Alliances;

        private List<Nation> War;
        
        public void DeclareWar(Nation nation)
        {
            War.Add(nation);
        }
        
        public void MakeAnAlliance(Nation nation)
        {
            Alliances.Add(nation);
        }
    }
}