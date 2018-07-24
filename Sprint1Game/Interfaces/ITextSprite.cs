using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface ITextSprite : ISprite
    {
        string Text { get; set; }
    }
}
