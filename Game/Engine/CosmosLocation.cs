using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        public Fleet ActualFleetPosition;
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

    public class PopulateFleets()
    {
        
        public Map PopulateMap(List<Nation> nations, Map map)
        {
            var groupedFleetsbySpaceshipCounts = nations
                .GroupBy(x => x.Fleets)
                .OrderBy(group => group.First().Fleets.First().Spaceships.Count)
                .ToList();
            
            foreach(var fleet in groupedFleetsbySpaceshipCounts)
            {
                var randomPositionX = new Random().Next(0, 9);
                var randomPositionY = new Random().Next(0, 9);
                
                var cords = int.Parse(randomPositionX.ToString() + randomPositionY);
                map.Location[cords].ActualFleetPosition = fleet;
                var isSafePosition = CheckDistance(map, cords);
                
                while (!isSafePosition)
                {
                    
                }
            }

        }

        private bool CheckDistance(Map map, int cords)
        {
            //todo - check if there is 3x3 distance between another FleetLocation in LocationCordination object and corners
            foreach (var cord in map)
            {
                var leftTopCorner = map.Location[0];
                var rightTopCorner = map.Location[9]; 
                var leftBotCorner = map.Location[90];
                var rightBotCorner = map.Location[99];
            }
        }
        
        public void Right(Map map, Fleet unit, int fields)
        {

            var isCollision = CheckForCollision();

        }
        
        public void Left(Map map, Fleet unit, int fields){
    
        }
    
        public void Top(Map map, Fleet unit, int fields){
    
        }
    
        public void Down(Map map, Fleet unit, int fields){
    
        }
        
        private object CheckForCollision()
        {
            throw new NotImplementedException();
        }
        
    }
}

