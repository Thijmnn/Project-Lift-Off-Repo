using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

public class Enemy : AnimationSprite
{

    //int _score;
    public static float hitRange = 2f;
    public static float Range;
    public static int playerHealth = 10;
    int _startX;
    int _startY;
    float planeScale = 1f;
    float planeScale2 = 0.01f;
    int scaleTimer;
    int scaleTime = 20;
    float planeDistance;
    float rangeDiff;

    Cursor cursor;

    public EasyDraw textDisplayer;

    public Enemy(int x, int y, Cursor pCursor) : base("Plan2.png" ,3,3)
    {
            this.x = x;
            this.y = y;
            _startX = x;
            _startY = y;
            SetOrigin(width/2, height/2);
            cursor = pCursor;
        
        textDisplayer = new EasyDraw(300, 50);
        textDisplayer.TextAlign(CenterMode.Min, CenterMode.Min);
        AddChild(textDisplayer);
        textDisplayer.y = this.height / 2f;
        textDisplayer.x -= 50f;
    }

        public float GetScore()
        {
            return hitRange;
        }
    void Update(){
        planeDistance = 200 - (planeScale * 100f);
        textDisplayer.Clear(Color.Empty);
        textDisplayer.Text("Distance: "+planeDistance.ToString());
        scaleOverTime();
        shootRange();
        SetScaleXY(planeScale);

        //Animate(0.05f);

        if (planeScale >= 2f)
        {
            playerHealth -= 1;
            LateDestroy();
        }
        Move(0, .1f);

        if (hitRange - planeScale <= 0.2f && hitRange - planeScale >= -0.2f)
        {
            if (Input.GetKey(Key.F))
            {
                if (HitTestPoint(cursor.x, cursor.y))
                {
                    LateDestroy();
                }
            }
        }
     }



    void scaleOverTime()
    {
        scaleTimer++;
        //Console.WriteLine(scaleTimer);

        if(scaleTimer >= scaleTime)
        {
            //Console.WriteLine(planeScale);
            planeScale += planeScale2;
            scaleTimer = 0;
        }
        

    }
    void shootRange()
    {
        if (Input.GetKeyDown(Key.F))
        {
            SetFrame(2);
        }
        else if (Input.GetKeyDown(Key.G))
        {
            SetFrame(1);
        }
        if (hitRange <= 2f)
        {
            if (Input.GetKey(Key.Z))
            {
                hitRange += 0.002f;
            }
        }
        if (hitRange >= 1f)
        {
            if (Input.GetKey(Key.X))
            {
                hitRange -= 0.002f;
            }
        }
        if (hitRange <= 1f)
        {
            hitRange = 1f;
        }
        if (hitRange >= 2f)
        {
            hitRange = 2f;
        }


        rangeDiff = planeDistance - Range;
        Console.WriteLine(rangeDiff);

        if (rangeDiff >= 41 || rangeDiff <= -41)
        {
            //blury state
            SetCycle(0, 1);
            Console.WriteLine(" Blur1");
        }
        if ((rangeDiff <= 40 && rangeDiff >= 21) || (rangeDiff >= -40 && rangeDiff <= -21))
        {
            //middle state 
            SetCycle(3, 1);
            Console.WriteLine(" Blur2");
        }
        if (rangeDiff <= 20f && rangeDiff >= -20f)
        {
            //sharp state
            SetCycle(6, 1);
            Console.WriteLine(" Blur3");
        }
        Animate(0.05f);
    }

}
