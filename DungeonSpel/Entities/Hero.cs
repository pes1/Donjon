﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSpel.Entities
{
    class Hero:Creature    //, IDrawable
    {
        public int X      { get; set; }
        public int Y      { get; set; }
        //public int Health { get; set; }
        //public int Damage { get; set; }

        //public ConsoleColor Color  { get; set; } = ConsoleColor.DarkGray;
        //public string       Symbol { get; set; } = "@";
        //public string Symbol { get; set; } = "☻";

        public Hero():base(symbol:"@",color: ConsoleColor.White)
        {
            //Color = ConsoleColor.Cyan;
            //Symbol = "@";
        }

        
    }
}