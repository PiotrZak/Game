using System;

namespace Game
{
    public class Attack
    {
        public static decimal? Hit(int dmg, decimal accuracy, int underAttackHealth,int? defense = null, int? protectiveField = null)
        {
            var gen = new Random();
            var aimed = IsAimed(accuracy);

            if (aimed)
            {
                if (protectiveField != null && protectiveField <= 0)
                {
                    return (decimal) (protectiveField - (dmg - defense));
                }
                return underAttackHealth - (dmg);  
            }
            return null;
        }

        private static bool IsAimed(decimal accuracy)
        {
            var gen = new Random();
            var prob = gen.Next(100);
            return prob <= accuracy;
        }
    }
}