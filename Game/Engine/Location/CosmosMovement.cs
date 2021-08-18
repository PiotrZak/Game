using System;
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
            var actualFleetPosition = map.Location.Find(x => x.ActualFleetPosition.Id == fleetId);
            if (actualFleetPosition == null) return map;
            
            //right - is move on X or Y axis?
            var postulatedFleetPosition = new LocationCoordinate(actualFleetPosition.X, actualFleetPosition.Y+fields);
            
            var isCollision = CheckForCollision(actualFleetPosition, postulatedFleetPosition);

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
        public static bool CheckForCollision(LocationCoordinate actualFleetPosition, LocationCoordinate postulatedFleetPosition)
        {

            var fromX = actualFleetPosition.X;
            var fromY = actualFleetPosition.Y;
            var toX = postulatedFleetPosition.X;
            var toY = postulatedFleetPosition.Y;
        
            //only right for now
            
            // check if the fields allow another spaceships - if yes than start battle
            if (fromY + toY >= 10)
            {
                return false;
            }
        

            return true;

        }
        
    }
}