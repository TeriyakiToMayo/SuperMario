using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.GameStates
{
    public class CompetitiveState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.Competitive;
            }
        }

        public CompetitiveState(AbstractGame game)
        {
            this.game = game;
            MarioAttributes.StartTimer();
        }

        public void GameOver()
        {
            game.State = new CompetitiveEndingState(game);
        }

        public void MarioDied()
        {

        }

        public void Pause()
        {
            game.State = new CompetitivePauseState(game);
        }

        public void PlayDemo()
        {

        }

        public void Proceed()
        {
            
        }
    }
}
