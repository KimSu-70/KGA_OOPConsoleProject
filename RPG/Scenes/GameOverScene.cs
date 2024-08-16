using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Scenes
{
    public class GameOverScene : Scene
    {
        public GameOverScene(Game game) : base(game)
        { }
        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            Console.WriteLine("    다시 시작하려면 아무키나 누르세요    ");
            Console.ReadKey();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=             You Died             =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.Select);
        }
    }
}
