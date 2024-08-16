using RPG.BGMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Scenes
{
    public class TitleScene : Scene
    {

        private MusicPlayer MainBGM;
        public TitleScene(Game game) : base(game)
        {
            MainBGM = new MusicPlayer();
        }
        public override void Enter()
        {
            MainBGM.Path = @"C:\BGMs\Title.mp3";
            MainBGM.Volume = 22;
            MainBGM.Loop = true;
            MainBGM.Play();
        }

        public override void Exit()
        {
            MainBGM.Stop(); 
        }

        public override void Input()
        {
            Console.WriteLine("    시작하려면 아무키나 누르세요    ");
            Console.ReadKey();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=             랜덤 RPG             =");
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
