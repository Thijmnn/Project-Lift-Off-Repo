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
    bool bossSpawned = false;
    
    Random rnd = new Random();
    public int spawnTimer;
    public static int Wave = 1;
    public Enemy enemy;
    public Boss boss;

    bool HUDActive = false;
    private float elapsedTime;
    private float interval = 6 * 1000;
    private float waveInterval = 45 * 1000;
    int reloadTimer;
    Cursor cursor;
    int waveTimer;
    int SpawnTime;

    private Random random = new Random();

        public EnemySpawner(Cursor pCursor) {
            cursor = pCursor;
        }

    void Update()
    {
        spawnTimer++;
        //Console.WriteLine(spawnTimer.ToString());
        //if (Wave == 1)
        //{
          //  SpawnTime = 5000;
          //  interval = 6 * 1000;
       // }
       // else if (Wave == 2)
       // {
           // SpawnTime = 7000;
          //  interval = 10 * 1000;
       // }
        
        
        gameStage();
        spawnEnemy();
        ammoCount();
    }
            

        public void spawnEnemy()
        {
        
            switch (Wave)
            {
                case (1):
                Cursor.waveNum = 1;

                break;
                case (2):
                
                enemy = new Enemy(rnd.Next(12) * 100 + 50, 70, cursor, 1, 0.2f);

                break;

                case (3):
                Cursor.waveNum = 2;
                break;

                case (4):
                enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                    break;

                case (5):
                Cursor.waveNum = 3;
                break;

                case (6):

                 enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                

                break;
                case (7):
                Cursor.waveNum = 4;
                break;

                case (8):
                enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                break;

                case (9):
                Cursor.waveNum = 5;
                break;

                case (10):
                if (bossSpawned == false)
                {
                    boss = new Boss(rnd.Next(7) * 100 + 50, 70, cursor, 20);
                    bossSpawned = true;
                }
                break;

                case (11):
                Cursor.waveNum = 6;
                break;

                case (12):
                enemy = new Enemy(rnd.Next(7) * 100 + 50, 70, cursor, 2, 0.1f);
                break;



            }
        if (spawnTimer >= 500)
            {
                if (Wave != 1 && Wave != 3 && Wave != 5 && Wave != 7 && Wave != 9 && Wave != 10 && Wave != 11 )
                {
                    AddChild(enemy);
                    
                    spawnTimer = 0;
                }
                
            }
        if (spawnTimer >= 250 && Wave == 10)
        {
            if (Wave == 10)
            {
                AddChild(boss);
                spawnTimer = 0;
            }

        }
    }
    //

    public void gameStage()
        {
            if (Wave == 1 || Wave == 3 || Wave == 5 || Wave == 7 || Wave == 9 || Wave == 11 )
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
            else if(Wave == 2 || Wave == 4 || Wave == 6 || Wave == 8)
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
            else if(Wave == 10)
                 {
            if (Boss.BossDead)
            {
                    Wave++;
                    Boss.BossDead = false;
            }
                 }
        }

        void ammoCount()
        {

            if (Player.ammo <= 0)
            {
                reloadTimer++;
            }
            if (reloadTimer >= 300)
            {
                Player.ammo = 10;
                reloadTimer = 0;
            }
        }

}



