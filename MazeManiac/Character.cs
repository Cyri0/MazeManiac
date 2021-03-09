using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeManiac
{
    class Weapon {
        public int damage;
        public string name;

        public Weapon(int damage, string name) {
            this.damage = damage;
            this.name = name;
        }

    }
    class Character
    {
        public int hp;
        public int lvl;
        public int strength;
        public int agility;
        public int endurance;
        public Weapon weapon;
        public int[] damage;

        public int[] calculateDmg(Weapon w, int s) {

            int[] newDamage = { 0, 0 };

            newDamage[0] = (s * 2) + (int)(w.damage * 1.5);
            newDamage[0] = (int)(s * 2.2) + (int)(w.damage * 2);


            return newDamage;
        }
    }

    class Player : Character {
        public Player()
        {
            this.hp = 150;
            this.lvl = 1;
            this.strength = 5;
            this.agility = 5;
            this.endurance = 5;
            this.weapon = new Weapon(40, "kezdők pallosa");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }

    class Enemy : Character {
        public string name;

        public void fight(Player p) {
            Console.WriteLine(this.name + " megtámadott téged!");

            Random r = new Random();
            while (this.hp > 0 && p.hp > 0) {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                int player_damage = r.Next(p.damage[0], p.damage[1]);
                int enemy_damage = r.Next(this.damage[0], this.damage[1]);
                p.hp -= enemy_damage;
                this.hp -= player_damage;
                Console.WriteLine("Ellenfeled megsebzett téged! Vesztettél " + enemy_damage + " életerőt!");
                Console.WriteLine("Megsebezted ellenfeledet! " + this.name + " veszített " +player_damage +"életerőt!");
                Console.WriteLine("Játékos élete: " + p.hp + "\t"+this.name+" élete: " + this.hp );
            }

            if (this.hp <= 0 && p.hp <= 0)
            {
                Console.WriteLine("A harc döntetlen, mindketten elmentek nyalogatni a sebeiteket!");
            }
            else if (this.hp <= 0)
            {
                Console.WriteLine("Legyőzted az ellenfeled! Diadalittasan hagyod el a harc helyszínét.");
            }
            else {
                Console.WriteLine("Ellenfeled legyőzött... Szerencséd, hogy túlélted a harcot!");
            }
        }
    }

    class Ogre : Enemy {
        public Ogre() {
            this.name = "Ogre";
            this.hp = 200;
            this.lvl = 3;
            this.strength = 10;
            this.agility = 2;
            this.endurance = 10;
            this.weapon = new Weapon(100, "bunkósbot");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }
    class Goblin : Enemy {
        public Goblin()
        {
            this.name = "Goblin";
            this.hp = 50;
            this.lvl = 1;
            this.strength = 3;
            this.agility = 5;
            this.endurance = 5;
            this.weapon = new Weapon(20, "bot");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }
    class Ork : Enemy {
        public Ork()
        {
            this.name = "Ogre";
            this.hp = 100;
            this.lvl = 2;
            this.strength = 6;
            this.agility = 5;
            this.endurance = 7;
            this.weapon = new Weapon(50, "ork kard");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }
}
