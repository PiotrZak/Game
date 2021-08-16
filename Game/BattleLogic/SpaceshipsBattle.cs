using System.Collections.Generic;
using Game.Engine;

namespace Game
{
    public class SpaceshipsBattle
    {

        public class StartBattle
        {
            public List<Spaceship> StartBattle(Spaceship a, Spaceship b)
            {
                while (!(a.Health <= 0) && !(b.Health <= 0))
                {
                    Attack.Hit(a.Damage, a.ShootAccuracy, b.Health,  null, a.Health);
                    Attack.Hit(b.Damage, b.ShootAccuracy, a.Health,  null, b.Health);

                    //todo - refactor
                    if (a.Health == 100)
                    {
                        var isFlied = FlyAway(a, b);
                        var isAgreed = Negotiate(a, b);
                    }

                    if (b.Health == 100)
                    {
                        var isFlied = FlyAway(b, a);
                        var isAgreed = Negotiate(b, a);
                    }
                    
                }
            }

            private static bool FlyAway(Spaceship runner, Spaceship attacker)
            {
                if (runner.Speed > attacker.Speed)
                {
                    
                }

                return false;
            }

            private static bool Negotiate(Spaceship negotiator, Spaceship attacker)
            {
                //correlate with nation and raw metrials, political impact
                // BATNA - best alternative to a negotiated agreement
                return true;
            }
        }
    }
}