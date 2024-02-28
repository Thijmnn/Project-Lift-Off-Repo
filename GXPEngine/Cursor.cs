using GXPEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

public class Cursor : Sprite
{
    public EasyDraw rangeDisplayer;
    public EasyDraw healthDisplayer;
    public EasyDraw ammoDisplayer;
    public EasyDraw waveDisplayer;
    public int waveTextTimer;
    public int waveTextTimerr;
    public Cursor() : base("Plan.png")
    {

        SetScaleXY(0.5f);
        this.x = game.height / 2;
        this.y = game.width / 2;
        SetOrigin(width / 2, height / 2);

        rangeDisplayer = new EasyDraw(game.height, game.width);
        rangeDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(rangeDisplayer);
        rangeDisplayer.y = game.height + 3;
        rangeDisplayer.x = game.width - 300;
        rangeDisplayer.SetScaleXY(4f);

        healthDisplayer = new EasyDraw(game.height, game.width);
        healthDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(healthDisplayer);
        healthDisplayer.y = game.height;
        healthDisplayer.x = -game.width - 100;
        healthDisplayer.SetScaleXY(4f);

        ammoDisplayer = new EasyDraw(game.height, game.width);
        ammoDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(ammoDisplayer);
        ammoDisplayer.y = game.height;
        ammoDisplayer.x = game.width - 1000;
        ammoDisplayer.SetScaleXY(4f);

        waveDisplayer = new EasyDraw(game.width, game.height);
        waveDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(waveDisplayer);
        waveDisplayer.y = this.y- game.height;
        waveDisplayer.x = this.x - 450;
        waveDisplayer.SetScaleXY(4f);

    }
    void Update()
    {
        waveTextTimer++;
        waveTextTimerr = waveTextTimer / 100 % 2;
        //waveTextTimer = waveTextTimer / 10;
        //Console.WriteLine(waveTextTimerr.ToString());
        Enemy.Range = 200 - Enemy.hitRange * 100f;

        rangeDisplayer.Clear(Color.Empty);
        rangeDisplayer.Text("Range: " + Enemy.Range.ToString());

        healthDisplayer.Clear(Color.Empty);
        healthDisplayer.Text("Health: " + Enemy.playerHealth.ToString());

        ammoDisplayer.Clear(Color.Empty);
        ammoDisplayer.Text("Ammo: " + Enemy.ammo.ToString());

        if (EnemySpawner.Wave == 1 || EnemySpawner.Wave == 3)
        {
            if (waveTextTimer / 100 % 2 == 0)
            {
                waveDisplayer.Clear(Color.Empty);
                waveDisplayer.Text("Wave: " + EnemySpawner.Wave);
            }
            else
            {
                waveDisplayer.ClearTransparent();
            }
        }
        else
        {
            waveDisplayer.ClearTransparent();
        }

        //Console.WriteLine(this.y);
        if (this.y <= 650)
        {
            if (Input.GetKey(Key.W))
            {
                y = y + 1f;
            }
        }
        if (this.y >= -50)
        {
            if (Input.GetKey(Key.S))
            {
                y = y - 1f;
            }
        }
        if (this.x <= 850)
        {
            if (Input.GetKey(Key.D))
            {
                x = x + 1f;
            }
        }
        if (this.x >= -50)
        {
            if (Input.GetKey(Key.A))
            {
                x = x - 1f;
            }
        }
    }
}