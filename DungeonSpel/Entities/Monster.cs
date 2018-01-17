using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSpel.Entities
{
    class Monster: Creature   //, IDrawable
    {
        protected  Monster(string name, string  symbol, ConsoleColor color) : 
                   base(  name:name, symbol: symbol, color:       color)
        {
            //this.Color = ConsoleColor.DarkRed;
            //this.Symbol = "C";
        }
        public static Monster Troll()
        {
            return new Monster(name: "Monster", symbol: "T", color: ConsoleColor.DarkBlue)
            { Health = 3,
              Damage = 1
            };
        }

        public static Monster Goblin()
        {
            return new Monster(name:"Goblin", symbol:"G", color:ConsoleColor.Green)
            {
                Health = 2,
                Damage = 1
            };
        }

     
        

    }

    class Troll : Monster
    {
        public Troll() : base("Troll", "T", ConsoleColor.Green)
        {
            Health = 3;
            Damage = 1;
        }
    }

}
