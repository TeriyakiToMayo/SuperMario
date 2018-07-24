using Sprint1Game.DisplayPanel;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.GameStates
{
    public class CompetitivePreparingState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.CompetitivePreparing;
            }
        }

        public CompetitivePreparingState(AbstractGame game)
        {
            this.game = game;
            MarioAttributes.ResetTimerForCompetitive();
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
            game.State = new CompetitiveState(game);
        }
    }
}
