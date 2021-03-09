using System;
using System.IO;

namespace MazeManiac
{
    class Program
    {
        static void Main(string[] args)
        {
            Player jatekos = new Player();
            MapHandler map1 = new MapHandler("elso.txt", jatekos);

            bool gameIsRunning = true;
            map1.showMap();
            while (gameIsRunning) {
                
                char command = Console.ReadKey(true).KeyChar;

                Console.Clear();

                switch (command) {
                    case 'w': map1.up(); break;
                    case 's': map1.down(); break;
                    case 'a': map1.left(); break;
                    case 'd': map1.right(); break;
                    case 'f': Console.WriteLine(map1.whereAmI()[0] + "|"+map1.whereAmI()[1]); break;
                    default: Console.WriteLine("Nincs ilyen parancs!"); break;
                }
                if (map1.GameIsOver)
                {
                    map1.showAndClearMessage();
                    gameIsRunning = false;
                }
                else
                {
                    map1.showMap();
                    map1.showAndClearMessage();
                }
            }

            Console.ReadKey();
        }
    }
}
