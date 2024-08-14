using Microsoft.VisualBasic;

namespace RPG.Scenes
{
    public class HotelScene : Scene
    {
        public Random rand = new Random();
        public HotelScene(Game game) : base(game)
        { }
        public override void Enter()
        {
            Console.WriteLine("휴식중...");
            Thread.Sleep(1500);
        }

        public override void Exit()
        {

        }

        public override void Input()
        {

        }

        public override void Render()
        {

        }

        public override void Update()
        {
            if (game.Player.Gold > 19)
            {
                game.Player.Gold -= 20;
                game.Player.CurHP = game.Player.MaxHP;

                List<string> script = new();
                script.Add("오랜만에 푹 잔거 같다");
                script.Add("20G.. 좀 비싼거 같기도?");
                script.Add("좀 힘이 나는거 같네");
                
                int scriptType = script.Count;
                int RandNumber = rand.Next(scriptType);
                string RandScript = script[RandNumber];
                
                Console.WriteLine($"{RandScript}");
                Console.WriteLine($"체력이 전부 회복되었습니다.");
                
                Thread.Sleep(1500);
                game.ChangeScene(SceneType.Town);
            }
            else
            {
                Console.WriteLine("돈이 모자르다.");
                Thread.Sleep(1500);
                game.ChangeScene(SceneType.Town);
            }
        }
    }
}
