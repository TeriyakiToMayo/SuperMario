using Microsoft.Xna.Framework;
using Sprint1Game.CollisionHandling;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.CollisionHandling.CollisionSide;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game
{
    public class AllCollisionHandler : ICollisionHandler
    {
        private Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand> collisionDictionary;
        private List<Tuple<IGameObject, IGameObject>> blockCollisions;
        
        public AllCollisionHandler()
        {
            collisionDictionary = new Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand>();
            CollisionXMLParser.ParseXMLObjects(this);
            blockCollisions = new List<Tuple<IGameObject, IGameObject>>();
        }

        public void RegisterCommand(Tuple<ObjectType, ObjectType, Object2Side> collision, ICollisionCommand command)
        {
            if (!collisionDictionary.ContainsKey(collision))
            {
                collisionDictionary.Add(collision, command);
            }          
        }

        public bool HandleCollision(IGameObject object1, IGameObject object2)
        {
            
            Object2Side side = DetermineCollisionSide(object1.Destination, object2.Destination);
            if (side != Object2Side.NoCollision)
            {
                Tuple<ObjectType, ObjectType, Object2Side> collision = new Tuple<ObjectType, ObjectType, Object2Side>(object1.Type, object2.Type, side);
                if (collisionDictionary.ContainsKey(collision))
                {
                    collisionDictionary[collision].Execute(object1, object2);
                }
            }
            return side != Object2Side.NoCollision;
        }

        public void DetectMarioBlockCollisions(IGameObject object1, IGameObject object2)
        {
            Object2Side side = DetermineCollisionSide(object1.Destination, object2.Destination);
            if (side != Object2Side.NoCollision)
            {
                blockCollisions.Add(new Tuple<IGameObject, IGameObject>(object1, object2));
            }
        }
        
        public void HandleMarioBlockCollisions()
        {
            for (int i = 0; i < blockCollisions.Count; i++)
            {
                IGameObject mario = blockCollisions[i].Item1;
                IGameObject block1 = blockCollisions[i].Item2;
                Rectangle marioDest = mario.Destination;
                Rectangle block1Dest = block1.Destination;
                if (i + 1 < blockCollisions.Count)
                {
                    IGameObject block2 = blockCollisions[i + 1].Item2;
                    if (block2.Destination.X - block1Dest.X <= GameUtilities.BlockSize && block1Dest.Y == block2.Destination.Y
                        && !DetermineToHandleFirstBlockCollision(marioDest, block1Dest, block2.Destination))
                            continue;
                }
                Object2Side side = DetermineCollisionSide(marioDest, block1Dest);
                Tuple<ObjectType, ObjectType, Object2Side> collision = new Tuple<ObjectType, ObjectType, Object2Side>(mario.Type, block1.Type, side);
                if (collisionDictionary.ContainsKey(collision))
                {
                    collisionDictionary[collision].Execute(mario, block1);
                }
                
            }
            blockCollisions.Clear();
        }

        private static bool DetermineToHandleFirstBlockCollision(Rectangle marioDest, Rectangle block1Dest, Rectangle block2Dest)
        {
            Rectangle collision1Intersection = Rectangle.Intersect(marioDest, block1Dest);
            Rectangle collision2Intersection = Rectangle.Intersect(marioDest, block2Dest);
            int collision1Area = collision1Intersection.Width * collision1Intersection.Height;
            int collision2Area = collision2Intersection.Width * collision2Intersection.Height;
            return collision1Area > collision2Area;
        }

        public static Object2Side DetermineCollisionSide(Rectangle obj1Dest, Rectangle obj2Dest)
        {
            Object2Side side = Object2Side.NoCollision;
            Rectangle collisionIntersection = Rectangle.Intersect(obj1Dest, obj2Dest);
            if (collisionIntersection.Width != 0 || collisionIntersection.Height != 0)
            {
                side = DetermineOverlappingCollisionSide(collisionIntersection, obj1Dest, obj2Dest);
            }
            else
            {
                side = DetermineBorderOrNoCollisionSide(obj1Dest, obj2Dest);
            }
            return side;
        }

        private static Object2Side DetermineOverlappingCollisionSide(Rectangle collisionIntersection, Rectangle obj1Dest, Rectangle obj2Dest)
        {
            Object2Side side = Object2Side.NoCollision;
            float percentOfObject1Height = (float)collisionIntersection.Height / ((float)obj1Dest.Height);
            float percentOfObject1Width = (float)collisionIntersection.Width / ((float)obj1Dest.Width);
            float percentOfObject2Height = (float)collisionIntersection.Height / ((float)obj2Dest.Height);
            float percentOfObject2Width = (float)collisionIntersection.Width / ((float)obj2Dest.Width);
            if (percentOfObject2Height > percentOfObject2Width || percentOfObject1Height > percentOfObject1Width)
            {
                if (collisionIntersection.X == obj2Dest.X)
                    side = Object2Side.Left;
                else
                    side = Object2Side.Right;
            }
            else
            {
                if (collisionIntersection.Y == obj2Dest.Y)
                    side = Object2Side.Top;
                else
                    side = Object2Side.Bottom;
            }
            return side;
        }

        private static Object2Side DetermineBorderOrNoCollisionSide(Rectangle obj1Dest, Rectangle obj2Dest)
        {
            Object2Side side = Object2Side.NoCollision;
            if (obj1Dest.Y + obj1Dest.Height == obj2Dest.Y && HasHorizontalIntersection(obj1Dest, obj2Dest))
            {
                side = Object2Side.Top;
            }
            else if (obj1Dest.Y == obj2Dest.Y + obj2Dest.Height && HasHorizontalIntersection(obj1Dest, obj2Dest))
            {
                side = Object2Side.Bottom;
            }
            else if (obj1Dest.X + obj1Dest.Width == obj2Dest.X && HasVerticalIntersection(obj1Dest, obj2Dest))
            {
                side = Object2Side.Left;
            }
            else if (obj1Dest.X == obj2Dest.X + obj2Dest.Width && HasVerticalIntersection(obj1Dest, obj2Dest))
            {
                side = Object2Side.Right;
            }
            return side;
        }

        private static bool HasHorizontalIntersection(Rectangle rect1, Rectangle rect2)
        {
            return rect1.X > rect2.X - rect1.Width + GameUtilities.collisionDisplacement && rect1.X < rect2.X + rect2.Width - GameUtilities.collisionDisplacement;
        }

        private static bool HasVerticalIntersection(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Y > rect2.Y - rect1.Height + GameUtilities.collisionDisplacement && rect1.Y < rect2.Y + rect2.Height - GameUtilities.collisionDisplacement;
        }
    }
}
