using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine;

namespace Game
{
    public class FleetBattle()
    {
        public decimal FindDifference(decimal nr1, decimal nr2)
        {
            return Math.Abs(nr1 - nr2);
        }

        public void Encounter(Fleet a, Fleet b)
        {

            var shipsA = (decimal)a.Spaceships.Count;
            var shipsB = (decimal)b.Spaceships.Count;
                
            var damageShipsA = a.Spaceships.Sum(x => x.Damage);
            var damageShipsB = b.Spaceships.Sum(x => x.Damage);

            var crewA = a.Spaceships.Sum(x => x.Crew.Count);
            var crewB = a.Spaceships.Sum(x => x.Crew.Count);
            
            var differenceInShips = FindDifference(shipsA, shipsB);
            var differenceInCrew = FindDifference(crewA, crewB);

            var meanOfAccuracyA = CalculateAccuracy(a.Spaceships);
            var probabilityResult = CalculateProbabilityOfFight(differenceInShips, differenceInCrew);

            var battleOfUnit = new SpaceshipsBattle.StartBattle(a.Spaceships[0], b.Spaceships[0]);
        }

        private decimal CalculateAccuracy(IEnumerable<Spaceship> spaceships)
        {
            return spaceships.Average(x => x.ShootAccuracy);
        }

        private object CalculateProbabilityOfFight(decimal differenceInShips, decimal differenceInCrew)
        {
        }
        
        public void Mediation(Fleet a, Fleet b)
        {
    }
}