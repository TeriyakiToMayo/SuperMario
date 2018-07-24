using Microsoft.Xna.Framework;
using Sprint1Game.DisplayPanel;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.GameStates
{
    public class TitleState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.Title;
            }
        }

        public TitleState(AbstractGame game)
        {
            this.game = game;
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
            TitleDisplayPanel titlePanel = (TitleDisplayPanel)GameUtilities.GameObjectManager.TitlePanel;
            if (titlePanel.OptionNum == 0)
            {
                game.State = new LifeDisplayState(game);
            }
            else
            {
                game.State = new CompetitivePreparingState(game);
            }
        }
    }
}
