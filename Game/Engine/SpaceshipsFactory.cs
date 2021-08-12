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

        public List<Spaceship> BuildSpaceship(Nation builder, SpaceshipType typeToBuild, decimal quantity)
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
                var demandsOfMaterials = chaserCost.Select(x => x * quantity);

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
                    CalculatePossibleQuantityBuild(demandsOfMaterials, actualState, quantity);
                }
            }
            return spaceShips;
        }

        private int CalculatePossibleQuantityBuild(IEnumerable<decimal> demandsOfMaterials, decimal[] actualState, in decimal quantity)
        {
            int possibleQuantity = 0;
            var ofMaterials = demandsOfMaterials.ToList();
            
            while (IsDemandFullfill(ofMaterials, actualState) == false)
            {
                var oneUnit = IsDemandFullfill(ofMaterials, actualState);
                if (oneUnit == true)
                {
                    possibleQuantity++;
                    actualState[0] -= ofMaterials[0];
                    actualState[1] -= ofMaterials[1];
                    actualState[2] -= ofMaterials[2];
                }
            }
            return possibleQuantity;
        }

        public bool IsDemandFullfill(IEnumerable<decimal> cost, decimal[] actualState)
        {
            var enumerable = cost.ToList();
            if (actualState[0] < enumerable[0] ||
                actualState[1] < enumerable[1] ||
                actualState[2] < enumerable[2]
            )
            {
                var exception = new Exception("Nation have not enough materials");
                return false;
            }

            return true;
        }
        
        public void RecruitTheCrew()
        {
            
        }
    }
}