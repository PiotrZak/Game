using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine.Creatures;

namespace Game.Engine
{

    
    public class FleetsFactory
    {
        public static Fleet OrganizeFleet(List<Spaceship> spaceships, List<Player> management, Nation nation)
        {

            var strategyObjective = DefineObjective();
            var formation = DefineFormation(spaceships.Count);
            var general = PromoteGeneral(management);
            management.RemoveAll(x => x.Id == general.Id);
            
            return new Fleet(nation, general, management, formation, strategyObjective, spaceships);
        }

        private static Formation DefineFormation(int spaceshipsCount)
        {
            if (spaceshipsCount < 5)
            {
                return Formation.Corps;
            }

            if (spaceshipsCount < 10)
            {
                return Formation.Brigade;
            }

            if (spaceshipsCount < 15)
            {
                return Formation.Division;
            }

            return Formation.Unknown;
        }

        private static Player PromoteGeneral(List<Player> management)
        {
            return management.OrderByDescending(x => x.Charisma).First();
        }

        private static StrategyObjective DefineObjective()
        {
            var max = Enum.GetValues(typeof(StrategyObjective)).Length;
            return (StrategyObjective)new Random().Next(0, max - 1);
        }
    }
}