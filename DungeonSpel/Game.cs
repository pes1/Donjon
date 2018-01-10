using DungeonSpel.Entities;
using System;

namespace DungeonSpel
{
    internal class Game
    {
        private Map map;
        private bool playing;

        public Game()
        {

        } //- of Game

        
        internal void Start()  //- Startar spelet
        {
            //clear screen
            Console.Clear();  //rensa skärmen
            //initialize
            Initialize();
            //ConsoleColor konsolFärg = White;
            //Console.BackgroundColor backgroundColor = ;

            //// Get an array with the values of ConsoleColor enumeration members.
            //ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            //            Console.ReadLine();
            //play
            Play();



        }//- of play

        private void Initialize()
        {
            Console.WriteLine("Initializing game");
             map = new Map(width: 10, height: 10);
            map.Hero = new Hero();

            //Console.OutputEncoding = System.Text.Encoding.UTF8;

        }


        private void Play()
        {
            //Console.WriteLine("Playing game");
            Draw();
            playing = true;
            while (playing)
            {
                PlayerAction();
                Draw();
            }
        }  //- of class






        private void PlayerAction()
        {
            var key = Console.ReadKey(intercept:true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Move(x: 0, y: -1);
                    break;
                case ConsoleKey.DownArrow:
                    Move(x: 0, y: 1);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(x: -1, y: 0);
                    break;
                case ConsoleKey.RightArrow:
                    Move(x: 1, y: 0);
                    break;
                case ConsoleKey.Q:
                    playing = false;
                    break;


            }
        }//´- of PlayerAction()

        private void Move(int x, int y)
        {
            var targetX = map.Hero.X + x; //- förväntad nästa position
            var targetY = map.Hero.Y + y;

            if (map.InValidCell(x:targetX, y:targetY) ) return; //- om inte giltig avsluta metod

            map.Hero.X += x;
            map.Hero.Y += y;
        }

        private void Draw()
        {
            Console.Clear();
            Console.CursorVisible = false;
            map.Draw();

        } //- of class









    } //- of class
}