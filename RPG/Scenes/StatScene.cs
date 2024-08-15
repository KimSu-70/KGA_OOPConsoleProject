namespace RPG.Scenes
{
    public class StatScene : Scene
    {
        public enum statType { STR, DEX, LUK }

        private string input;
        public StatScene(Game game) : base(game)
        {

        }
        public override void Enter()
        {

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
            Console.WriteLine("===================");
            Console.WriteLine($"이름 : {game.Player.Name}");
            Console.WriteLine($"직업 : 모험가");
            Console.WriteLine($"체력 : {game.Player.MaxHP}");
            Console.WriteLine($"힘 : {game.Player.Str}");
            Console.WriteLine($"민첩 : {game.Player.Dex}");
            Console.WriteLine($"행운 : {game.Player.Luk}");
            Console.WriteLine($"공격 : {game.Player.Attack}");
            Console.WriteLine($"방어 : {game.Player.Defense}");
            Console.WriteLine($"소지금 : {game.Player.Gold}");
            Console.WriteLine($"잔여 능력치 : {game.Player.StatPoint}");
            Console.WriteLine("===================");
            Console.WriteLine();
        }

        public override void Update()
        {
            if (game.Player.StatPoint > 0)
            {
                Console.Clear();
                Console.WriteLine("능력치 포인트가 남았습니다.");
                Console.WriteLine("포인트를 사용하시겠습니까?");
                Console.WriteLine("1. 힘 (STR)");
                Console.WriteLine("2. 민첩 (DEX)");
                Console.WriteLine("3. 행운 (LUK)");
                Console.WriteLine("4. 돌아가기");

                Input();

                switch (input)
                {
                    case "1":
                        Statinput(statType.STR);
                        break;
                    case "2":
                        Statinput(statType.DEX);
                        break;
                    case "3":
                        Statinput(statType.LUK);
                        break;
                    case "4":
                        game.ChangeScene(SceneType.Town);
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("1. 돌아가기");
                Input();
                switch (input)
                {
                    case "1":
                        game.ChangeScene(SceneType.Town);
                        break;
                }
            }
        }

        private void Statinput(statType statType)
        {
            if (game.Player.StatPoint > 0)
            {
                switch (statType)
                {
                    case statType.STR:
                        game.Player.Str++;
                        break;
                    case statType.DEX:
                        game.Player.Dex++;
                        break;
                    case statType.LUK:
                        game.Player.Luk++;
                        break;
                }
                game.Player.StatPoint--;
                Console.WriteLine($"{statType}가 1증가 하였습니다.");
                Console.WriteLine($"남은 능력치는 {game.Player.StatPoint}");
                Thread.Sleep( 1000 );
            }
        }
    }
}
