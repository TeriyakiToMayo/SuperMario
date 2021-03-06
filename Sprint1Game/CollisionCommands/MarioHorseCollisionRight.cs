﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Microsoft.Xna.Framework;
using Sprint1Game.States.EnemyStates;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    class MarioHorseCollisionRight : ICollisionCommand
    {
        public MarioHorseCollisionRight()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            Horse goomba = (Horse)gameObject2;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario.IsProtected || !goomba.Alive)
            {
                return;
            }

            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - GameUtilities.SinglePixel));
            if (marioPreY + mario.Destination.Height < gameObject2.Destination.Y)
            {
                ICollisionCommand TopCommand = new MarioGoombaCollisionTop();

                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }

            else if (marioPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                ICollisionCommand BottomCommand = new MarioGoombaCollisionBottom();
                BottomCommand.Execute(gameObject1, gameObject2);
                return;
            }

            if (goomba.State.GetType() == typeof(GoombaAliveState))
            {
                if (mario.State.IsStar == true)
                {
                    ScoringSystem.Player1Score.AddPointsForSpecialGoombaHit(gameObject2);
                    goomba.Terminate("RIGHT");
                }
                else
                {
                    goomba.ChangeDirection();
                    switch (mario.State.MarioShape)
                    {
                        case MarioState.MarioShapeEnums.Small:
                            mario.State.Terminated();
                            break;
                        case MarioState.MarioShapeEnums.Big:
                            mario.IsProtected = true;
                            GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Small, mario);
                            SoundManager.Instance.PlayPipeSound();
                            break;
                        case MarioState.MarioShapeEnums.Fire:
                            mario.IsProtected = true;
                            GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Small, mario);
                            SoundManager.Instance.PlayPipeSound();
                            break;
                    }
                }
            }
        }
    }
}