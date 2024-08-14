namespace RPG.Scenes
{
    public class TownScene : Scene
    {
        private string input;
        public TownScene(Game game) : base(game)
        { }
        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("마을로 이동합니다");
            Thread.Sleep(1500);
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            game.Player.ShowInfo();
            Console.WriteLine("초보자 마을");
            Console.WriteLine("무엇을 하시겠습니까?");
            Console.WriteLine("1. 여관에서 휴식을 취한다 (체력 전부 회복/ 20G)");
            Console.WriteLine("2. 숲으로 이동한다");
            Console.WriteLine("3. 상태창을 확인한다.");
        }

        public override void Update()
        {
            switch (input)
            {
                case "1":
                    game.ChangeScene(SceneType.Hotel);
                    break;
                case "2":
                    game.ChangeScene(SceneType.Map);
                    break;
                case "3":
                    game.ChangeScene(SceneType.Stat);
                    break;
            }
        }
    }
}
