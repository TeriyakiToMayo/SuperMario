using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.GameStates
{
    public class LevelCompleteState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.LevelComplete;
            }
        }

        public LevelCompleteState(AbstractGame game)
        {
            this.game = game;
            SoundManager.Instance.StopAllSound();
            SoundManager.Instance.PlayStageClearSound();
        }

        public void GameOver()
        {

        }

        public void MarioDied()
        {

        }

        public void Pause()
        {

        }

        public void PlayDemo()
        {

        }

        public void Proceed()
        {
            game.State = new TitleState(game);
        }
    }
}
