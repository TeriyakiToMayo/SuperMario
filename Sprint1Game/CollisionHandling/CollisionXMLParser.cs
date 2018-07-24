using Sprint1Game.CollisionCommands;
using Sprint1Game.CollisionCommandsProjectiles;
using Sprint1Game.CollisionCommandsEnemies;
using Sprint1Game.CollisionCommandsItems;
using Sprint1Game.Commands;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Sprint1Game.CollisionHandling.CollisionSide;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.CollisionHandling
{
    public static class CollisionXMLParser
    {
        private static Dictionary<string, ICollisionCommand> commandDictionary = new Dictionary<string, ICollisionCommand>
        {
            {"MarioMarioCollisionTopCommand", new MarioMarioCollisionTopCommand()},
            {"MarioMarioCollisionRightCommand", new MarioMarioCollisionRightCommand()},
            {"MarioMarioCollisionBottomCommand", new MarioMarioCollisionBottomCommand()},
            {"MarioMarioCollisionLeftCommand", new MarioMarioCollisionLeftCommand()},
            {"MarioBlockCollisionTopCommand", new MarioBlockCollisionTopCommand()},
            {"MarioBlockCollisionRightCommand", new MarioBlockCollisionRightCommand()},
            {"MarioBlockCollisionBottomCommand", new MarioBlockCollisionBottomCommand()},
            {"MarioBlockCollisionLeftCommand", new MarioBlockCollisionLeftCommand()},
            {"MarioPipeCollisionTop", new MarioPipeCollisionTop()},
            {"MarioPipeCollisionRight", new MarioPipeCollisionRight()},
            {"MarioPipeCollisionBottom", new MarioPipeCollisionBottom()},
            {"MarioPipeCollisionLeft", new MarioPipeCollisionLeft()},
            {"MarioCoinCollisionTop", new MarioCoinCollisionTop()},
            {"MarioCoinCollisionLeft", new MarioCoinCollisionLeft()},
            {"MarioCoinCollisionRight", new MarioCoinCollisionRight()},
            {"MarioCoinCollisionBottom", new MarioCoinCollisionBottom()},
            {"MarioStarCollisionTop", new MarioStarCollisionTop()},
            {"MarioStarCollisionLeft", new MarioStarCollisionLeft()},
            {"MarioStarCollisionRight", new MarioStarCollisionRight()},
            {"MarioStarCollisionBottom", new MarioStarCollisionBottom()},
            {"MarioFlowerCollisionTop", new MarioFlowerCollisionTop()},
            {"MarioFlowerCollisionLeft", new MarioFlowerCollisionLeft()},
            {"MarioFlowerCollisionRight", new MarioFlowerCollisionRight()},
            {"MarioFlowerCollisionBottom", new MarioFlowerCollisionBottom()},
            {"MarioRMushroomCollisionTop", new MarioRMushroomCollisionTop()},
            {"MarioRMushroomCollisionLeft", new MarioRMushroomCollisionLeft()},
            {"MarioRMushroomCollisionRight", new MarioRMushroomCollisionRight()},
            {"MarioRMushroomCollisionBottom", new MarioRMushroomCollisionBottom()},
            {"MarioGMushroomCollisionTop", new MarioGMushroomCollisionTop()},
            {"MarioGMushroomCollisionLeft", new MarioGMushroomCollisionLeft()},
            {"MarioGMushroomCollisionRight", new MarioGMushroomCollisionRight()},
            {"MarioGMushroomCollisionBottom", new MarioGMushroomCollisionBottom()},
            {"MarioGoombaCollisionTop", new MarioGoombaCollisionTop()},
            {"MarioGoombaCollisionRight", new MarioGoombaCollisionRight()},
            {"MarioGoombaCollisionLeft", new MarioGoombaCollisionLeft()},
            {"MarioGoombaCollisionBottom", new MarioGoombaCollisionBottom()},
            {"MarioKoopaCollisionTop", new MarioKoopaCollisionTop()},
            {"MarioKoopaCollisionRight", new MarioKoopaCollisionRight()},
            {"MarioKoopaCollisionLeft", new MarioKoopaCollisionLeft()},
            {"MarioKoopaCollisionBottom", new MarioKoopaCollisionBottom()},
            {"GoombaBlockCollisionBottom", new GoombaBlockCollisionBottom()},
            {"GoombaBlockCollisionLeft", new GoombaBlockCollisionLeft()},
            {"GoombaBlockCollisionRight", new GoombaBlockCollisionRight()},
            {"GoombaBlockCollisionTop", new GoombaBlockCollisionTop()},
            {"GoombaGoombaCollisionBottom", new GoombaGoombaCollisionBottom()},
            {"GoombaGoombaCollisionLeft", new GoombaGoombaCollisionLeft()},
            {"GoombaGoombaCollisionRight", new GoombaGoombaCollisionRight()},
            {"GoombaGoombaCollisionTop", new GoombaGoombaCollisionTop()},
            {"GoombaKoopaCollisionBottom", new GoombaKoopaCollisionBottom()},
            {"GoombaKoopaCollisionLeft", new GoombaKoopaCollisionLeft()},
            {"GoombaKoopaCollisionRight", new GoombaKoopaCollisionRight()},
            {"GoombaKoopaCollisionTop", new GoombaKoopaCollisionTop()},
            {"GoombaHorseCollisionBottom", new GoombaHorseCollisionBottom()},
            {"GoombaHorseCollisionLeft", new GoombaHorseCollisionLeft()},
            {"GoombaHorseCollisionRight", new GoombaHorseCollisionRight()},
            {"GoombaHorseCollisionTop", new GoombaHorseCollisionTop()},
            {"KoopaBlockCollisionBottom", new KoopaBlockCollisionBottom()},
            {"KoopaBlockCollisionRight", new KoopaBlockCollisionRight()},
            {"KoopaBlockCollisionLeft", new KoopaBlockCollisionLeft()},
            {"KoopaBlockCollisionTop", new KoopaBlockCollisionTop()},
            {"FireBallCollisionLeft", new FireBallLeftCollision()},
            {"FireBallCollisionRight", new FireBallRightCollision()},
            {"FireBallCollisionTop", new FireBallTopCollision()},
            {"FireBallGoombaCollision", new FireBallGoombaCollision()},
            {"FireBallKoopaCollision", new FireBallKoopaCollision()},
            {"FireBallHorseCollision", new FireBallHorseCollision()},
            {"FireBallMarioCollision", new FireBallMarioCollision()},
            {"GoombaPipeCollisionBottom", new GoombaPipeCollisionBottom()},
            {"GoombaPipeCollisionLeft", new GoombaPipeCollisionLeft()},
            {"GoombaPipeCollisionRight", new GoombaPipeCollisionRight()},
            {"GoombaPipeCollisionTop", new GoombaPipeCollisionTop()},
            {"KoopaPipeCollisionBottom", new KoopaPipeCollisionBottom()},
            {"KoopaPipeCollisionRight", new KoopaPipeCollisionRight()},
            {"KoopaPipeCollisionLeft", new KoopaPipeCollisionLeft()},
            {"KoopaPipeCollisionTop", new KoopaPipeCollisionTop()},
            {"KoopaGoombaCollisionBottom", new KoopaGoombaCollisionBottom()},
            {"KoopaGoombaCollisionRight", new KoopaGoombaCollisionRight()},
            {"KoopaGoombaCollisionLeft", new KoopaGoombaCollisionLeft()},
            {"KoopaGoombaCollisionTop", new KoopaGoombaCollisionTop()},
            {"KoopaKoopaCollisionBottom", new KoopaKoopaCollisionBottom()},
            {"KoopaKoopaCollisionRight", new KoopaKoopaCollisionRight()},
            {"KoopaKoopaCollisionLeft", new KoopaKoopaCollisionLeft()},
            {"KoopaKoopaCollisionTop", new KoopaKoopaCollisionTop()},
            {"GMushroomBlockBottom", new GMushroomBlockBottom()},
            {"GMushroomBlockCollisionTop", new GMushroomBlockCollisionTop()},
            {"GMushroomBlockCollisionRight", new GMushroomBlockCollisionRight()},
            {"GMushroomBlockCollisionLeft", new GMushroomBlockCollisionLeft()},
            {"GMushroomPipeCollisionTop", new GMushroomPipeCollisionTop()},
            {"GMushroomPipeCollisionRight", new GMushroomPipeCollisionRight()},
            {"GMushroomPipeCollisionLeft", new GMushroomPipeCollisionLeft()},
            {"RMushroomBlockCollisionLeft", new RMushroomBlockCollisionLeft()},
            {"RMushroomBlockCollisionTop", new RMushroomBlockCollisionTop()},
            {"RMushroomBlockCollisionRight", new RMushroomBlockCollisionRight()},
            {"RMushroomPipeCollisionLeft", new RMushroomPipeCollisionLeft()},
            {"RMushroomPipeCollisionTop", new RMushroomPipeCollisionTop()},
            {"RMushroomPipeCollisionRight", new RMushroomPipeCollisionRight()},
            {"StarBlockCollisionBottom", new StarBlockCollisionBottom()},
            {"StarBlockCollisionTop", new StarBlockCollisionTop()},
            {"StarBlockCollisionRight", new StarBlockCollisionRight()},
            {"StarBlockCollisionLeft", new StarBlockCollisionLeft()},
            {"StarPipeCollisionBottom", new StarPipeCollisionBottom()},
            {"StarPipeCollisionTop", new StarPipeCollisionTop()},
            {"StarPipeCollisionRight", new StarPipeCollisionRight()},
            {"StarPipeCollisionLeft", new StarPipeCollisionLeft()},
            {"HorseBlockCollisionBottom", new HorseBlockCollisionBottom()},
            {"HorseBlockCollisionLeft", new HorseBlockCollisionLeft()},
            {"HorseBlockCollisionRight",new HorseBlockCollisionRight()},
            {"HorseBlockCollisionTop",new HorseBlockCollisionTop()},
            {"HorseGoombaCollisionBottom",new HorseGoombaCollisionBottom()},
            {"HorseGoombaCollisionLeft",new HorseGoombaCollisionLeft()},
            {"HorseGoombaCollisionRight",new HorseGoombaCollisionRight()},
            {"HorseGoombaCollisionTop",new HorseGoombaCollisionTop()},
            {"HorseHorseCollisionBottom",new HorseHorseCollisionBottom()},
            {"HorseHorseCollisionLeft",new HorseHorseCollisionLeft()},
            {"HorseHorseCollisionRight",new HorseHorseCollisionRight()},
            {"HorseHorseCollisionTop",new HorseHorseCollisionTop()},
            {"HorseKoopaCollisionBottom",new HorseKoopaCollisionBottom()},
            {"HorseKoopaCollisionLeft",new HorseKoopaCollisionLeft()},
            {"HorseKoopaCollisionRight",new HorseKoopaCollisionRight()},
            {"HorseKoopaCollisionTop",new HorseKoopaCollisionTop()},
            {"HorsePipeCollisionBottom",new HorsePipeCollisionBottom()},
            {"HorsePipeCollisionLeft",new HorsePipeCollisionLeft()},
            {"HorsePipeCollisionRight",new HorsePipeCollisionRight()},
            {"HorsePipeCollisionTop",new HorsePipeCollisionTop()},
            {"MarioHorseCollisionBottom", new MarioHorseCollisionBottom()},
            {"MarioHorseCollisionLeft", new MarioHorseCollisionLeft()},
            {"MarioHorseCollisionRight", new MarioHorseCollisionRight()},
            {"MarioHorseCollisionTop", new MarioHorseCollisionTop()},
            {"KoopaHorseCollisionBottom", new KoopaHorseCollisionBottom()},
            {"KoopaHorseCollisionLeft", new KoopaHorseCollisionLeft()},
            {"KoopaHorseCollisionRight",new KoopaHorseCollisionRight()},
            {"KoopaHorseCollisionTop",new KoopaHorseCollisionTop()},

        };
        public static void ParseXMLObjects(ICollisionHandler collisionHandler)
        {
            XmlDocument doc = new XmlDocument();
            string str = System.Environment.CurrentDirectory;
            string debuggingPath = "bin\\Windows\\x86\\Debug";
            str = str.Substring(0, str.Length - debuggingPath.Length);
            doc.Load(str + "CollisionHandling\\XML Files\\collisions.xml");
            XmlNode root = doc.ChildNodes.Item(1);
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name.Equals("Item"))
                {
                    ParseXMLObject(node, collisionHandler);
                }
                else
                {
                    continue;
                }
            }
        }
        private static void ParseXMLObject(XmlNode xmlObject, ICollisionHandler collisionHandler)
        {
            ObjectType object1Type = (ObjectType)Enum.Parse(typeof(ObjectType), xmlObject["object1"].FirstChild.Value);
            ObjectType object2Type = (ObjectType)Enum.Parse(typeof(ObjectType), xmlObject["object2"].FirstChild.Value);
            Object2Side side = (Object2Side)Enum.Parse(typeof(Object2Side), xmlObject["side"].FirstChild.Value);
            ICollisionCommand command = commandDictionary[xmlObject["command"].FirstChild.Value];
            collisionHandler.RegisterCommand(new Tuple<ObjectType, ObjectType, Object2Side>(object1Type, object2Type, side), command);
        }
    }
}
