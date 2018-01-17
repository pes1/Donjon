using System;
namespace DungeonSpel.Entities
{
    public class Item: IDrawable
    {
        public string Name;

        public ConsoleColor Color  { get; }
        public string       Symbol { get; }


        public Item(string name, string symbol, ConsoleColor color)
        {
            this.Name   = name;
            this.Symbol = symbol;
            this.Color  = color;

        }
        public static Item Coin() => new Item("Coin", "C", ConsoleColor.Yellow);
    }
}