using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.GameStates
{
    public class PlayingState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.Playing;
            }
        }

        public PlayingState(AbstractGame game)
        {
            this.game = game;
        }

        public void GameOver()
        {
            game.State = new GameOverState(game);
        }

        public void MarioDied()
        {
            game.State = new LifeDisplayState(game);
        }

        public void Pause()
        {
            game.State = new PauseState(game);
        }

        public void PlayDemo()
        {

        }

        public void Proceed()
        {
            game.State = new LevelCompleteState(game);
        }
    }
}
