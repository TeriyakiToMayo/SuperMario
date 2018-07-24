using Sprint1Game.Interfaces;
using Sprint1Game.UtilitiesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.HeadsUp
{
    public class ScoringComboManager
    {
        
        private static Dictionary<IGameObject, int>[] koopaKickedShells = { new Dictionary<IGameObject, int>(), new Dictionary<IGameObject, int>() };
        private int stompedEnemiesInSequence;
        public bool HitEnemyAlreadyThisIteration { get; set; } = false;
        private bool isMarioInAir;
        public bool IsMarioAirbourne
        {
            get { return isMarioInAir; }
            set
            {
                if (!value)
                    stompedEnemiesInSequence = 0;
                isMarioInAir = value;
            }
        }

        public ScoringComboManager(IMario mario)
        {
            this.stompedEnemiesInSequence = 0;
            this.isMarioInAir = mario.IsInAir;
        }

        public int DetermineDoubleStompSequence()
        {
            int scoreToAdd = HUDUtilities.InitialStompScore;
            if (HitEnemyAlreadyThisIteration)
                scoreToAdd = HUDUtilities.DoubleStompScore;
            HitEnemyAlreadyThisIteration = true;
            return scoreToAdd;
        }

        public int DetermineStompSequence(int player)
        {
            int scoreToAdd = DetermineDoubleStompSequence();
            if (scoreToAdd == HUDUtilities.InitialStompScore && isMarioInAir)
            {
                switch (stompedEnemiesInSequence % HUDUtilities.StompComboScores)
                {
                    case 0:
                        scoreToAdd = HUDUtilities.InitialStompScore;
                        break;
                    case 1:
                        scoreToAdd = HUDUtilities.Stomp2ComboScore;
                        break;
                    case 2:
                        scoreToAdd = HUDUtilities.Stomp3ComboScore;
                        break;
                    case 3:
                        scoreToAdd = HUDUtilities.Stomp4ComboScore;
                        break;
                    case 4:
                        scoreToAdd = HUDUtilities.Stomp5ComboScore;
                        break;
                    case 5:
                        scoreToAdd = HUDUtilities.Stomp6ComboScore;
                        break;
                    case 6:
                        scoreToAdd = HUDUtilities.Stomp7ComboScore;
                        break;
                    case 7:
                        scoreToAdd = HUDUtilities.Stomp8ComboScore;
                        break;
                    case 8:
                        scoreToAdd = HUDUtilities.Stomp9ComboScore;
                        break;
                    case 9:
                        MarioAttributes.MarioLife[player]++;
                        scoreToAdd = 0;
                        break;
                    default:
                        break;
                }
            }
            isMarioInAir = true;
            stompedEnemiesInSequence++;
            return scoreToAdd;
        }

        public int DetermineShellHitSequence(IGameObject koopa, int player)
        {
            this.ToString();
            int scoreToAdd = 0;
            if (koopaKickedShells[player].ContainsKey(koopa))
                scoreToAdd = ShellHitComboScore(koopa, player);
            else if (koopaKickedShells[(player + 1) % GameUtilities.Players].ContainsKey(koopa))
                scoreToAdd = -1 * ShellHitComboScore(koopa, (player + 1) % GameUtilities.Players);
            return scoreToAdd;
        }

        public int DetermineShellInitializationSequence(IGameObject koopa, int player)
        {
            int scoreToAdd = HUDUtilities.InitialShellKickScore;
            if (!koopaKickedShells[player].ContainsKey(koopa))
            {
                koopaKickedShells[player].Add(koopa, 0);
                if (koopaKickedShells[(player + 1) % GameUtilities.Players].ContainsKey(koopa))
                    koopaKickedShells[(player + 1) % GameUtilities.Players].Remove(koopa);
            }
            if (isMarioInAir)
                scoreToAdd = HUDUtilities.InAirAfterMakingShellKickScore;
            return scoreToAdd;
        }

        private static int ShellHitComboScore(IGameObject koopa, int player)
        {
            int scoreToAdd = 0;
            switch (koopaKickedShells[player][koopa] % HUDUtilities.ShellHitComboScores)
            {
                case 0:
                    scoreToAdd = HUDUtilities.InitialShellHitScore;
                    break;
                case 1:
                    scoreToAdd = HUDUtilities.ShellHit2ComboScore;
                    break;
                case 2:
                    scoreToAdd = HUDUtilities.ShellHit3ComboScore;
                    break;
                case 3:
                    scoreToAdd = HUDUtilities.ShellHit4ComboScore;
                    break;
                case 4:
                    scoreToAdd = HUDUtilities.ShellHit5ComboScore;
                    break;
                case 5:
                    scoreToAdd = HUDUtilities.ShellHit6ComboScore;
                    break;
                case 6:
                    MarioAttributes.MarioLife[player]++;
                    break;
                default:
                    break;
            }
            koopaKickedShells[player][koopa]++;
            return scoreToAdd;
        }
    }
}
