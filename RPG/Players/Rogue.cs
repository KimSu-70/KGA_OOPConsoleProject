using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Players
{
    public class Rogue : Player
    {
        public Rogue(string name)
        {
            this.name = name;
            this.job = Job.Rogue;
            this.maxHP = 80 + rand.Next(-10, 20);
            this.curHP = maxHP;
            this.str = 10;
            this.dex = 5;
            this.luk = 15;
            this.attack = 40 + rand.Next(-10, 20);
            this.defense = 20;
            this.statPoint = 5;
            this.gold = 100 + rand.Next(0, 200);
        }
    }
}
