using System;
using System.Collections.Generic;
using System.Drawing;

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
    }
    
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
}

