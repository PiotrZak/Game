using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Game.Engine
{
    public class Nation
    {
        public string Name { get; set; }

        public decimal Gold { get; set; }
        public int Steel { get; set; }
        public int RocketPropulsion { get; set; }
        public int Aluminium { get; set; }
        public List<Nation> Alliances { get; set; }
        public List<Nation> Enemies { get; set; }
        
        public List<Fleet> Fleets { get; set; }
        
        public void DeclareWar(Nation nation)
        {
            Enemies.Add(nation);
        }
        
        public void MakeAnAlliance(Nation nation)
        {
            Alliances.Add(nation);
        }
        
    }
    
}