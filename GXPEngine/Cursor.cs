using GXPEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Cursor : AnimationSprite
{
   
    AmmoCount ammocount = new AmmoCount();
    HealthCount healthcount = new HealthCount();
    StartScreen startscreen;
    public int waveTextTimer;
    public int waveTextTimerr;
    bool isShooting;
    int lastframe;
    public static int waveNum;
    public Cursor() : base("Turret.png",4,1)
    {
        isShooting = false;
        SetScaleXY(1f);
        this.y = game.height / 2;
        this.x = game.width / 2;
        SetOrigin(width / 2, height / 2);



        SetCycle(0, 1);
    }
    void Update()
    {
        
        AddChild(ammocount);
        AddChild(healthcount);
        startscreen = new StartScreen();

        waveTextTimerr = waveTextTimer / 100 % 2;
        //waveTextTimer = waveTextTimer / 10;
        //Console.WriteLine(waveTextTimerr.ToString());
        Enemy.Range = 200 - Enemy.hitRange * 100f;



        /*healthDisplay = new Button("Fire To Startt", 400, 150);
        healthDisplay.SetXY(425, height / 2 - 150);
        AddChild(healthDisplay);*/

        //health bar image


        /*ammoDisplay = new Button("Fire To Startt", 400, 150);
        ammoDisplay.SetXY(425, height / 2 - 150);
        AddChild(ammoDisplay);*/

        //AmmoImages


        if (EnemySpawner.Wave == 1 || EnemySpawner.Wave == 3 || EnemySpawner.Wave == 5 || EnemySpawner.Wave == 7 || EnemySpawner.Wave == 9 || EnemySpawner.Wave == 11)
        {
            /*aveDisplay = new Button("Wave: " + waveNum, 400, 150);
            waveDisplay.SetXY(0, height / 2 - 150);
            AddChild(waveDisplay);
            waveTextTimer++;
            if (waveTextTimer / 100 % 2 == 0)
            {
                waveDisplay.ClearTransparent();
            }*/


                //waves image
            
        }

        //Console.WriteLine(this.y);
        if (this.y <= 650)
        {
            if (Input.GetKey(Key.W))
            {
                y = y + 1.4f;
            }
        }
        if (this.y >= -50)
        {
            if (Input.GetKey(Key.S))
            {
                y = y - 1.8f;
            }
        }
        if (this.x <= 1300)
        {
            if (Input.GetKey(Key.D))
            {
                x = x + 1.4f;
            }
        }
        if (this.x >= -50)
        {
            if (Input.GetKey(Key.A))
            {
                x = x - 1.8f;
            }
        }

        if (Input.GetKeyDown(Key.F))
        {
            if (Player.ammo > 0)
            {
                isShooting = true;
                Player.ammo--;
                //Console.WriteLine("wav " +Wave);
                
            }
        }

        //Console.WriteLine(currentFrame + "  " + lastframe);
        if (isShooting)
        {
            SetCycle(0, 5);
            isShooting = false;
        }
        if (currentFrame == 3)
        {
            lastframe = 4;
        }
        if (currentFrame == 0 && lastframe == 4)
        {
            SetCycle(0, 1);
            lastframe = 0;
        }
        Animate(0.3f);
    }
}