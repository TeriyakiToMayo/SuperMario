using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public static class GameUtilities
    {
        public static AbstractGame Game { get; set; }
        public static TheGameObjectManager GameObjectManager { get; set; }
        public const int Two = 2;
        public const int Three = 3;
        public const int Four = 4;
        public const int Five = 5;
        public const int Six = 6;
        public const int Seven = 7;
        public const int Eight = 8;
        public const int Nine = 9;
        public const string EmptyString = "";
        public static int Player1 { get; } = 0;
        public static int Player2 { get; } = 1;
        public static int Players { get; } = 2;
        public static int SpriteSize { get; set; } = 1;
        public static int HorizonLine { get; set; } = 300;
        public static int Number { get; set; } = 240;
        public static int Origin { get; } = 0;
        public static int StationaryVelocity { get; } = 0;
        public static int StationaryAcceleration { get; } = 0;
        public static int marioJumpingSpeed { get; } = -8;
        public static float marioMovingCriticalSpeed { get; } = 0.75f;
        public static int SinglePixel { get; } = 1;
        public static int MarioBounceVelocity { get; } = -2;
        public static int KoopaShellVelocity { get; } = 4;
        public static int FireBallPopVelocity { get; } = 3;
        public static int MarioSprintSpeed { get; } = 4;
        public static float MarioRegularSpeed { get; } = 2.5f;
        public static float MarioRegularAccel { get; } = .25f;
        public static float BrickBlockFallingSpeed { get; } = 0.5f;
        public static float GoombaBounceVelocity { get; } = 3.5f;
        public static float Gravity { get; } = .48f;
        public static float GoombaHSpeed { get; } = .75f;
        public static float FlowerGravity { get; } = 0.5f;
        public static int ScreenWidth { get; } = 480;
        public static int ScreenHeight { get; } = 240;
        public static int BlockSize { get; } = 16;
        public static int heightOutOfBlocks { get; } = 15;
        public static int MarioInitalLife { get; } = 3;
        public static float CoinGravity { get; } = 0.1f;
        public static float CoinInitialVelocity { get; } = -1.5f;
        public static float ScoreTextGravity { get; } = 0.05f;
        public static float ScoreTextInitialVelocity { get; } = -1.5f;
        public static float EnemyDistanceBuffer { get; } = 250f;
        public static int collisionDisplacement { get; } = 3;
        public static int castleGate { get; } = 204;
        public static int VictoryAnimationGround { get; } = 11;
        public const int VictoryAnimationDownSpeed = 1;
        public static int FireBallCombustSpriteCount { get; set; }
        public static int MaxTime { get; } = 300;
        public static int MaxCompetitiveTime { get; } = 60;
        public static int OneSecondOfMilliseconds { get; } = 1000;
        public static int HurryTime { get; } = 100;

        public static int FlagLine { get; } = 199;
        public static int LevelEndLine { get; } = 208;
        public static int UndergroundEndLine { get; } = 238;
        public static int Competitive1EndLine { get; } = 268;
        public static int Competitive2EndLine { get; } = 298;
    }
}
