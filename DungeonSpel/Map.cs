using System;
using System.Collections.Generic;
using DungeonSpel.Entities;
using System.Linq;
namespace DungeonSpel
{
    internal class Map
    {
        private int          width;
        private int          height;
        private List<string> log;

        //private int[][] cells;         //- ej nödvändigtvis ortogonal array
        private Cell[,] cells;           //- 0,0 ligger längst upp till vänster
        private IEnumerable<Cell> Cells => cells.Cast<Cell>();  //låtsas att vi har en endimmensionell lista


        public  Hero Hero { get; set; }  //- Entities.Hero

        public IEnumerable<Monster> Monsters
            => Cells
                    .Where(cells => cells.Monster != null)  //lista av celler med monster i
                    .Select(c => c.Monster);             // skapa en lista av monster bara

        //{
        //get
        //{   //- Nedanstående görs eftersom listan inte är en endimensionell lista
        //-
        //-
        //var allCells = cells.Cast<Cell>(); // cast:a till en IEnumerable
        //var    monsterCells = Cells.Where(cells => cells.Monster != null); //lista av celler med monster i
        //var    monsters     = monsterCells.Select(c => c.Monster);         // skapa en lista av monster bara
        //lista av celler med monster i
        // skapa en lista av monster bara
        //return monsters;

        //    return Cells
        //        .Where(cells => cells.Monster != null)  //lista av celler med monster i
        //        .Select(c    => c.Monster);             // skapa en lista av monster bara
        ////}

        // }

        // cast:a till en IEnumerable


        public Map(int width, int height, List<string> log)
        {
            this.width  = width;
            this.height = height;
            this.log    = log;
            cells       = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x,y] = new Cell();
                }//-- for x
                //Console.WriteLine();
            }//-- for y
        }

        internal void Draw()
        {
            //var previousColor = Console.ForegroundColor;
            IDrawable drawable;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(" ");
                    
                     drawable = cells[x, y];


                    if (Hero.X == x && Hero.Y == y) drawable = Hero;
                    
                        Console.ForegroundColor = drawable.Color;
                        Console.Write(drawable.Symbol);
                    //if (Hero.X == x && Hero.Y == y)
                    //{
                    //    Console.ForegroundColor = Hero.Color;
                    //    Console.Write(Hero.Symbol);
                    //}
                    //else
                    //{
                    //    //Console.ForegroundColor = cell.Color;
                    //    //Console.Write(cell.Symbol);
                    //    Console.ForegroundColor = drawable.Color;
                    //    Console.Write(drawable.Symbol);
                    //}


                    //Console.Write(" ."); //-initialtest av arrayutskrift

                //Console.SetCursorPosition(int left, int top)


                    //Console.ForegroundColor = cells[x, y].Color;
                    ////Console.WriteLine(cells[x, y].Symbol);
                    //Console.Write(cells[x, y].Symbol);
                }//-- for x

                Console.WriteLine();
            }//-- for y
            // Console.ForegroundColor = previousColor;
        }//- of Draw()

        internal void ClearDeadMonsters()
        {
            var deadCells = Cells
                .Where(c => c.Monster != null)
                .Where(c => c.Monster.Health <= 0);
            foreach(var cell in deadCells)
            {
                cell.Monster = null;
            }


            //foreach (var cell in Cells){
            //    if   (cell.Monster != null) {
            //      if (cell.Monster.Health <= 0){
            //            cell.Monster = null;
            //        }
            //    }
            //}
        }

        internal void Pickup()
        {
            var cell = cells[Hero.X, Hero.Y];
            if(cell.Item != null)
            {
                var pickuped = Hero.BackPack.Add(cell.Item);
                if (pickuped
                    )
                    log.Add($"The {cell.Item} picked up.");
            }
        }

        internal Cell Cell(int x, int y)
        {
            return cells[x, y];
        }

        internal bool OutOfBounds(int x, int y)
        {
            bool outofBounds = x < 0 || y < 0 || x >= width || y >= height;
            //if (!outofBounds)
            //{
            //    var hasMonster = cells[x, y]?.Monster != null;
            //    return hasMonster;
            //}

            return outofBounds;
        }


        public bool MoveHero(int x, int y)
        {
            var targetX =  Hero.X + x; //- förväntad nästa position
            var targetY =  Hero.Y + y;

            if (OutOfBounds(targetX, targetY)) return false;
            var cell = cells[targetX, targetY];
            if(cell.Monster == null)
            {
                Hero.X = targetX;
                Hero.Y = targetY;
                return true;
            }
            else
            {
                Fight(Hero, cell.Monster);
                return true;
            }

        }

        private void Fight(Hero hero, Monster monster) //- ändras till (creature, creature)
        {
            //Console.WriteLine($"{hero.Name} attacks a { monster.Name} ({ monster.Health})");
            log.Add($"The {hero.Name} attacks a { monster.Name} ({ monster.Health})");
            monster.Health -=    hero.Damage;
            if (monster.Health <= 0)
            {
                log.Add($"The {monster.Name} is dead ");
                return;
            }
            log.Add($"The {monster.Name} attacks a { hero.Name} ");
            hero.Health -= monster.Damage;
        }
    }//- of class

}