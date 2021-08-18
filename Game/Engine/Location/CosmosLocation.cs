#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Game.Engine;

namespace Game.Engine
{

    public class LocationCoordinate
    {
        public LocationCoordinate( int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public Fleet? ActualFleetPosition { get; set; }

        public bool IsPositionEmpty()
        {
            return ActualFleetPosition == null;
        }
    }
    
    
    //todo - take for consideration 2-dimensional array
    //int[,] Coords;
    public class Map
    {
        public Map(List<LocationCoordinate> location)
        {
            Location = location;
        }
        public List<LocationCoordinate> Location { get; set; }
    }
    
    public class CosmosLocation
    {
        public static Map GenerateMap()
        {
            var A1 = new Map(new List<LocationCoordinate>());
            
            for(var i = 1; i <= 10; i++)
            {
                for(var j = 1; j <= 10; j++)
                {
                    var point = new LocationCoordinate(i, j);
                    A1.Location.Add(point);
                }
                Console.WriteLine();
            }

            return A1;
        }
    }

    public class PopulateFleets
    {
        public Map PopulateMap(List<Nation> nations, Map map)
        {
            var groupedFleetsbySpaceshipCounts = nations
                .GroupBy(x => x.Fleets)
                .OrderBy(group => group.First().Fleets.First().Spaceships.Count)
                .ToList();

            var random = new Random();
            var i = 0;
            foreach (var fleet in groupedFleetsbySpaceshipCounts)
            {
                int coords;
                do {
                    var randomPositionX = random.Next(0, 9);
                    var randomPositionY = random.Next(0, 9);

                    coords = 10 * randomPositionX + randomPositionY;
                } while (!IsPositionAllowed(map, coords));

                map.Location[coords].ActualFleetPosition = fleet.Key[i];
                i++;
            }

            return map;
        }
        
        private bool IsPositionAllowed(Map map, int cords)
        {
            //todo - check if there is 3x3 distance between another FleetLocation in LocationCordination object and corners
            
            return map.Location[cords].IsPositionEmpty();;
        }
    }
}

