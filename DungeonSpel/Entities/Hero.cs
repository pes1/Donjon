using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSpel.Entities
{
    class Hero:Creature    //, IDrawable //- gränssnittet flyttat till basklassen
    {
        public int X        { get; set; }
        public int Y        { get; set; }
        //public int Health { get; set; }
        //public int Damage { get; set; }

        //public ConsoleColor Color  { get; set; } = ConsoleColor.DarkGray;
        //public string       Symbol { get; set; } = "@";
        //public string       Symbol { get; set; } = "☻";


        public LimitedList<Item> BackPack { get; set; }


        //public Hero() : base( name:"Roger Hjälte",symbol: "@", color: ConsoleColor.White) //- simplare tecken använt
        public Hero()   : base( name:"Roger Hjälte",
                                symbol: "☻", 
                                color: ConsoleColor.White) //- paras med att i Games lägga till:
                                                           //- Console.OutputEncoding = System.Text.Encoding.UTF8;
        {
            //Color = ConsoleColor.Cyan; //- flyttat till basklassen
            //Symbol = "@";              //- flyttat till basklassen

            Health = 5;
            Damage = 1;
            BackPack = new LimitedList<Item>(3);
            
        }


    }
}
