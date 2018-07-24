using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public enum GameStates { Title, Demo, Playing, Pause, LevelComplete, GameComplete,
    LifeDisplay, GameOver, Competitive, CompetitivePreparing, CompetitiveEnding,
    CompetitivePause
    }

    public interface IGameState
    {
        GameStates Type { get; }
        void Proceed();
        void PlayDemo();
        void Pause();
        void MarioDied();
        void GameOver();
    }
}
