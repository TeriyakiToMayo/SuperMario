using Sprint1Game.Sound;
using Sprint1Game.UtilitiesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.HeadsUp
{
    public class CoinSystem
    {
        private static CoinSystem instance = new CoinSystem();
        public static CoinSystem Instance { get { return instance; } }
        private int coins = 0;
        public int Coins { get { return coins; } }
        public void AddCoin()
        {
            if (coins < HUDUtilities.MaxCoin)
            {
                coins++;
            }
            else if (coins == HUDUtilities.MaxCoin)
            {
                coins = 0;
                MarioAttributes.MarioLife[GameUtilities.Player1]++;
                SoundManager.Instance.Play1UpSound();
            }
            SoundManager.Instance.PlayCoinSound();
        }

        public void ResetCoin()
        {
            coins = 0;
        }
    }
}
