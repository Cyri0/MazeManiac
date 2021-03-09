using System;
using System.Collections.Generic;
using System.IO;


namespace MazeManiac
{
    class MapHandler
    {
        private char[,] map;
        private String mapname;
        private string message;
        private Player p;
        public bool GameIsOver = false;

        public MapHandler(Player p)
        {
            this.p = p;
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

        public MapHandler(string filename, Player p)
        {
            this.p = p;
            this.mapname = filename;
            this.message = "";
            try
            {

                string[] lines = File.ReadAllLines(filename);

                int width = lines[0].Length;
                int height = lines.Length;

                char[,] mapFromFile = new char[width, height];

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        char c = lines[i][j];
                        mapFromFile[i, j] = c;
                    }
                }

                this.map = mapFromFile;

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Hiba a fájl beolvasásakor!");
            }
        }

        public String getName()
        {
            return mapname;
        }

        public char[,] getMap()
        {
            return map;
        }

        public void showMap()
        {
            int meret = this.map.GetLength(0);
            for (int row = 0; row < meret; row++)
            {
                for (int col = 0; col < meret; col++)
                {
                    Console.Write(this.map[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public void showAndClearMessage()
        {
            Console.WriteLine(this.message);
            this.message = "";
        }

        public int[] whereAmI()
        {
            int[] pos = { 0, 0 };

            int meret = this.map.GetLength(0);
            for (int row = 0; row < meret; row++)
            {
                for (int col = 0; col < meret; col++)
                {
                    if (this.map[row, col] == '@')
                    {
                        pos[0] = row;
                        pos[1] = col;
                    }
                }
            }

            return pos;
        }

        private bool mapFight(Player p, Enemy e) {
            List<string> harc_log = e.fight(p);
            foreach (var line in harc_log)
            {
                this.message += "\n" + line;
            }

            if (harc_log[harc_log.Count - 1] == "PLAYER")
            {
                return true;
            }
            else if (harc_log[harc_log.Count - 1] == "ENEMY")
            {
                this.message += "\n" + "Súlyosan megsérültél! (-10 hp)";
                p.hp -= 10;
                return false;
            }
            else
            {
                return false;
            }
        }

        private void move(int xmod, int ymod)
        {
            int[] pos = whereAmI();
            int x = pos[0];
            int y = pos[1];

            char next_step = map[x + xmod, y + ymod];
            try
            {
                if (next_step == '.')
                {
                    map[x + xmod, y + ymod] = '@';
                    map[x, y] = '.';
                }
                else if (next_step == '&')
                {
                    Ork o = new Ork();
                    if (mapFight(this.p, o))
                    {
                        map[x + xmod, y + ymod] = '@';
                        map[x, y] = '.';
                    }
                }
                else if (next_step == 'g')
                {
                    Goblin o = new Goblin();
                    if (mapFight(this.p, o))
                    {
                        map[x + xmod, y + ymod] = '@';
                        map[x, y] = '.';
                    }
                }
                else if (next_step == 'x')
                {
                    this.message += "Kijutottál a labirintusból! Gratulálok!";
                    this.GameIsOver = true;
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

        public void up()
        {
            move(-1, 0);
        }
        public void down()
        {
            move(1, 0);
        }
        public void right()
        {
            move(0, 1);
        }
        public void left()
        {
            move(0, -1);
        }
    }
}
