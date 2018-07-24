using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Sprint1Game.Camera;
using Sprint1Game.DisplayPanel;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Commands
{
    class EnterCommand : ICommand
    {
        private Game1 game;

        public EnterCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            switch (game.State.Type)
            {
                case GameStates.Title:
                    game.State.Proceed();

                    TitleDisplayPanel titlePanel = (TitleDisplayPanel)GameUtilities.GameObjectManager.TitlePanel;
                    if(titlePanel.OptionNum == 1)
                    {
                        Camera2D.SetCamera(new Vector2(GameUtilities.UndergroundEndLine * GameUtilities.BlockSize, 0));
                        GameUtilities.GameObjectManager.MarioPlayer1.Location = new Vector2((GameUtilities.Competitive1EndLine - 4) * GameUtilities.BlockSize, 0);
                        GameUtilities.GameObjectManager.SetMarioPlayer2(new Mario(new Vector2((GameUtilities.UndergroundEndLine + 3) * GameUtilities.BlockSize, 0), GameUtilities.Player2));
                    } else if(titlePanel.OptionNum == 2)
                    {
                        Camera2D.SetCamera(new Vector2(GameUtilities.Competitive1EndLine * GameUtilities.BlockSize, 0));
                        GameUtilities.GameObjectManager.MarioPlayer1.Location = new Vector2((GameUtilities.Competitive2EndLine - 4) * GameUtilities.BlockSize, 0);
                        GameUtilities.GameObjectManager.SetMarioPlayer2(new Mario(new Vector2((GameUtilities.Competitive1EndLine + 3) * GameUtilities.BlockSize, 0), GameUtilities.Player2));
                    }
                    
                    break;
                case GameStates.Playing:
                    if(GameUtilities.GameObjectManager.MarioPlayer1.State.MarioPosture != MarioState.MarioPostureEnums.Dead)
                    {
                        game.State.Pause();
                        SoundManager.Instance.PauseSound();
                    }
                    break;
                case GameStates.Pause:
                    game.State.Proceed();
                    SoundManager.Instance.ResumeSound();
                    break;
                case GameStates.Competitive:
                    if (GameUtilities.GameObjectManager.MarioPlayer1.State.MarioPosture != MarioState.MarioPostureEnums.Dead &&
                        GameUtilities.GameObjectManager.MarioPlayer2.State.MarioPosture != MarioState.MarioPostureEnums.Dead)
                    {
                        game.State.Pause();
                        SoundManager.Instance.PauseSound();
                    }
                    break;
                case GameStates.CompetitivePause:
                    game.State.Proceed();
                    SoundManager.Instance.ResumeSound();
                    break;
                default:
                    break;
            }
            
        }
    }
}
