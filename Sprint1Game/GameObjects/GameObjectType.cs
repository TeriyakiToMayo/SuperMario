using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.GameObjects
{
    public static class GameObjectType
    {
        public enum ObjectType {
            Mario, Goomba, Koopa, BrickBlock, Coin, CrackedBlock,
            Flower, GreenMushroom, Pipe, QuestionmarkBlock, RedMushroom,
            Star, StoneBlock, Block, SmallCloud, SmallHill, SmallBush,
            BigCloud, BigHill, BigBush, MediumCloud, MediumBush, Castle,
            MediumPipe, BigPipe, FireBallProjectile, Flag, FlagPole, FlagTop,
            BlackBackground, LPipe, Spawner, Horse
        };
    }
}
