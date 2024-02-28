using System;
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
        Random rnd = new Random();
        public int spawnTimer;
        public static int Wave = 1;
        public Enemy enemy;
        bool HUDActive = false;
        private float elapsedTime;
        private float interval = 30 * 1000;
        int reloadTimer;
        Cursor cursor;

        public EnemySpawner(Cursor pCursor)
        {
            cursor = pCursor;
        }

        void Update()
        {
            ammoCount();
            if (Input.GetKeyDown(Key.F))
            {
                if (Enemy.ammo > 0)
                {
                    Enemy.ammo--;
                }
            }

            gameStage();
            spawnEnemy();
            Console.WriteLine(Wave);
        }

        public void spawnEnemy()
        {
            //for (int j = 0; j < 4; j++)
            //{
            //  Console.WriteLine(rnd.Next(10)); //returns random integers < 10
            //}
            spawnTimer++;
            switch (Wave)
            {
                case (1):
                    enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor,1 ,0.2f);
                    break;

                case (2):
                    enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                    break;

                    //case 2:
                    //  if (spawnTimer >= 250)
                    //  {
                    //  enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor);
                    //  AddChild(enemy);

                    //Console.WriteLine("Enemy Spawned");
                    //  spawnTimer = 0;
                    //  }
                    // break;
            }
            if (spawnTimer >= 250)
            {
                AddChild(enemy);
                //Console.WriteLine("Enemy Spawned");
                spawnTimer = 0;
            }
        }

        public void gameStage()
        {
            if (Wave <= 5)
            {
                // Update the timer
                elapsedTime += Time.deltaTime;

                // Check if the interval is reached
                if (elapsedTime >= interval)
                {
                    // Increment the current stage
                    Wave++;
                    
                    // Adjust elapsedTime to keep track of the remaining time
                    elapsedTime %= interval;
                }
            }
        }

        void ammoCount()
        {

            if (Enemy.ammo <= 0)
            {
                reloadTimer++;
            }
            if (reloadTimer >= 300)
            {
                Enemy.ammo = 10;
                reloadTimer = 0;
            }
        }

    }
}

