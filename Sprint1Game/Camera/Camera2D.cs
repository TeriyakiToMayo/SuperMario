﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Camera
{
    public class Camera2D
    {
        public Camera2D()
        {
            Zoom = 1;
            Position = Vector2.Zero;
            Rotation = 0;
            Origin = Vector2.Zero;
        }
        public float Zoom { get; set; }
        public static Vector2 Position { get; set; }
        public static Collection<int> LimitationList { get; } = new Collection<int>();
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        private static int centerOfScreen = 240;
        private static int centerOfCamera = 240;
        private static int CameraXPos = GameUtilities.Origin;
        private static int scale = 1;
        
        public static int CenterOfScreen
        {
           get
            {
                return centerOfScreen;
            }
            set
            {
                centerOfScreen = value;
            }
        }

        public static int CenterOfCamera
        {
            get
            {
                return centerOfCamera;
            }
            set
            {
                centerOfCamera = value;
            }
        }
        
        public static int CameraX
        {
            get
            {
                return CameraXPos;
            }
            set
            {
                CameraXPos = value;
            }
        }

        public static void Move(IMario mario)
        {
            int fullWidthOfScreen = 2 * CenterOfScreen;
            int x = (int)-Position.X;

            foreach(int limitation in LimitationList)
            {
                if(x >= limitation - fullWidthOfScreen && x < limitation)
                {
                    Position = new Vector2(-(limitation - fullWidthOfScreen), 0);
                    return;
                }
                
            }

            int halfOfMarioWidth = MarioSpriteFactory.Instance.NormalMarioWidth / 2;

            if (((mario.Destination.X + halfOfMarioWidth) > centerOfCamera) && mario.Velocity.X >= 0)
            {
                Vector2 tempNewPos = new Vector2(-(mario.Location.X + halfOfMarioWidth - centerOfScreen), 0);
                if (-Position.X > -tempNewPos.X)
                {
                    return;
                }
                Position = new Vector2(-(mario.Location.X + halfOfMarioWidth - centerOfScreen), 0);
                CameraXPos = (int)-Position.X;
                centerOfCamera = CameraXPos + centerOfScreen;
            }
        }

        public static void ResetCamera()
        {
            CameraXPos = GameUtilities.Origin;
            centerOfCamera = centerOfScreen;
            Position = Vector2.Zero;
        }

        public static void SetCamera(Vector2 location)
        {
            CameraXPos = (int)location.X;
            centerOfCamera = (int)location.X + centerOfScreen;
            Position = new Vector2(-location.X, location.Y);
        }

        public Matrix GetTransform
        {
            get
            {
                var translationMatrix = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
                var rotationMatrix = Matrix.CreateRotationZ(Rotation);
                var scaleMatrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, scale));
                var originMatrix = Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 0));

                return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;
            }         
        }
    }
}
