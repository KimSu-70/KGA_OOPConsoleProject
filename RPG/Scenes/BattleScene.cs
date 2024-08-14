using RPG.GameObjects;
using RPG.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Scenes
{
    public class BattleScene : Scene
    {
        private Player player;
        private Monster monster;
        private bool battleResult = false;
        private string input;

        public BattleScene(Game game) : base(game)
        { }

        public void SetBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine($"{monster.name} 이/가 나타났다!");
            Thread.Sleep(2000);
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
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"{monster.name} 이/가 공격 해 왔다.");
            Console.WriteLine();
            Console.WriteLine("무엇을 하시겠습니까?");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 수비");
            Console.WriteLine("2. 도망");
            Console.WriteLine("--------------------------------");

            Console.WriteLine($"{monster.name} 남은 체력 : {monster.hp}");
            Console.WriteLine($"당신의 체력 : {game.Player.CurHP}/{game.Player.MaxHP}");
        }

        public override void Update()
        {
            switch(input)
            {
                case "1":
            }
            
            
            
            
            if (monster.hp <= 0)
            {
                Console.WriteLine($"{monster.name} 이/가 쓰러졌습니다!");
                Thread.Sleep(1500);
                game.ReturnScene();
            }
            else if (game.Player.CurHP <= 0)
            {
                Console.WriteLine("You Died");
                Thread.Sleep(1500);
                game.ChangeScene(SceneType.EndIng1);
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

        }
        private void Escape()
        {

        }
    }
}
