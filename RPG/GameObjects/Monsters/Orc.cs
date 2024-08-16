using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects.Monsters
{
    public class Orc : Monster
    {
        public Orc(Scene scene) : base(scene)
        {
            name = "[일반] 오크";
            hp = 120;
            attack = 35;
            defense = 30;
            gold = 30;
            simbol = 'O';
        }
    }
}
