using System;

namespace DungeonSpel
{
    internal interface IDrawable
    {
        ConsoleColor Color  { get;   }
        string       Symbol { get;   }
    }
}