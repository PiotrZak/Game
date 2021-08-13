using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Game.Engine
{
    public enum SpaceshipType
    {
        Chaser = 1,
        Shuttle = 2,
        Destroyer = 3,
        Dreadnought =4,
    }
    
    public class SpaceshipsFactory
    {

        public static List<Spaceship> BuildSpaceship(Nation builder, SpaceshipType typeToBuild, int quantity)
        {

            var chaserCost = new[] {4000, 2000, 1000};
            var shuttleCost = new[] {8000, 4000, 1800};
            var destroyerCost = new[] {18000, 12000, 4000};
            var dreadnoughtCost = new[] {40000, 20000, 6000};

            var spaceShips = new List<Spaceship>();

            if (typeToBuild == SpaceshipType.Chaser)
            {
                var availableSteel = builder.Steel;
                var availableAluminium = builder.Aluminium;
                var availableRocketPopulsion = builder.RocketPropulsion;

                var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};
                var demandsOfMaterials = chaserCost.Select(x => x * quantity).ToList();

                var isPossible = IsDemandFullfill(demandsOfMaterials, actualState);

                if (isPossible)
                {
                    for(var i = 0; i < quantity; i++)
                    {
                        var chaser = new Spaceship(builder, SpaceshipType.Chaser, 100, 20 ,1200, 60, 5, 120 );   
                        spaceShips.Add(chaser);
                    }
                }
                else
                {
                    CalculatePossibleQuantityBuild(demandsOfMaterials, actualState);
                }
            }
            return spaceShips;
        }

        public static int CalculatePossibleQuantityBuild(List<int> demandsOfMaterials, int[] actualState)
        {
            int possibleQuantity = 0;

            do
            {
                var oneUnit = IsDemandFullfill(demandsOfMaterials, actualState);
                if (oneUnit)
                {
                    possibleQuantity++;
                    actualState[0] -= demandsOfMaterials[0];
                    actualState[1] -= demandsOfMaterials[1];
                    actualState[2] -= demandsOfMaterials[2];
                }
            } while (!IsDemandFullfill(demandsOfMaterials, actualState) == false);
            
            return possibleQuantity;
        }

        public static bool IsDemandFullfill(List<int> cost, int[] actualState)
        {
            if (actualState[0] >= cost[0])
            {
                if (actualState[1] >= cost[1])
                {
                    if (actualState[2] >= cost[2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public static List<int> CalculateLackOfDemands(List<int> cost, int[] actualState)
        {
            var lackResources = new List<int>();
            foreach(var i in actualState.Select((value, index) => new { index, value }))
            {
                if (actualState[i.index] <= cost[i.index])
                {
                    var diff = cost[i.index] - actualState[i.index];
                    lackResources.Add(diff);
                }
            }
            return lackResources;
        }
    }
}