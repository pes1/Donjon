using System;

namespace DungeonSpel.Entities
{
    internal abstract class Creature: IDrawable
    {


        public ConsoleColor Color  { get; set; }
        public string       Symbol { get; set; }

        public int          Health { get; set; }
        public int          Damage { get; set; }
        public string       Name   { get; set; }

        protected  Creature(string name, string symbol, ConsoleColor color) // kan vara public
                                                                            // konsekvens av att klassen är internal
        {
            Name   = name;
            Symbol = symbol;
            Color  = color; //test
        }
    }
}