﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

namespace GXPEngine
{
    public class EnemySpawner : GameObject
    {
        public int spawnTimer;
        public int spawnTime = 300;
        public Enemy enemy;
        bool HUDActive = false;
        Cursor cursor;
        public EasyDraw rangeDisplayer;
        public EnemySpawner(Cursor pCursor)
        {
            cursor = pCursor;
            rangeDisplayer = new EasyDraw(300, 50);
            rangeDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
            AddChild(rangeDisplayer);
            rangeDisplayer.y = 3;
            rangeDisplayer.x = 3;

        }

        void Update()
        {
            rangeDisplayer.Clear(Color.Empty);
            rangeDisplayer.Text("Range: " + Enemy.hitRange.ToString());
            spawnEnemy();
        }

        public void spawnEnemy()
        {
            Random rnd = new Random();
            for (int j = 0; j < 4; j++)
            {
              //  Console.WriteLine(rnd.Next(10)); //returns random integers < 10
            }
            spawnTimer++;
            
            if (spawnTimer >= 450) 
           {
                enemy = new Enemy(rnd.Next(7)*100+50, 70, cursor);
                AddChild(enemy);
                
                //Console.WriteLine("Enemy Spawned");
                spawnTimer = 0;
            }
            
        }

        


}
}