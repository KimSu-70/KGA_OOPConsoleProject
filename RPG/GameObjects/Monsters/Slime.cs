using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects.Monsters
{
    public class Slime : Monster
    {
        public Slime(Scene scene) : base(scene)
        {
            name = "[일반] 슬라임";
            hp = 70;
            attack = 25;
            defense = 15;
            gold = 10;
            simbol = 'S';
        }
    }
}
