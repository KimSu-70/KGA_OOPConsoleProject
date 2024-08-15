using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG.Players
{
    public abstract class Player
    {
        public Random rand = new Random();

        protected string name;
        public string Name { get { return name; } }

        protected Job job;
        public Job Job { get { return job; } }

        protected int curHP;
        public int CurHP { get { return curHP; } set { curHP = value; } }

        protected int maxHP;
        public int MaxHP { get { return maxHP; } }

        protected int str;
        public int Str { get { return str; } set { str = value; } }

        protected int dex;
        public int Dex { get { return dex; } set { dex = value; } }

        protected int luk;
        public int Luk { get { return luk; } set { luk = value; } }

        protected int attack;
        public int Attack { get { return attack; } }

        protected int defense;
        public int Defense { get { return defense; } }

        protected int statPoint;
        public int StatPoint { get { return statPoint; } set { statPoint = value; } }

        protected int gold;
        public int Gold { get { return gold; } set { gold = value; } }

        //public abstract void Skill(Monster monster);

        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("==========================================");
            Console.WriteLine($" 이름 : {name,-6} 직업 : 모험가");
            Console.WriteLine($" 체력 : {curHP,+3} / {maxHP}");
            Console.WriteLine($" 힘 : {str} / 민첩 : {dex}");
            Console.WriteLine($" 공격 : {attack,-3} / 방어 : {defense,-3}");
            Console.WriteLine($" 행운 : {luk}");
            Console.WriteLine($" 골드 : {gold,+5} G");
            Console.WriteLine($" 잔여 능력치 : {statPoint}");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 15);
        }
    }
}
