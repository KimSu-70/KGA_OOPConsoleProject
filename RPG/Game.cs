﻿using RPG.GameObjects;
using RPG.Players;
using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Game
    {
        private bool isRunning;

        private Scene[] scenes;
        private Scene curScene;
        private Scene prevScene;
        
        public Scene CurScene { get { return curScene; } }

        private Player player;
        public Player Player { get { return player; } set { player = value; } }

        public void Run()
        {
            Start();                //준비작업
            while (isRunning)       // 계속해서 플레이
            {
                Render();           // 표현 : 게임데이터들을 이용해서 콘솔 출력
                Input();            // 입력 : 키보드를 통한 입력 받기
                Update();           // 처리 : 받은 입력을 토대로 게임데이터들 가공
            }
            End();
        }

        public void ChangeScene(SceneType sceneType)
        {
            curScene.Exit();
            curScene = scenes[(int)sceneType];
            curScene.Enter();
        }

        public void ReturnScene()
        {
            curScene.Exit();
            curScene = prevScene;
            curScene.Enter();
        }

        public void StartBattle(Monster monster)
        {
            prevScene = curScene;
            curScene.Exit();
            curScene = scenes[(int)SceneType.Battle];
            BattleScene battleScene = (BattleScene)curScene;
            battleScene.SetBattle(player, monster);
            curScene.Enter();
        }

        public void Over()
        {
            isRunning = false;
        }

        private void Start()
        {
            isRunning = true;
            //public enum SceneType { Title, Select, Town, Forest, EndIng1, Battle, 
            //EndIng2, EndIng3, EndIng4, EndIng5, Size }
        
            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Select] = new SelectScene(this);
            scenes[(int)SceneType.Town] = new TownScene(this);
            scenes[(int)SceneType.Hotel] = new HotelScene(this);
            scenes[(int)SceneType.Battle] = new BattleScene(this);
            scenes[(int)SceneType.Stat] = new StatScene(this);
            scenes[(int)SceneType.Map] = new MapScene(this);
            scenes[(int)SceneType.GameOver] = new GameOverScene(this);

            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
        }

        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }
    }
}
