﻿using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.GameStates
{
    public class CompetitiveEndingState : IGameState
    {
        private AbstractGame game;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.CompetitiveEnding;
            }
        }

        public CompetitiveEndingState(AbstractGame game)
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
            game.State = new TitleState(game);
        }
    }
}
