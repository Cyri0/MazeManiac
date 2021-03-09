using System;
using System.Collections.Generic;

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

            // s= 10  w=20
            newDamage[0] = (s * 2) + (int)(w.damage * 1.5);
            newDamage[1] = (int)(s * 2.2) + (int)(w.damage * 2);

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
            this.weapon = new Weapon(5, "kezdők pallosa");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }

    class Enemy : Character {
        public string name;

        public List<string> fight(Player p) {

            List<string> lista = new List<string>();

            lista.Add(this.name + " megtámadott téged!");

            Random r = new Random();
            while (this.hp > 0 && p.hp > 0) {
                lista.Add("-------------------------------------------------------------------------------------");
                int player_damage = r.Next(p.damage[0], p.damage[1]);
                int enemy_damage = r.Next(this.damage[0], this.damage[1]);
                p.hp -= enemy_damage;
                this.hp -= player_damage;
                lista.Add("Ellenfeled megsebzett téged! Vesztettél " + enemy_damage + " életerőt!");
                lista.Add("Megsebezted ellenfeledet! " + this.name + " veszített " +player_damage +"életerőt!");
                lista.Add("Játékos élete: " + p.hp + "\t"+this.name+" élete: " + this.hp );
            }

            if (this.hp <= 0 && p.hp <= 0)
            {
                lista.Add("A harc döntetlen, mindketten elmentek nyalogatni a sebeiteket!");
                lista.Add("TIE");
            }
            else if (this.hp <= 0)
            {
                lista.Add("Legyőzted az ellenfeled! Diadalittasan hagyod el a harc helyszínét.");
                lista.Add("PLAYER");
            }
            else {
                lista.Add("Ellenfeled legyőzött... Szerencséd, hogy túlélted a harcot!");
                lista.Add("ENEMY");
            }

            return lista;
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
            this.weapon = new Weapon(10, "bunkósbot");
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
            this.weapon = new Weapon(2, "bot");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }
    class Ork : Enemy {
        public Ork()
        {
            this.name = "Ork";
            this.hp = 100;
            this.lvl = 2;
            this.strength = 6;
            this.agility = 5;
            this.endurance = 7;
            this.weapon = new Weapon(8, "ork kard");
            this.damage = this.calculateDmg(this.weapon, this.strength);
        }
    }
}
