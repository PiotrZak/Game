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
            Location.MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            Location.MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            Location.MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            Location.MoveTo(_player.CurrentLocation.LocationToWest);
        }

        public void Start(Location newLocation)
        {

            _player.CurrentLocation = newLocation;
            HideImpossibleMoves(newLocation);

            Console.WriteLine(newLocation.Name);
            Console.WriteLine(newLocation.Description);

            Quest.CheckForQuestInNewLocation(newLocation);
            EnemyLocation.CheckForEnemy(newLocation);

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