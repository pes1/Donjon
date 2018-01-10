using System;

namespace DungeonSpel
{
    internal interface IDrawable
    {
        ConsoleColor Color  { get; set; }
        string       Symbol { get; set; }
    }
}