using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Sprint1Game.Interfaces;

namespace Sprint1Game.Controllers
{
    public class GamePadController : IGamePadController
    {
        public enum KeyboardKeys2 { Left, Right, Up, Down, A, B, Select, Start, TestToSmall, TestToBig, TestToFire, TestToDead, TestToStar, TestReset, TestQuit }
        private Dictionary<Buttons, ICommand> commandDict = new Dictionary<Buttons, ICommand>();
        private Dictionary<KeyboardKeys2, Buttons> keyDict = new Dictionary<KeyboardKeys2, Buttons>();
        private Dictionary<Buttons, ICommand> releasedCommandDict = new Dictionary<Buttons, ICommand>();
        private Dictionary<KeyboardKeys2, Buttons> releasedKeyDict = new Dictionary<KeyboardKeys2, Buttons>();
        private Buttons[] preKeys = new Buttons[0];
        private IMario mario;
        public bool IsFunctionKeysEnable {get;set;}

        public GamePadController()
        {
        }

        public void ClearAllCommandDicts()
        {
            commandDict = new Dictionary<Buttons, ICommand>();
            keyDict = new Dictionary<KeyboardKeys2, Buttons>();
            releasedCommandDict = new Dictionary<Buttons, ICommand>();
            releasedKeyDict = new Dictionary<KeyboardKeys2, Buttons>();
            preKeys = new Buttons[0];
        }

        public void RegisterMario(IMario mario_)
        {
            this.mario = mario_;
        }

        public void RegisterCommand(KeyboardKeys2 name, Buttons key, ICommand command)
        {
            if (!keyDict.ContainsKey(name) && !commandDict.ContainsKey(key))
            {
                keyDict.Add(name, key);
                commandDict.Add(key, command);
            }
        }

        public void RegisterReleasedCommand(KeyboardKeys2 name, Buttons key, ICommand command)
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
            if (mario == null || keyDict.LongCount() == 0)
            {
                return;
            }

            List<Buttons> tempList = new List<Buttons>();
            if(GamePad.GetState(0).Buttons.A == ButtonState.Pressed)
            {
                tempList.Add(Buttons.A);
            }
            if (GamePad.GetState(0).Buttons.B == ButtonState.Pressed)
            {
                tempList.Add(Buttons.B);
            }
            if (GamePad.GetState(0).DPad.Left == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadLeft);
            }
            if (GamePad.GetState(0).DPad.Right == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadRight);
            }
            if (GamePad.GetState(0).DPad.Up == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadUp);
            }
            if (GamePad.GetState(0).DPad.Down == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadDown);
            }

            Buttons[] pressedKeys = new Buttons[tempList.LongCount()];
            for(int i = 0; i < pressedKeys.LongCount(); i++)
            {
                pressedKeys[i] = tempList[i];
            }

            if ((GameUtilities.Game.State.Type == Interfaces.GameStates.Playing ||
                GameUtilities.Game.State.Type == Interfaces.GameStates.Competitive) &&
                IsFunctionKeysEnable)
            {
                if (Left(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.Left]].Execute();
                }
                else if (Right(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.Right]].Execute();
                }
                else if (Jump(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.A]].Execute();
                }
                else if (Down(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.Down]].Execute();
                }
                else if (LeftJump(pressedKeys))
                {
                    if (mario.IsInAir)
                    {
                        commandDict[keyDict[KeyboardKeys2.Left]].Execute();
                    }
                    else
                    {
                        commandDict[keyDict[KeyboardKeys2.A]].Execute();
                    }
                }
                else if (LeftDown(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.Down]].Execute();
                }
                else if (RightJump(pressedKeys))
                {
                    if (mario.IsInAir)
                    {
                        commandDict[keyDict[KeyboardKeys2.Right]].Execute();
                    }
                    else
                    {
                        commandDict[keyDict[KeyboardKeys2.A]].Execute();
                    }
                }
                else if (RightDown(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.Down]].Execute();
                }
                else if (LeftRightJump(pressedKeys))
                {
                    commandDict[keyDict[KeyboardKeys2.A]].Execute();
                }


                if (pressedKeys.Contains(keyDict[KeyboardKeys2.B]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys2.B]))
                {
                    commandDict[keyDict[KeyboardKeys2.B]].Execute();
                }

                if (preKeys != null)
                {
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys2.Right]) && GamePad.GetState(0).IsButtonUp(releasedKeyDict[KeyboardKeys2.Right]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys2.Right]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys2.Left]) && GamePad.GetState(0).IsButtonUp(releasedKeyDict[KeyboardKeys2.Left]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys2.Left]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys2.Down]) && GamePad.GetState(0).IsButtonUp(releasedKeyDict[KeyboardKeys2.Down]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys2.Down]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys2.B]) && GamePad.GetState(0).IsButtonUp(releasedKeyDict[KeyboardKeys2.B]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys2.B]].Execute();
                    }
                    if (preKeys.Contains(releasedKeyDict[KeyboardKeys2.A]) && GamePad.GetState(0).IsButtonUp(releasedKeyDict[KeyboardKeys2.A]))
                    {
                        releasedCommandDict[releasedKeyDict[KeyboardKeys2.A]].Execute();
                    }
                }
            }
            else if (GameUtilities.Game.State.Type == Interfaces.GameStates.Title)
            {
                if (pressedKeys.Contains(keyDict[KeyboardKeys2.A]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys2.A]))
                {
                    commandDict[keyDict[KeyboardKeys2.A]].Execute();
                }

                if (pressedKeys.Contains(keyDict[KeyboardKeys2.Down]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys2.Down]))
                {
                    commandDict[keyDict[KeyboardKeys2.Down]].Execute();
                }
            }

            if (pressedKeys.Contains(keyDict[KeyboardKeys2.Start]) && preKeys != null && !preKeys.Contains(keyDict[KeyboardKeys2.Start]))
            {
                commandDict[keyDict[KeyboardKeys2.Start]].Execute();
            }

            preKeys = pressedKeys;
        }
        private bool Left(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
        private bool Right(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
        private bool Jump(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
        private bool Down(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }

        private bool LeftJump(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
        private bool LeftDown(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
        private bool RightJump(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
        private bool RightDown(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }

        private bool LeftRightJump(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(keyDict[KeyboardKeys2.Left]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.A]) &&
                pressedKeys.Contains(keyDict[KeyboardKeys2.Right]) &&
                !pressedKeys.Contains(keyDict[KeyboardKeys2.Down]);
        }
    }
}
