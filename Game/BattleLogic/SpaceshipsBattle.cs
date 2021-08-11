using Game.Engine;

namespace Game
{
    public class SpaceshipsBattle
    {

        public class StartBattle
        {
            public StartBattle(Spaceship a, Spaceship b)
            {
                
                
                while (!(a.Health <= 0) && !(b.Health <= 0))
                {
                    Attack.Hit(a.Damage, a.ShootAccuracy, b.Health,  null, a.Health);
                    Attack.Hit(b.Damage, b.ShootAccuracy, a.Health,  null, b.Health);

                    if (a.Health == 100 || b.Health == 100)
                    {
                        //try to fly away
                        //mediate
                    }
                    
                }
            }
        }
    }
}