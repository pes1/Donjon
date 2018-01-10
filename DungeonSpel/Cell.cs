using DungeonSpel.Entities;
using System;

namespace DungeonSpel
{
    internal class Cell : IDrawable
    {
        private string      _symbol = ".";
        private ConsoleColor _color = ConsoleColor.DarkGray;

        public string Symbol 
            => Monster?.Symbol 
            ??    Item?.Symbol
            ??    ".";



        //public string Symbol      { get {
        //        //if (Monster != null) return Monster?.Symbol;
        //        //return _symbol; }  }
        //        return Monster?.Symbol ?? Symbol;
        //    }
        //}



        //public ConsoleColor Color { get => _color; set => _color = value; }
        public ConsoleColor Color => Monster?.Color
                                    ??  Item?.Color
                                    ??  ConsoleColor.DarkGray;


        public Item         Item    { get; set; }
        public Monster      Monster { get; set; }  //- internal default
    }
    
}