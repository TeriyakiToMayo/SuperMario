using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.UtilitiesClasses
{
    public static class HUDUtilities
    {
        public static int MaxCoin { get; } = 99;
        public static int InitialStompScore { get; } = 100;
        public static int DoubleStompScore { get; } = 200;
        public static int InitialShellHitScore { get; } = 500;
        public static int InitialShellKickScore { get; } = 400;
        public static int InAirAfterMakingShellKickScore { get; } = 500;
        public static int Stomp2ComboScore { get; } = 200;
        public static int Stomp3ComboScore { get; } = 400;
        public static int Stomp4ComboScore { get; } = 500;
        public static int Stomp5ComboScore { get; } = 800;
        public static int Stomp6ComboScore { get; } = 1000;
        public static int Stomp7ComboScore { get; } = 2000;
        public static int Stomp8ComboScore { get; } = 4000;
        public static int Stomp9ComboScore { get; } = 5000;
        public static int ShellHit2ComboScore { get; } = 800;
        public static int ShellHit3ComboScore { get; } = 1000;
        public static int ShellHit4ComboScore { get; } = 2000;
        public static int ShellHit5ComboScore { get; } = 4000;
        public static int ShellHit6ComboScore { get; } = 5000;
        public static int ShellHitComboScores { get; } = 7;
        public static int StompComboScores { get; } = 10;

        public static int BreakingBlockScore { get; } = 50;
        public static int ItemCollectedScore { get; } = 1000;
        public static int CoinCollectedScore { get; } = 200;
        public static int SecondBonusScore { get; } = 10;
        public static int EnemyBelowBlockHitScore { get; } = 100;
        public static int SpecialGoombaHitScore { get; } = 100;
        public static int SpecialKoopaHitScore { get; } = 200;
        public static int Pole1Score { get; } = 5000;
        public static int Pole2Score { get; } = 2000;
        public static int Pole3Score { get; } = 800;
        public static int Pole4Score { get; } = 400;
        public static int Pole5Score { get; } = 100;
        public static int Pole1Cutoff { get; } = 1;
        public static int Pole2Cutoff { get; } = 4;
        public static int Pole3Cutoff { get; } = 5;
        public static int Pole4Cutoff { get; } = 8;
        public static string AddLifeString { get; } = "1UP";

        public const int DistanceOfFirstRowText = 10;
        public const int DistanceOfSecondRowText  = 20;
        public const int ScoreLength = 6;
        public const int CoinLength = 2;
        public const int TimeLength = 3;
        public const int Fifths = 5;
        public const string Mario = "MARIO";
        public const string MultiplicationSign = "*";
        public const string World = "WORLD";
        public const string Level = "1-1";
        public const string Time = "TIME";
        public const string Zero = "0";
    }
}
