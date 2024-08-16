using RPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameObjects.Monsters;
using RPG.BGMs;

namespace RPG.Scenes
{
    public class MapScene : Scene
    {
        private bool[,] map;
        private Point playerPos;

        private List<GameObject> gameObjects;
        private List<Monster> monsters;

        private Place town;

        private ConsoleKey input;

        private MusicPlayer mapBGM;

        public MapScene(Game game) : base(game)
        {
            map = new bool[,]
            {
                //    0      1      2      3      4      5      6      7      8      9
                { false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false },
            };

            mapBGM = new MusicPlayer();

            playerPos = new Point(1, 1);
            gameObjects = new List<GameObject>();
            monsters = new List<Monster>();

            Random rand = new Random();

            Place town = new Place(this);
            town.pos = new Point(1, 1);
            town.simbol = 'T';
            town.color = ConsoleColor.Yellow;
            town.destination = SceneType.Town;
            gameObjects.Add(town);

            AddMonsters();
        }

        private void AddMonsters()
        {
            Random rand = new Random();

            Monster monster1 = new Slime(this);
            monster1.pos = new Point(rand.Next(1, 8), rand.Next(3, 4));
            gameObjects.Add(monster1);

            Monster monster2 = new Orc(this);
            monster2.pos = new Point(rand.Next(1, 8), rand.Next(5, 6));
            gameObjects.Add(monster2);

            Monster monster3 = new Ghost(this);
            monster3.pos = new Point(rand.Next(1, 8), rand.Next(7, 8));
            gameObjects.Add(monster3);

            gameObjects.AddRange(monsters);  // List gameObjects에 배열로 요소를 추가 AddRange
        }
        public override void Enter()
        {
            Console.CursorVisible = false;

            mapBGM.Path = @"C:\BGMs\Map.mp3";
            mapBGM.Volume = 22;
            mapBGM.Loop = true;
            mapBGM.Play();

            Console.Clear();
            Console.WriteLine("숲으로 이동합니다...");
            Thread.Sleep(1500);
            Console.Clear();
        }

        public override void Exit()
        {
            Console.CursorVisible = true;
            mapBGM.Stop();
            MonsterRegen();
        }

        public override void Input()
        {
            input = Console.ReadKey().Key;
        }

        public override void Render()
        {
            Console.Clear();
            PrintMap();
            PrintGameObject();
            PrintPlayer();
        }

        public override void Update()
        {
            Move();
            Interaction();
        }

        private void PrintMap()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }

        private void PrintGameObject()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Console.SetCursorPosition(gameObject.pos.X, gameObject.pos.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.simbol);
                Console.ResetColor();
            }
        }

        private void PrintPlayer()
        {
            Console.SetCursorPosition(playerPos.X, playerPos.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }

        private void Move()
        {
            Point next = playerPos;

            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    next = new Point(playerPos.X, playerPos.Y - 1);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    next = new Point(playerPos.X, playerPos.Y + 1);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    next = new Point(playerPos.X - 1, playerPos.Y);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    next = new Point(playerPos.X + 1, playerPos.Y);
                    break;
            }

            if (map[next.Y, next.X])
            {
                playerPos = next;
            }
        }

        private void Interaction()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (playerPos.X == gameObject.pos.X &&
                    playerPos.Y == gameObject.pos.Y)
                {
                    gameObject.Interaction(game.Player);
                    if (gameObject.removeWhenInteract)
                    {
                        gameObjects.Remove(gameObject);
                    }
                    else if(gameObject is Monster monster)
                    {
                        if(monster.hp <= 0)
                        {
                            gameObjects.Remove(monster);
                            monsters.Remove(monster);
                        }
                    }
                    return;
                }
            }
        }

        private void MonsterRegen()
        {
            Random random = new Random();
            if (monsters.Count < 1)
            {
                AddMonsters();
            }
        }
    }
}
