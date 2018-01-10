using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSpel
{
    class Program
    {
        static void Main(string[] args)
        {
            //- start av program
            bool  playAgain;
            do {
                var game = new Game();
                game.Start();
                Console.WriteLine("Ahother game ?  Y/N: ");
                // var keyInfo = Console.ReadKey(intercept: true); //- inget eko av inskrivet tecken till konsolen.
                //- inget eko av inskrivet tecken till konsolen.

                //- Vilken tangent är nertryckt
                //var key = keyInfo.Key;
                //var playAgain  playAgain = key == ConsoleKey.Y;
                playAgain = Console.ReadKey(intercept: true).Key == ConsoleKey.Y;
                //- nystart av program ?
            }
            while (playAgain);



        }//- of main
    } //- of class





}
