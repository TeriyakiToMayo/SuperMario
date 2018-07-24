using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public enum AnimationState { NotStart, IsPlaying, Stopped }
    public interface IAnimation
    {
        void Update();
        AnimationState State { get; set; }
    }
}
