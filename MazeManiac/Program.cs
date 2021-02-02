using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeManiac
{
    class Program
    {
        static void Main(string[] args)
        {
            MapHandler map1 = new MapHandler("Elso palya");

            bool gameIsRunning = true;

            while (gameIsRunning) {
                char command = Console.ReadKey().KeyChar;
                switch (command) {
                    case 'w': map1.up(); break;
                    case 's': map1.down(); break;
                    case 'a': map1.left(); break;
                    case 'd': map1.right(); break;
                    case 'f': Console.WriteLine(map1.whereAmI()[0] + "|"+map1.whereAmI()[1]); break;
                    default: Console.WriteLine("Nincs ilyen parancs!"); break;
                }

                map1.showMap();
            }

            Console.ReadKey();
        }
    }

    class MapHandler
    {
        private char[,] map;
        private String mapname;

        public MapHandler(String name) {
            this.mapname = name;
            this.map = new char[,] 
            {
                {'#','@','#','#','#'},
                {'#','.','.','.','#'},
                {'#','.','#','.','#'},
                {'#','.','#','.','x'},
                {'#','#','#','#','#'}
            };
        }

        public String getName() {
            return mapname;
        }

        public char[,] getMap() {
            return map;
        }

        public void showMap() {
            int meret = this.map.GetLength(0);
            for (int row = 0; row < meret; row++) {
                for (int col = 0; col < meret; col++) {
                    Console.Write(this.map[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        public int[] whereAmI() {
            int[] pos = { 0, 0 };

            int meret = this.map.GetLength(0);
            for (int row = 0; row < meret; row++)
            {
                for (int col = 0; col < meret; col++)
                {
                    if (this.map[row, col] == '@') {
                        pos[0] = row;
                        pos[1] = col;
                    }
                }
            }

            return pos;
        }
        public void up() { }
        public void down() { }
        public void right() { }
        public void left() { }
    }
}
