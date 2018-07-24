using Microsoft.Xna.Framework.Input;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public class KeyboardController : IController
    {
        public enum KeyboardKeys { Left, Right, Up, Down, A, B, Select, Start, TestToSmall, TestToBig, TestToFire, TestToDead, TestToStar, TestReset, TestQuit } 
        private Dictionary<Keys, ICommand> commandDict = new Dictionary<Keys, ICommand>();
        private Dictionary<KeyboardKeys, Keys> keyDict = new Dictionary<KeyboardKeys, Keys>();
        private Dictionary<Keys, ICommand> releasedCommandDict = new Dictionary<Keys, ICommand>();
        private Dictionary<KeyboardKeys, Keys> releasedKeyDict = new Dictionary<KeyboardKeys, Keys>();
        private Keys[] preKeys = new Keys[0];
        private IMario mario;
        public bool IsFunctionKeysEnable { get; set; } = true;


        public KeyboardController()
        {
        }

        public void ClearAllCommandDicts()
        {
            commandDict = new Dictionary<Keys, ICommand>();
            keyDict = new Dictionary<KeyboardKeys, Keys>();
            releasedCommandDict = new Dictionary<Keys, ICommand>();
            releasedKeyDict = new Dictionary<KeyboardKeys, Keys>();
            preKeys = new Keys[0];
    }

        public void RegisterMario(IMario mario_)
        {
            this.mario = mario_;
        }
    
        public void RegisterCommand(KeyboardKeys name, Keys key, ICommand command)
        {
            if (!keyDict.ContainsKey(name) && !commandDict.ContainsKey(key))
            {
                keyDict.Add(name, key);
                commandDict.Add(key, command);
            }
        }

        public void RegisterReleasedCommand(KeyboardKeys name, Keys key, ICommand command)
        {
            if (!releasedKeyDict.ContainsKey(name) && !releasedCommandDict.ContainsKey(key))
            {
                releasedKeyDict.Add(name, key);
                releasedCommandDict.Add(key, command);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public void Update()
        {
            if(mario == null || keyDict.LongCount() == 0)
            {
                return;
            }

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if((GameUtilities.Game.State.Type == Interfaces.GameStates.Playing ||
                GameUtilities.Game.State.Type == Interfaces.GameStates.Competitive) &&
                IsFunctionKeysEnable)
            {
                if (Left(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.Left]].Execute();
                }
                else if (Right(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.Right]].Execute();
                }
                else if (Jump(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.A]].Execute();
                }
                else if (Down(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.Down]].Execute();
                }
                else if (LeftJump(pressedKeys))
                {
                    if (mario.IsInAir){
                        commandDict[keyDict[KeyboardKeys.Left]].Execute();
                    } else
                    {
                        commandDict[keyDict[KeyboardKeys.A]].Execute();
                    }
                    
                }
                else if (LeftDown(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.Down]].Execute();
                }
                else if (RightJump(pressedKeys))
                {
                    if (mario.IsInAir)
                    {
                        commandDict[keyDict[KeyboardKeys.Right]].Execute();
                    }
                    else
                    {
                        commandDict[keyDict[KeyboardKeys.A]].Execute();
                    }
                }
                else if (RightDown(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.Down]].Execute();
                }
                else if (LeftRightJump(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys.A]].Execute();
                }

                if (pressedKeys.Contains(keyDict[KeyboardKeys.B]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys.B]))
                {
                    commandDict[keyDict[KeyboardKeys.B]].Execute();
                }

                if (preKeys != null)
                {
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys.Right]) && Keyboard.GetState().IsKeyUp(releasedKeyDict[KeyboardKeys.Right]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys.Right]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys.Left]) && Keyboard.GetState().IsKeyUp(releasedKeyDict[KeyboardKeys.Left]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys.Left]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys.Down]) && Keyboard.GetState().IsKeyUp(releasedKeyDict[KeyboardKeys.Down]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys.Down]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys.B]) && Keyboard.GetState().IsKeyUp(releasedKeyDict[KeyboardKeys.B]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys.B]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys.A]) && Keyboard.GetState().IsKeyUp(releasedKeyDict[KeyboardKeys.A]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys.A]].Execute();
                    }
                }
            }else if (GameUtilities.Game.State.Type == Interfaces.GameStates.Title)
            {
                if (pressedKeys.Contains(keyDict[KeyboardKeys.A]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys.A]))
                {
                    commandDict[keyDict[KeyboardKeys.A]].Execute();
                }

                if (pressedKeys.Contains(keyDict[KeyboardKeys.Down]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys.Down]))
                {
                    commandDict[keyDict[KeyboardKeys.Down]].Execute();
                }
            }

            if (pressedKeys.Contains(keyDict[KeyboardKeys.Start]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys.Start]))
            {
                commandDict[keyDict[KeyboardKeys.Start]].Execute();
            }

            preKeys = pressedKeys;

        }
        private bool Left(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
        private bool Right(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
        private bool Jump(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
        private bool Down(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }

        private bool LeftJump(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
        private bool LeftDown(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
        private bool RightJump(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
        private bool RightDown(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }

        private bool LeftRightJump(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys.Down]);
        }
    }
}
