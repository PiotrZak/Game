using Game.Engine;
using Game.Engine.Creatures;

namespace Game
{
    public class Game
    {
        private Player _player;

        public Game()
        {
            
            _player = new Player(
                10,
                10,
                20,
                0,
                "Hero",
                100,
                5,
                10);
        }
    }
}