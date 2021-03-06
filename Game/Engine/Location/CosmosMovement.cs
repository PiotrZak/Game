using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Engine
{
    public class CosmosMovement
    {
        public enum DirectionType
        {
            Top = 1,
            Right = 2,
            Down = 3,
            Left = 4,
        }
        
        public Map Move (Map map, Fleet unit, DirectionType direction, int fields)
        {
            Map updatedMap;
            switch (direction)
            {
                // case DirectionType.Top:
                //     updatedMap = Top(map, unit, fields);
                //     break;
                case DirectionType.Right:
                    updatedMap = Right(map, unit, fields);
                    break;
                // case DirectionType.Down:
                //     updatedMap = Down(map, unit, fields);
                //     break;
                // case DirectionType.Left:
                //     updatedMap = Left(map, unit, fields);
                //     break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(DirectionType), direction, null);
            }

            return updatedMap;
        }

        private Map Right(Map map, Fleet unit, int fields)
        {
            var fleetId = unit.Id;
            var actualFleetPosition = map.Location
                .Find(x => x.ActualFleetPosition.Id == fleetId);
            
            if (actualFleetPosition == null) return map;
            
            var postulatedFleetPosition = new LocationCoordinate(actualFleetPosition.X, actualFleetPosition.Y+fields);
            
            var isCollision = CheckForCollision(map, unit, actualFleetPosition, postulatedFleetPosition);

            map = !isCollision ? 
                UpdatePosition(map, actualFleetPosition, postulatedFleetPosition, unit) 
                : map;

            return map;
        }
        
        public void Left(Map map, Fleet unit, int fields){
    
        }
    
        public void Top(Map map, Fleet unit, int fields){
    
        }
    
        public void Down(Map map, Fleet unit, int fields){
    
        }
        
        //todo - make tests for that
        private static Map UpdatePosition(Map map, LocationCoordinate? actualFleetPosition, LocationCoordinate postulatedFleetPosition, Fleet unit)
        {
            var startPosition = map.Location.FirstOrDefault(x => x == actualFleetPosition);
            if (startPosition != null) startPosition.ActualFleetPosition = null;
            var finishPosition = map.Location.FirstOrDefault(x => x == postulatedFleetPosition);
            if (finishPosition != null) finishPosition.ActualFleetPosition = unit;
            
            return map;
        }

        //todo - precise and refactor
        public static bool CheckForCollision(Map map, Fleet fleet, LocationCoordinate actualFleetPosition, LocationCoordinate postulatedFleetPosition)
        {

            var fromX = actualFleetPosition.X;
            var fromY = actualFleetPosition.Y;
            var toX = postulatedFleetPosition.X;
            var toY = postulatedFleetPosition.Y;
            
            if (fromY + toY >= 10)
            {
                //5 to 10 - then 5,6,7,8,9 
                var fieldsVisited = Enumerable
                    .Range(fromX, toX)
                    .ToList();
                
                foreach (var field in fieldsVisited)
                {
                    var locationCoordinates = map.Location
                        .FirstOrDefault(position => position.Y == fromY && position.X == field);

                    //check actual field - todo - check from range - fieldsVisited
                    if (locationCoordinates?.ActualFleetPosition != null)
                    {

                        if (locationCoordinates.ActualFleetPosition.Nation.Enemies != null)
                        {

                            var enemiesOfFleet = locationCoordinates.ActualFleetPosition.Nation.Enemies
                                .Select(x => x.Id)
                                .ToList();

                            if (enemiesOfFleet.Contains(fleet.Id))
                            {
                                FleetBattle.Encounter(locationCoordinates.ActualFleetPosition, fleet);
                            }
                        }

                        if (locationCoordinates.ActualFleetPosition.Nation.Alliances != null)
                        {
                            var alliesOfFleet = locationCoordinates.ActualFleetPosition.Nation.Alliances
                                .Select(x => x.Id)
                                .ToList();

                            if (alliesOfFleet.Contains(fleet.Id))
                            {
                                TradeLogic.FleetTrade.Trade(locationCoordinates.ActualFleetPosition, fleet);
                            }
                        }
                        
                        //neutral fleet meet
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
        
    }
}