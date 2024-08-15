using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Players
{
    public class Warrior : Player
    {
        public Warrior(string name)
        {
            this.name = name;
            this.job = Job.Warrior;
            this.maxHP = 120 + rand.Next(-10, 40);
            this.curHP = maxHP;
            this.str = 15;
            this.dex = 10;
            this.luk = 3;
            this.attack = 30 + rand.Next(-10, 20);
            this.defense = 20 + rand.Next(0, 10);
            this.statPoint = 5;
            this.gold = 100;
        }
    }
}
