using RPG.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG.Scenes
{
    public class SelectScene : Scene
    {

        public enum State {Name, Job, Confirm }
        private State curState;

        private string input;
        private string nameInput;

        public SelectScene(Game game) : base(game)
        { }
        public override void Enter()
        {
            curState = State.Name;
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            if (curState == State.Name)
            {
                Console.Write("캐릭터의 이름을 입력하세요 : ");
            }
            else if (curState == State.Job)
            {
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 도적");
                Console.Write("직업을 선택하세요 : ");
            }
            else if (curState == State.Confirm)
            {
                Console.WriteLine("===================");
                Console.WriteLine($"이름 : {game.Player.Name}");
                Console.WriteLine($"직업 : 모험가");
                Console.WriteLine($"체력 : {game.Player.MaxHP}");
                Console.WriteLine($"힘 : {game.Player.Str}");
                Console.WriteLine($"민첩 : {game.Player.Dex}");
                Console.WriteLine($"행운 : {game.Player.Luk}");
                Console.WriteLine($"공격 : {game.Player.Attack}");
                Console.WriteLine($"방어 : {game.Player.Defense}");
                Console.WriteLine($"잔여 능력치 : {game.Player.StatPoint}");
                Console.WriteLine($"소지금 : {game.Player.Gold}");
                Console.WriteLine("===================");
                Console.WriteLine();
                Console.Write("이대로 플레이 하시겠습니까?(y/n)");
            }
        }

        public override void Update()
        {
            if (curState == State.Name)
            {
                if (input == string.Empty)
                    return;

                nameInput = input;
                curState = State.Job;
            }
            else if (curState == State.Job)
            {
                if (Job.TryParse(input, out Job select) == false)
                    return;

                if (Enum.IsDefined(typeof(Job), select) == false)
                    return;

                switch (select)
                {
                    case Job.Warrior:
                        game.Player = new Warrior(nameInput);
                        break;
                    case Job.Mage:
                        game.Player = new Mage(nameInput);
                        break;
                    case Job.Rogue:
                        game.Player = new Rogue(nameInput);
                        break;
                }

                curState = State.Confirm;
            }
            else if (curState == State.Confirm)
            {
                switch (input)
                {
                    case "Y":
                    case "y":
                        game.ChangeScene(SceneType.Town);
                        break;
                    case "N":
                    case "n":
                        curState = State.Name;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
