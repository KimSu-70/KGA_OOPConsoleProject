using RPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameObjects.Monsters;

namespace RPG.Scenes
{
    public class MapScene : Scene
    {
        private bool[,] map;
        private Point playerPos;

        private List<GameObject> gameObjects;

        private Place town;

        private Monster slime;
        private Monster orc;

        private ConsoleKey input;

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

            playerPos = new Point(1, 1);
            gameObjects = new List<GameObject>();
            Random rand = new Random();

            Place town = new Place(this);
            town.pos = new Point(1, 1);
            town.simbol = 'T';
            town.color = ConsoleColor.Yellow;
            town.destination = SceneType.Town;

            Monster monster1 = new Slime(this);
            monster1.pos = new Point(rand.Next(1,8), rand.Next(3,4));

            Monster monster2 = new Orc(this);
            monster2.pos = new Point(rand.Next(1, 8), rand.Next(5, 6));

            Monster monster3 = new Ghost(this);
            monster3.pos = new Point(rand.Next(1, 8), rand.Next(7, 8));

            gameObjects.Add(monster1);
            gameObjects.Add(monster2);
            gameObjects.Add(monster3);

            gameObjects.Add(town);
        }
        public override void Enter()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("숲으로 이동합니다...");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public override void Exit()
        {
            Console.CursorVisible = true;
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
                    return;
                }
            }
        }
    }
}
