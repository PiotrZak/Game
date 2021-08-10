using System.Collections.Generic;
using Game.Engine.Creatures;

namespace Game.Engine
{
    public class Fleet_
    {
        public Player General { get; set; }
        
        public List<Player> Captains { get; set; }

        public string Formation;

        public string StrategyObjective;
        
        private List<Nation> Alliances;

        private List<Nation> War;
        
        public void DeclareWar(Nation nation)
        {
            Alliances.Add(nation);
        }
        
        public void MakeAnAlliance(Nation nation)
        {
            War.Add(nation);
        }
    }

    public class Nation
    {
        public string Name;
    }
}