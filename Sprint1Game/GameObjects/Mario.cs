using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects;
using static Sprint1Game.GameObjects.GameObjectType;
using static Sprint1Game.MarioState;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;

namespace Sprint1Game
{
    public class Mario : IMario
    {
        public bool CanJump { get; set; } = true;
        public ObjectType Type { get; } = ObjectType.Mario;
        public IMarioState State { get; set; }   
        private bool isAirbourne;   
        public bool IsInAir
        {
            get { return isAirbourne; }
            set
            {
                if (!value)
                    ScoringSystem.Player1Score.SetMarioAirbourneToFalse();
                isAirbourne = value;
            }
        }
        private const int minProtectTime = 0;
        private bool isProtect = false;
        public bool IsProtected
        {
            get { return isProtect; }
            set
            {
                isProtect = value;
                if(value == true)
                {
                    protectTime = minProtectTime;
                }
            }
        }
        private int player;
        public int Player { get { return player; } }
        private int protectTime;
        private const int protectDuration = 50;
        private int starTime;
        private const int starDuration = 400;
        private const int maxYSpeed = 10;
        public MarioShapeEnums PreStarShape { set; get; }
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                int horizontalDisplacement = (MarioSpriteFactory.Instance.NormalMarioWidth - this.Destination.Width) / 2;
                int verticalDisplacement = (MarioSpriteFactory.Instance.NormalMarioHeight - this.Destination.Height);
                location.X = value.X - horizontalDisplacement;
                location.Y = value.Y - verticalDisplacement;
            }
        }

        public Vector2 Velocity{ set; get; }
        public float MarioTopSpeed { set; get; }
        public Vector2 Acceleration { set; get; }
        private const int smallMarioVertDis = 3;
        private const int smallMarioHeriDis = 3;
        private const int bigMarioVertDis = 5;
        private const int bigMarioHeriDis = 2;

        private const int starTimeMin = -1;
        private const int starTimeNormal = 0;
        public Rectangle Destination
        {
            set { Destination = value; }
            get
            {
                int verticalDisplacement;
                int horizontalDisplacement;
                if (this.State.MarioPosture == MarioPostureEnums.Crouch ||
                    this.State.MarioShape == MarioShapeEnums.Small ||
                    this.State.MarioShape == MarioShapeEnums.StarSmall)
                {
                    verticalDisplacement = MarioSpriteFactory.Instance.HalfNormalMarioHeight + smallMarioVertDis;
                    horizontalDisplacement = smallMarioHeriDis;
                }
                else 
                {
                    verticalDisplacement = bigMarioVertDis;
                    horizontalDisplacement = bigMarioHeriDis;
                }
                return new Rectangle((int)this.location.X + horizontalDisplacement, (int)this.location.Y + verticalDisplacement, MarioSpriteFactory.Instance.NormalMarioWidth - 2 * horizontalDisplacement, MarioSpriteFactory.Instance.NormalMarioHeight - verticalDisplacement);
            }
        }


        public Mario(Vector2 location, int player)
        {
            this.State = new IdleRightSmallMarioState(this);
            this.Location = location;
            this.player = player;
            this.Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
            this.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.Gravity);
            this.IsProtected = false;
            this.MarioTopSpeed = GameUtilities.MarioRegularSpeed;
            ScoringSystem.PlayerScore(player).RegisterMario(this);
        }

        public void Update()
        {
            if (IsProtected)
            {
                protectTime++;
                if(protectTime >= protectDuration)
                {
                    IsProtected = false;
                }
            }

            float newVelocityX = this.Velocity.X;
            if ((this.Velocity.X < MarioTopSpeed && this.Velocity.X > -MarioTopSpeed) || 
                (this.Velocity.X <= -MarioTopSpeed && this.Acceleration.X > GameUtilities.StationaryAcceleration) ||
                (this.Velocity.X >= MarioTopSpeed && this.Acceleration.X < GameUtilities.StationaryAcceleration))
            {
                newVelocityX += this.Acceleration.X;
            }
            float newVelocityY = this.Velocity.Y;
            if (this.Velocity.Y < maxYSpeed)
            {
                newVelocityY += this.Acceleration.Y;
            }
            this.Velocity = new Vector2(newVelocityX, newVelocityY);
            float newLocationX = this.Destination.X + this.Velocity.X;
            float newLocationY = this.Destination.Y + this.Velocity.Y;
            this.Location = new Vector2(newLocationX, newLocationY);
            State.Update();

            if (State.IsStar)
            {
                starTime--;
                if (starTime == starTimeMin)
                {
                    starTime = starDuration;
                }
                if (starTime == starTimeNormal)
                {
                    SoundManager.Instance.PlayOverWorldSong();
                    switch(PreStarShape)
                    {
                        case MarioShapeEnums.Big:
                            State.ChangeSizeToBig();
                            break;
                        case MarioShapeEnums.Fire:
                            State.ChangeFireMode();
                            break;
                        case MarioShapeEnums.Small:
                            State.ChangeSizeToSmall();
                            break;
                        default:
                            State.ChangeSizeToSmall();
                            break;
                    }
                }
            }
            else
            {
                PreStarShape = State.MarioShape;
                if (starTime != starTimeNormal)
                {
                    starTime = starTimeNormal;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, this.Location);
        }
    }
}
