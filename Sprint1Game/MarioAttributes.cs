using Microsoft.Xna.Framework;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sprint1Game
{
    static class MarioAttributes
    {
        public static int[] MarioLife { get; } = {3, 3};

        public static int Time { get; set; } = 0;
        public static int HighestScore { get; set; } = 0;

        private static int counter = 0;
        private static bool isTimeTicking = false;

        public static void UpdateHighestScore()
        {
            if(ScoringSystem.Player1Score.Score > HighestScore)
            {
                HighestScore = ScoringSystem.Player1Score.Score;
            }
        }

        public static void ResetTimer()
        {
            Time = GameUtilities.MaxTime;
            isTimeTicking = false;
        }

        public static void ResetTimerForCompetitive()
        {
            Time = GameUtilities.MaxCompetitiveTime;
            isTimeTicking = false;
        }

        public static void ClearTimer()
        {
            Time = 0;
            isTimeTicking = false;
        }

        public static void StartTimer()
        {
            isTimeTicking = true;
        }

        public static void StopTimer()
        {
            isTimeTicking = false;
        }

        public static void tick(GameTime gameTime)
        {
            if (isTimeTicking)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter >= GameUtilities.OneSecondOfMilliseconds)
                {
                    Time--;
                    counter = 0;
                }
                if(Time == 0)
                {
                    isTimeTicking = false;
                    if (GameUtilities.Game.State.Type == Interfaces.GameStates.Competitive)
                    {
                        GameUtilities.Game.State.GameOver();
                        return;
                    }
                    GameUtilities.GameObjectManager.MarioPlayer1.State.Terminated();
                    
                }
            }
        }
    }
}
