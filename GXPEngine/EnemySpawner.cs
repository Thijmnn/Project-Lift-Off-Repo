using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;



public class EnemySpawner : GameObject
{
    
    
    Random rnd = new Random();
    public int spawnTimer;
    public static int Wave = 1;
    public Enemy enemy;
    bool HUDActive = false;
    private float elapsedTime;
    private float interval = 6 * 1000;
    private float waveInterval = 30 * 1000;
    int reloadTimer;
    Cursor cursor;
    int waveTimer;

        public EnemySpawner(Cursor pCursor) {
            

            cursor = pCursor;





    }

        void Update()
        {

        spawnTimer++;
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
                //Console.WriteLine("wav " +Wave);
        }

        public void spawnEnemy()
        {
        
            switch (Wave)
            {
                case (1):
                //enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 1, 0.2f);

                break;

                case (2):
                
                enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 1, 0.2f);

                break;

                case (3):
                   
                    break;

                case (4):
                
                enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                    break;

                case (5):
                    enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                    break;


            }
            if (spawnTimer >= 250)
            {
                if (Wave != 1 && Wave != 3)
                {
                    AddChild(enemy);
                    //Console.WriteLine("Enemy Spawned");
                    spawnTimer = 0;
                }
                
            }
        }

        public void gameStage()
        {
            if (Wave == 1 || Wave == 3)
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
            else if(Wave == 2 || Wave == 4)
            {
            elapsedTime += Time.deltaTime;

             //Check if the interval is reached
            if (elapsedTime >= waveInterval)
            {
                // Increment the current stage
                Wave++;

                 //Adjust elapsedTime to keep track of the remaining time
                elapsedTime %= waveInterval;
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


