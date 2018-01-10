using DungeonSpel.Entities;
using System;

namespace DungeonSpel
{
    internal class Cell : IDrawable
    {
        public string       Symbol { get; set; } = ".";
        public ConsoleColor Color  { get; set; } = ConsoleColor.DarkGray;
        public Item         Item   { get; set; }

    }
}