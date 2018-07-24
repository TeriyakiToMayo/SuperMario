﻿using Microsoft.Xna.Framework;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Animation
{
    public class VictoryAnimation : IAnimation
    {
        public AnimationState State { get; set; } = AnimationState.NotStart;

        private IMario mario_;
        private IItem flag_;

        private int stage = 1;
        private int counter = 0;
        private int maxCount = 1;
        private const int stage1 = 1;
        private const int stage2 = 2;
        private const int stage3 = 3;
        private const int minTime = 0;
        private const int minCount = 0;


        public VictoryAnimation(IMario mario, IItem flag)
        {
            this.mario_ = mario;
            this.flag_ = flag;
            
            mario_.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.StationaryAcceleration);
            mario_.Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.VictoryAnimationDownSpeed);
            SoundManager.Instance.PlayFlagPoleSound();
            
            flag_.Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.VictoryAnimationDownSpeed);
        }


        public void Update()
        {
            if (State != AnimationState.IsPlaying)
            {
                return;
            }

            switch (stage)
            {
                case stage1:
                    if (!mario_.IsInAir)
                    {
                        mario_.Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
                        mario_.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.Gravity);
                    }
                    if(flag_.Location.Y >= GameUtilities.VictoryAnimationGround * GameUtilities.BlockSize)
                    {
                        flag_.Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
                        flag_.Location = new Vector2(flag_.Location.X, GameUtilities.VictoryAnimationGround * GameUtilities.BlockSize);
                        
                    }

                    if (!mario_.IsInAir && flag_.Location.Y == GameUtilities.VictoryAnimationGround * GameUtilities.BlockSize)
                    {
                        stage++;
                    }
                    break;
                case stage2:
                    mario_.State.ChangeToRight();
                    if(mario_.Destination.X >= GameUtilities.castleGate * GameUtilities.BlockSize)
                    {
                        mario_.State.ChangeToLeft();
                        mario_.State.StateSprite = BlockSpriteFactory.Instance.CreateHiddenBlockSprite();
                        stage++;
                    }
                    break;
                case stage3:
                    if (MarioAttributes.Time == minTime)
                    {
                        stage++;
                    }else
                    {
                        counter++;
                        if (counter == maxCount)
                        {
                            ScoringSystem.Player1Score.AddPointsForRestTime();
                            MarioAttributes.Time--;
                            counter = minCount;
                        }
                    }
                    
                    break;
                default:
                    Game1 game = (Game1)GameUtilities.Game;
                    game.Reset();
                    game.State.Proceed();
                    MarioAttributes.MarioLife[mario_.Player] = GameUtilities.MarioInitalLife;
                    MarioAttributes.UpdateHighestScore();
                    CoinSystem.Instance.ResetCoin();
                    ScoringSystem.Player1Score.ResetScore();
                    MarioAttributes.ClearTimer();
                    break;
            }
        }
    }
}
