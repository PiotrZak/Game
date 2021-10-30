using System;
using System.Collections;
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

        public class SpaceshipOrder
        {
            public SpaceshipType SpaceshipType { get; set; }
            public int Quantity { get; set; }
        }

        public static List<Spaceship> BuildSpaceship(Nation builder, List<SpaceshipOrder> orders)
        {

            var chaserCost = new[] { 4000, 2000, 1000 };
            var shuttleCost = new[] { 8000, 4000, 1800 };
            var destroyerCost = new[] { 18000, 12000, 4000 };
            var dreadnoughtCost = new[] { 50000, 20000, 6000 };

            var spaceShips = new List<Spaceship>();


            foreach (var order in orders)
            {
                var availableSteel = builder.Steel;
                var availableAluminium = builder.Aluminium;
                var availableRocketPopulsion = builder.RocketPropulsion;

                var actualState = new[] { availableSteel, availableAluminium, availableRocketPopulsion };
                var demandsOfMaterials = order.SpaceshipType switch
                {
                    Engine.SpaceshipType.Chaser => chaserCost.Select(x => x * order.Quantity).ToList(),
                    Engine.SpaceshipType.Shuttle => shuttleCost.Select(x => x * order.Quantity).ToList(),
                    Engine.SpaceshipType.Destroyer => destroyerCost.Select(x => x * order.Quantity).ToList(),
                    Engine.SpaceshipType.Dreadnought => dreadnoughtCost.Select(x => x * order.Quantity).ToList(),
                    _ => throw new ArgumentOutOfRangeException(nameof(order.SpaceshipType), order.SpaceshipType, null)
                };

                var isPossible = IsDemandFullfill(demandsOfMaterials, actualState);
                if (isPossible)
                {
                    var spaceshipsRanges = Enumerable.Range(0, order.Quantity).Select(x => new Spaceship(Guid.NewGuid(), builder, order.SpaceshipType, 100, 20, 1200, 60, 5, 120)).ToList();
                    builder.Steel -= demandsOfMaterials[0];
                    builder.Aluminium -= demandsOfMaterials[1];
                    builder.RocketPropulsion -= demandsOfMaterials[2];
                    spaceShips.AddRange(spaceshipsRanges);
                    
                }
                else
                {
                    var resourcePossibility = CalculatePossibleQuantityBuild(demandsOfMaterials, actualState);
                }
            }

            return spaceShips;
        }
        

        public static IEnumerable SpaceshipType { get; set; }

        public static int CalculatePossibleQuantityBuild(List<int> demandsOfMaterials, int[] actualState)
        {
            var possibleQuantity = 0;
            do
            {
                var oneUnit = IsDemandFullfill(demandsOfMaterials, actualState);
                if (oneUnit)
                {
                    possibleQuantity++;
                    foreach(var i in actualState.Select((value, index) => new { index, value }))
                    {
                        actualState[i.index] -= demandsOfMaterials[i.index];
                    }
                }
            } while (!IsDemandFullfill(demandsOfMaterials, actualState) == false);
            
            return possibleQuantity;
        }

        public static bool IsDemandFullfill(List<int> cost, int[] actualState)
        {
            if (actualState[0] < cost[0]) return false;
            if (actualState[1] < cost[1]) return false;
            return actualState[2] >= cost[2];
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