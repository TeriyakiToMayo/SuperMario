using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sound
{
    public class HurrySoundManager
    {
        private static HurrySoundManager instance = new HurrySoundManager();
        public static HurrySoundManager Instance
        {
            get
            {
                return instance;
            }
        }
        private HurrySoundManager()
        {

        }
        public void CheckForHurry()
        {
            if(GameUtilities.Game.State.Type != Interfaces.GameStates.Playing)
            {
                return;
            }

            if ((GameUtilities.GameObjectManager.MarioPlayer1.Destination.X < GameUtilities.FlagLine*GameUtilities.BlockSize ||
                GameUtilities.GameObjectManager.MarioPlayer1.Destination.X > GameUtilities.Competitive1EndLine * GameUtilities.BlockSize) && 
                MarioAttributes.Time == GameUtilities.HurryTime)
            {
                SoundManager.Instance.PlayHurryOverworldSong();
            }
            else if(GameUtilities.GameObjectManager.MarioPlayer1.Destination.X > GameUtilities.LevelEndLine * GameUtilities.BlockSize &&
                GameUtilities.GameObjectManager.MarioPlayer1.Destination.X < GameUtilities.Competitive1EndLine * GameUtilities.BlockSize &&
                MarioAttributes.Time == GameUtilities.HurryTime)
            {
                SoundManager.Instance.PlayHurryUnderworldSong();
            }
            else
            {
                SoundManager.Instance.ResumeSound();
            }

            this.ToString();
        }
    }
}
