using RPG.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG.GameObjects.Monsters
{
    public class Ghost : Monster
    {
        public Ghost(Scene scene) : base(scene)
        {
            name = "[보스] 고스트";
            hp = 200;
            attack = 45;
            defense = 55;
            simbol = 'G';
        }
    }
}
