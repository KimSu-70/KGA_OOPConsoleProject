using RPG.Players;
using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class Place : GameObject
    {
        public SceneType destination;

        public Place(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            game.ChangeScene(destination);
        }
    }
}
