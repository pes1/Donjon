using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSpel.Entities
{
    class Monster: Creature   //, IDrawable
    {
        private Monster(string  symbol, ConsoleColor color) : 
                  base(symbol: symbol, color:       color)
        {
            //this.Color = ConsoleColor.DarkRed;
            //this.Symbol = "C";
        }
        static Monster Troll()
        {
            return new Monster("T", ConsoleColor.Green);
        }

        static Monster Goblin()
        {
            return new Monster("G", ConsoleColor.Green);
        }



    }
}
