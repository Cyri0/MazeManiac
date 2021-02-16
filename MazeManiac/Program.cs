using System;
using System.IO;

namespace MazeManiac
{
    class Program
    {
        static void Main(string[] args)
        {
            MapHandler map1 = new MapHandler("elso.txt");

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
                
                map1.showMap();
                map1.showAndClearMessage();
            }

            Console.ReadKey();
        }
    }

    class MapHandler
    {
        private char[,] map;
        private String mapname;
        private string message;

        public MapHandler() {
            this.mapname = "Default";
            this.message = "";
            this.map = new char[,] 
            {
                {'#','.','#','#','#'},
                {'#','.','.','.','#'},
                {'#','.','#','.','#'},
                {'#','@','#','.','x'},
                {'#','#','#','#','#'}
            };
        }

        public MapHandler(string filename) {
            this.mapname = filename;
            this.message = "";
            try {

                string[] lines = File.ReadAllLines(filename);

                int width = lines[0].Length;
                int height = lines.Length;

                char[,] mapFromFile = new char[width,height];

                for (int i = 0; i < lines.Length; i++) {
                    for (int j = 0; j < lines[i].Length; j++) {
                        char c = lines[i][j];
                        mapFromFile[i, j] = c;
                    }
                }

                this.map = mapFromFile;

            } catch(FileNotFoundException e) {
                Console.WriteLine("Hiba a fájl beolvasásakor!");
            }
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

        public void showAndClearMessage() {
            Console.WriteLine(this.message);
            this.message = "";
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

        private void move(int xmod, int ymod) {
            int[] pos = whereAmI();
            int x = pos[0];
            int y = pos[1];

            try
            {
                if (map[x + xmod, y + ymod] == '.')
                {
                    map[x + xmod, y + ymod] = '@';
                    map[x, y] = '.';
                }
                else
                {
                    this.message += "Falba ütköztél!";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                this.message += "Elérted a pálya szélét!";
            }
        }

        public void up() {
            move(-1, 0);
        }
        public void down() {
            move(1, 0);
        }
        public void right() {
            move(0, 1);
        }
        public void left() {
            move(0, -1);
        }
    }
}
