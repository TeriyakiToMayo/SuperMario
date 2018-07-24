using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects.PipeGameObjects;
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    class MarioPipeCollisionLeft : ICollisionCommand
    {
        int hurryTime = 100;
        public MarioPipeCollisionLeft()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }

            if(gameObject2.GetType() == typeof(LPipeBottom))
            {
                LPipeBottom pipe = (LPipeBottom)gameObject2;
                if (pipe.IsTelable)
                {
                    pipe.Warp(mario);
                    SoundManager.Instance.PlayPipeSound();
                    if (MarioAttributes.Time <= hurryTime)
                    {
                        SoundManager.Instance.PlayHurryOverworldSong();
                    }
                    else
                    {
                        SoundManager.Instance.PlayOverWorldSong();
                    }
                    return;
                } 
            }

            mario.Location = new Vector2(gameObject2.Destination.X - mario.Destination.Width, mario.Destination.Y);
            mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, mario.Velocity.Y);
        }
    }
}
