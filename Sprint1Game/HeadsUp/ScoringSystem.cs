using Microsoft.Xna.Framework;
using Sprint1Game.Animation;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using Sprint1Game.UtilitiesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.HeadsUp
{
    public class ScoringSystem
    {
        private static Rectangle ZeroRectangle = new Rectangle(0, 0, 0, 0);
        private int score = 0;
        public int Score { get { return score; } }
        private ScoringComboManager comboManager;
        private List<IGameObject> poleParts;
        private IMario mario;
        protected Rectangle marioDestination
        {
            get
            {
                if (mario == null)
                    return ZeroRectangle;
                return mario.Destination;
            }
        }

        private static ScoringSystem[] playerScores = { new ScoringSystem(), new ScoringSystem() };
        public static ScoringSystem Player1Score { get { return playerScores[GameUtilities.Player1]; } }
        public static ScoringSystem Player2Score { get { return playerScores[GameUtilities.Player2]; } }

        private ScoringSystem()
        {
            this.poleParts = new List<IGameObject>();
        }
        public static ScoringSystem PlayerScore(int player)
        {
            return playerScores[player];
        }
        public void RegisterMario(IMario mario_)
        {
            this.comboManager = new ScoringComboManager(mario_);
            this.mario = mario_;
        }
        public IGameObject RegisterPole(IGameObject pole)
        {
            this.poleParts.Add(pole);
            return pole;
        }
        public void ResetScore()
        {
            score = 0;
        }
        protected void AddToScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }

        public static void AddPointsForBreakingBlock(IGameObject block)
        {
            ClosestMarioScoringSystem(block).AddToScore(HUDUtilities.BreakingBlockScore);
        }
        public static void AddPointsForCollectingItem(IGameObject item)
        {
            ClosestMarioScoringSystem(item).AddToScore(HUDUtilities.ItemCollectedScore);
            CreateNewScoreAnimation(item, HUDUtilities.ItemCollectedScore);
        }
        public static void AddPointsForCoin(IGameObject item)
        {
            ClosestMarioScoringSystem(item).AddToScore(HUDUtilities.CoinCollectedScore);
            CreateNewScoreAnimation(item, HUDUtilities.CoinCollectedScore);
        }
        public void AddPointsForRestTime()
        {
            score += HUDUtilities.SecondBonusScore;
            SoundManager.Instance.PlayCoinSound();
        }
        public void AddPointsForStompingEnemy(IGameObject enemy)
        {
            int scoreToAdd = comboManager.DetermineStompSequence(mario.Player);
            if (scoreToAdd > 0)
            {
                score += scoreToAdd;
                CreateNewScoreAnimation(enemy, scoreToAdd);
            }
            else
                CreateNewScoreAnimation(enemy, HUDUtilities.AddLifeString);
        }
        public void AddPointsForEnemyBelowBlockHit(IGameObject enemy)
        {
            ClosestMarioScoringSystem(enemy).AddToScore(HUDUtilities.EnemyBelowBlockHitScore);
            CreateNewScoreAnimation(enemy, HUDUtilities.EnemyBelowBlockHitScore);
            this.ToString();
        }
        public void AddPointsForSpecialGoombaHit(IGameObject goomba)
        {
            score += HUDUtilities.SpecialGoombaHitScore;
            CreateNewScoreAnimation(goomba, HUDUtilities.SpecialGoombaHitScore);
        }
        public static void AddPointsForFireballGoombaHit(IGameObject goomba, int player)
        {
            playerScores[player].AddToScore(HUDUtilities.SpecialGoombaHitScore);
            CreateNewScoreAnimation(goomba, HUDUtilities.SpecialGoombaHitScore);
        }
        public void AddPointsForSpecialKoopaHit(IGameObject koopa)
        {
            score += HUDUtilities.SpecialKoopaHitScore;
            CreateNewScoreAnimation(koopa, HUDUtilities.SpecialKoopaHitScore);
        }
        public static void AddPointsForFireballKoopaHit(IGameObject koopa, int player)
        {
            playerScores[player].AddToScore(HUDUtilities.SpecialKoopaHitScore);
            CreateNewScoreAnimation(koopa, HUDUtilities.SpecialKoopaHitScore);
        }
        public void AddPointsForInitiatingShell(IGameObject enemy)
        {
            int scoreToAdd = comboManager.DetermineShellInitializationSequence(enemy, mario.Player);
            score += scoreToAdd;
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForEnemyHitByShell(IGameObject enemy)
        {
            int scoreToAdd = comboManager.DetermineShellHitSequence(enemy, mario.Player);
            if (scoreToAdd > 0)
                score += scoreToAdd;
            else if (scoreToAdd == 0)
            {
                CreateNewScoreAnimation(enemy, HUDUtilities.AddLifeString);
                return;
            }
            else
            {
                scoreToAdd *= -1;
                playerScores[(mario.Player + 1) % GameUtilities.Players].AddToScore(scoreToAdd);
            }
            CreateNewScoreAnimation(enemy, scoreToAdd);
        }
        public void AddPointsForFinalPole(Rectangle marioDestination)
        {
            int scoreToAdd = HUDUtilities.Pole5Score;
            if (marioDestination.Y < poleParts[HUDUtilities.Pole1Cutoff].Destination.Y)
            {
                scoreToAdd = HUDUtilities.Pole1Score;
            }
            else if (marioDestination.Y < poleParts[HUDUtilities.Pole2Cutoff].Destination.Y)
            {
                scoreToAdd = HUDUtilities.Pole2Score;
            }
            else if (marioDestination.Y < poleParts[HUDUtilities.Pole3Cutoff].Destination.Y)
            {
                scoreToAdd = HUDUtilities.Pole3Score;
            }
            else if (marioDestination.Y < poleParts[HUDUtilities.Pole4Cutoff].Destination.Y)
            {
                scoreToAdd = HUDUtilities.Pole4Score;
            }
            score += scoreToAdd;
            CreateNewScoreAnimation(marioDestination, poleParts[poleParts.Count - 1].Destination, scoreToAdd);
        }

        public void SetMarioAirbourneToFalse()
        {
            comboManager.IsMarioAirbourne = false;
        }
        public void SetMarioEnemyHitThisIterationToFalse()
        {
            comboManager.HitEnemyAlreadyThisIteration = false;
        }

        private static void CreateNewScoreAnimation(IGameObject obj, int scoreToDisplay)
        {
            Rectangle objDestination = obj.Destination;
            Vector2 location = new Vector2(objDestination.X, objDestination.Y);
            IAnimationInGame scoreAnimation = new ScoreTextAnimation(location, "" + scoreToDisplay);
            scoreAnimation.StartAnimation();
        }
        private static void CreateNewScoreAnimation(IGameObject obj, string stringToDisplay)
        {
            Rectangle objDestination = obj.Destination;
            Vector2 location = new Vector2(objDestination.X, objDestination.Y);
            IAnimationInGame scoreAnimation = new ScoreTextAnimation(location, stringToDisplay);
            scoreAnimation.StartAnimation();
        }
        private static void CreateNewScoreAnimation(Rectangle marioDestination, Rectangle poleDestination, int scoreToDisplay)
        {
            IAnimationInGame scoreAnimation = new PoleScoreTextAnimation(marioDestination, poleDestination, "" + scoreToDisplay);
            scoreAnimation.StartAnimation();
        }

        private static ScoringSystem ClosestMarioScoringSystem(IGameObject obj)
        {
            int player = GameUtilities.Player1;
            Rectangle player1Dest = PlayerScore(GameUtilities.Player1).marioDestination;
            Rectangle player2Dest = PlayerScore(GameUtilities.Player2).marioDestination;
            Rectangle objDest = new Rectangle((int)obj.Location.X, (int)obj.Location.Y, obj.Destination.Width, obj.Destination.Height);
            if (player2Dest != ZeroRectangle)
                player = FindClosestPlayer(player1Dest, player2Dest, objDest);
            return PlayerScore(player);
        }
        private static int FindClosestPlayer(Rectangle player1Dest, Rectangle player2Dest, Rectangle objDest)
        {
            int player = GameUtilities.Player1;
            float player1X = player1Dest.X + player1Dest.Width / 2;
            float player1Y = player1Dest.Y + player1Dest.Height / 2;
            float player2X = player2Dest.X + player2Dest.Width / 2;
            float player2Y = player2Dest.Y + player2Dest.Height / 2;
            float objX = objDest.X + objDest.Width / 2;
            float objY = objDest.Y + objDest.Height / 2;
            float player1ToObjDistance = CalculateDistanceBetweenPlayerAndObject(player1X, player1Y, objX, objY);
            float player2ToObjDistance = CalculateDistanceBetweenPlayerAndObject(player2X, player2Y, objX, objY);
            if (player1ToObjDistance > player2ToObjDistance)
                player = GameUtilities.Player2;
            return player;
        }
        private static float CalculateDistanceBetweenPlayerAndObject(float playerX, float playerY, float objX, float objY)
        {
            return (float)Math.Sqrt(((playerX - objX) * (playerX - objX)) + ((playerY - objY) * (playerY - objY)));
        }
    }
}
