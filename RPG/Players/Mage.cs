using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Players
{
    public class Mage : Player
    {
        public Mage(string name)
        {
            this.name = name;
            this.job = Job.Mage;
            this.maxHP = 60;
            this.curHP = maxHP;
            this.str = 5;
            this.dex = 5;
            this.luk = 10;
            this.attack = 50 + rand.Next(-10, 40);
            this.defense = 10 + rand.Next(-10, 10);
            this.statPoint = 5;
            this.gold = 100;
        }
    }
}
