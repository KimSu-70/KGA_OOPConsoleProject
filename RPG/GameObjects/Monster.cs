using RPG.Players;
using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class Monster : GameObject
    {
        public SceneType battle;
        public string name;
        public int hp;
        public int attack;
        public int defense;

        public Monster(Scene scene) : base(scene)
        {
            color = ConsoleColor.Red;
        }

        public override void Interaction(Player player)
        {
            game.StartBattle(this);
        }
    }
}
