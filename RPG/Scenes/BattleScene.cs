using RPG.BGMs;
using RPG.GameObjects;
using RPG.GameObjects.Monsters;
using RPG.Players;

namespace RPG.Scenes
{
    public class BattleScene : Scene
    {
        private Player player;
        private Monster monster;
        private bool battleResult = false;
        private string input;

        private MusicPlayer battleBGM;

        public BattleScene(Game game) : base(game)
        {
            battleBGM = new MusicPlayer();
        }

        public void SetBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;

            if (monster is Ghost)
            {
                battleBGM.Path = @"C:\BGMs\BattleBoss.mp3";
            }
            else
            {
                battleBGM.Path = @"C:\BGMs\BattleNormal.mp3";
            }
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine($"{ monster.name} 이/가 나타났다!");
            Thread.Sleep(2000);

            battleBGM.Volume = 22;
            battleBGM.Loop = true;
            battleBGM.Play();
        }

        public override void Exit()
        {
            battleBGM.Stop();
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"{monster.name} 이/가 공격 해 왔다.");
            Console.WriteLine();
            Console.WriteLine("무엇을 하시겠습니까?");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 수비");
            Console.WriteLine("3. 도망");
            Console.WriteLine("--------------------------------");

            Console.WriteLine($"{monster.name} 남은 체력 : {monster.hp}");
            Console.WriteLine($"당신의 체력 : {game.Player.CurHP}/{game.Player.MaxHP}");
        }

        public override void Update()
        {
            switch (input)
            {
                case "1":
                    Attack();
                    break;
                case "2":
                    Defend();
                    break;
                case "3":
                    Escape();
                    break;
            }




            if (monster.hp <= 0)
            {
                monster.hp = 0;
                Console.WriteLine($"{monster.name} 이/가 쓰러졌습니다!");
                Thread.Sleep(1500);
                game.ReturnScene();
            }
            else if (game.Player.CurHP <= 0)
            {
                Console.WriteLine("당신은 쓰러졌습니다.");
                Thread.Sleep(1500);
                game.ChangeScene(SceneType.GameOver);
            }
        }

        private void Attack()
        {
            int Damage = player.Attack - monster.defense;
            int totalDamage;

            if (Damage < 0)
            {
                totalDamage = 0;
            }
            else
            {
                totalDamage = Damage;
            }

            totalDamage += (int)(player.Str * 0.3);

            bool criticalHit = player.rand.Next(100) < player.Luk;

            if (criticalHit)
            {
                totalDamage = (int)(totalDamage * 1.5);
                Console.WriteLine("적에게 치명적인 피해를 주었습니다!");
                Thread.Sleep(1000);
            }

            monster.hp -= totalDamage;
            Console.WriteLine($"{monster.name}에게 {totalDamage}의 피해를 입혔습니다");
            Thread.Sleep(1000);

            if (monster.hp > 0)
            {
                int monsterDamage = monster.attack - player.Defense;

                if (monsterDamage < 0)
                {
                    monsterDamage = 0;
                }

                player.CurHP -= monsterDamage;
                Console.WriteLine($"{monster.name} 이/가 당신을 공격 했습니다.");
                Console.WriteLine($"{monsterDamage}의 피해를 입었습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"{monster.name}에게 승리하였습니다!");
                Thread.Sleep(1000);
                game.ReturnScene();
            }
        }

        private void Defend()
        {
            int DamageReduction = monster.attack - player.Defense;
            int totalDamageReduction;

            if (DamageReduction < 0)
            {
                totalDamageReduction = 0;
            }
            else
            {
                totalDamageReduction = DamageReduction;
            }
            totalDamageReduction += (int)(player.Dex * 0.3);
            bool Parrying = player.rand.Next(100) < player.Dex;

            if (Parrying)
            {
                totalDamageReduction = 100;
                monster.hp -= 15 * (int)(player.Dex * 1.5);
                Console.WriteLine("완벽한 방어! 적에게 반격 피해를 주었습니다!");
                Thread.Sleep(1000);
            }
            
            if (player.CurHP > 0)
            {
                player.CurHP -= totalDamageReduction;
                Console.WriteLine("공격을 막아 피해를 줄였습니다.");
                Console.WriteLine($"{totalDamageReduction}의 피해를 입었습니다.");
                Thread.Sleep(1000);
            }
        }
        private void Escape()
        {
            bool escape = player.rand.Next(100) < 20 + player.Dex;

            if (escape)
            {
                Console.WriteLine("도망치는데 성공 했습니다!");
                Thread.Sleep(1000);
                game.ReturnScene();
            }
            else
            {
                int monsterAtk = monster.attack -= (int)(player.Defense * 0.5);
                player.CurHP -= monsterAtk;
                Console.WriteLine("도망에 실패했습니다!");
                Console.WriteLine($"{monster.name}에게 공격 당했습니다!");
                Console.WriteLine($"{monsterAtk}의 피해를 입었습니다.");
                Thread.Sleep(1000);
            }
        }
    }
}
