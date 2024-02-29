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
    public EasyDraw rangeDisplayer;
    public EasyDraw healthDisplayer;
    public EasyDraw ammoDisplayer;
    public EasyDraw waveDisplayer;
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

        rangeDisplayer = new EasyDraw(game.height, game.width);
        rangeDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(rangeDisplayer);
        rangeDisplayer.y = y;
        rangeDisplayer.x = x;
        rangeDisplayer.SetScaleXY(4f);

        healthDisplayer = new EasyDraw(game.height, game.width);
        healthDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(healthDisplayer);
        healthDisplayer.y = y;
        healthDisplayer.x = x;
        healthDisplayer.SetScaleXY(4f);

        ammoDisplayer = new EasyDraw(game.height, game.width);
        ammoDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(ammoDisplayer);
        ammoDisplayer.y = y;
        ammoDisplayer.x = x;
        ammoDisplayer.SetScaleXY(4f);

        waveDisplayer = new EasyDraw(game.width, game.height);
        waveDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(waveDisplayer);
        waveDisplayer.y =  y;
        waveDisplayer.x =  x;
        waveDisplayer.SetScaleXY(4f);

        SetCycle(0, 1);
    }
    void Update()
    {
        Console.WriteLine(y);
        
        waveTextTimerr = waveTextTimer / 100 % 2;
        //waveTextTimer = waveTextTimer / 10;
        //Console.WriteLine(waveTextTimerr.ToString());
        Enemy.Range = 200 - Enemy.hitRange * 100f;

        rangeDisplayer.Clear(Color.Empty);
        rangeDisplayer.Text("Range: " + Enemy.Range.ToString());

        healthDisplayer.Clear(Color.Empty);
        healthDisplayer.Text("Health: " + Player.playerHealth.ToString());

        ammoDisplayer.Clear(Color.Empty);
        ammoDisplayer.Text("Ammo: " + Player.ammo.ToString());

        if (EnemySpawner.Wave == 1 || EnemySpawner.Wave == 3 || EnemySpawner.Wave == 5 || EnemySpawner.Wave == 7 || EnemySpawner.Wave == 9 || EnemySpawner.Wave == 11)
        {
            waveTextTimer++;
            if (waveTextTimer / 100 % 2 == 0)
            {
                waveDisplayer.Clear(Color.Empty);
                waveDisplayer.Text("Wave:" + waveNum);
            }
            else
            {
                waveDisplayer.ClearTransparent();
            }
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