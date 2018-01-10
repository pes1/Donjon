using DungeonSpel.Entities;
using System;
using System.Collections.Generic;

namespace DungeonSpel
{
    internal class Game
    {
        private Map          map;
        private bool         playing;
        private List<string> log        = new List<string>();


        private ConsoleColor previousColor;
        private ConsoleKey key;

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

            cleanUp();

        }//- of play

        private void cleanUp()
        {
            Console.ForegroundColor = previousColor;
            Console.CursorVisible = true;              //tages bort i Initialize [ Draw()]
        }

        private void Initialize()
        {
            Console.WriteLine("Initializing game");     // Utskriften hinner ej ses.
            previousColor = Console.ForegroundColor;  //från map, testförflyttning.
            Console.CursorVisible = false;              //från Draw()
            //Console.ReadLine();                       // Hinner annars ej se ovanstående utskrift.
            map = new Map(width: 20, height: 20, log:log);  //- skapa kartan o ange storlek






            map.Hero  = new Hero();

            var troll    = Monster.Troll();           //- Factory-metod, instansierar ett objekt av Monsterklass:en
            Cell cell    = map.Cell(x: 10, y: 5);
            cell.Monster = troll;

            
            var goblin             = Monster.Goblin();
            map.Cell(8, 5).Monster = goblin;
            map.Cell(4, 3).Monster = Monster.Goblin();
            map.Cell(2, 3).Item    = Item.Coin();






            Console.OutputEncoding = System.Text.Encoding.UTF8; //- för att kunna skriva ut andra symboler än de vanliga på tangentbordet.

        }


        private void Play()
        {
            //Console.WriteLine("Playing game");
            Draw();
            playing = true;
            while (playing)
            {
                PlayerAction();
                UpdateMap();
                Draw();
                if (map.Hero.Health <= 0) playing = false;
            }
            Console.WriteLine("Game over");


        }  //- of   Play()

        private void UpdateMap()
        {
            map.ClearDeadMonsters();
        }

        private int ClearDeadMonsters()
        {
            throw new NotImplementedException();
        }

        private void PlayerAction()
        {
            // var key = Console.ReadKey(intercept: true).Key;
              key = Console.ReadKey(intercept: true).Key;    //- Key returnerar typen: ConsoleKey
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
            map.MoveHero(x, y);

            //var targetX = map.Hero.X + x; //- förväntad nästa position
            //var targetY = map.Hero.Y + y;

            //if (map.OutOfBounds(x:targetX, y:targetY) ) return; //- om inte giltig avsluta metod

            //map.Hero.X += x;
            //map.Hero.Y += y;
        }

        private void Draw()
        {
            Console.Clear();
            //Console.CursorVisible = false;
            map.Draw();
            Console.WriteLine($"Health: {map.Hero.Health} (X:{map.Hero.X} Y:{map.Hero.Y})");
            foreach(var message in log)
            {
                Console.WriteLine(message);
            }
            while (log.Count > 6) log.RemoveAt(0);

        } //- of class









    } //- of class
}