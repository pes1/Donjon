using System;

namespace DungeonSpel
{
    internal class Map
    {
        private int width;
        private int height;

        //private int[][] cells;
        private Cell[,] cells;   //- 0,0 ligger längst upp till vänster
       // public Entities.Hero Hero { get; set; }
        public Entities.Hero Hero { get; set; }


        public Map(int width, int height)
        {
            this.width  = width;
            this.height = height;
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
            var previousColor = Console.ForegroundColor;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(" ");
                    
                    IDrawable drawable = cells[x, y];


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




                    //Console.ForegroundColor = cells[x, y].Color;
                    ////Console.WriteLine(cells[x, y].Symbol);
                    //Console.Write(cells[x, y].Symbol);
                }//-- for x

                Console.WriteLine();
            }//-- for y
            Console.ForegroundColor = previousColor;
        }//- of Draw()


        internal bool InValidCell(int x, int y)
        {
            return x < 0 || y < 0 || x >=  width || y >= height;
        }









    }//- of class

}