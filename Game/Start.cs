using System;
using System.Linq;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Item.Abstraction;

namespace Game
{
    public class Game
    {
        private readonly Player _player;

        public Game()
        {
            _player = new Player(
                10,
                10,
                20,
                0,
                "You",
                100,
                5,
                10);
        }
        
        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void MoveTo(Location newLocation)
        {
            if (newLocation.AccessCode != null)
            {
                //todo - implement AccessCode mechanism also protection level, based on experience
            }

            if (newLocation.RequiredKey != null)
            {
                var playerHasKey = _player.Inventory.Cast<Item>().Any(key => key.Id == newLocation.RequiredKey.Id);

                if (!playerHasKey)
                {
                    //todo - configure writeln to RichTextBox if graphical
                    Console.WriteLine("Must have a " + newLocation.RequiredKey.Name + " to enter this location." + Environment.NewLine);
                    return;
                }
            }

            _player.CurrentLocation = newLocation;
            HideImpossibleMoves(newLocation);

            Console.WriteLine(newLocation.Name);
            Console.WriteLine(newLocation.Description);

            var isAvailableQuestHere = Quest.CheckForQuestInNewLocation(newLocation);
            // var isEnemyHere ?
            
        }



        private static void HideImpossibleMoves(Location newLocation)
        {
            //todo - ui controls if graphical
            // btnNorth.Visible = (newLocation.LocationToNorth != null);
            // btnEast.Visible = (newLocation.LocationToEast != null);
            // btnSouth.Visible = (newLocation.LocationToSouth != null);
            // btnWest.Visible = (newLocation.LocationToWest != null);
        }
    }
}