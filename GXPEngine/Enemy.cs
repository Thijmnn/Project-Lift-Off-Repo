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
    public static float hitRange = 0.5f;
    int _startX;
    int _startY;
    float planeScale = 1f;
    float planeScale2 = 0.01f;
    int scaleTimer;
    int scaleTime = 30;

    Cursor cursor;

    public EasyDraw textDisplayer;

    public Enemy(int x, int y, Cursor pCursor) : base("Plan.png", 1,1)
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
        textDisplayer.Clear(Color.Empty);
        textDisplayer.Text("Distance: "+planeScale.ToString());
        scaleOverTime();
        shootRange();
        SetScaleXY(planeScale);

        if (planeScale >= 1.9f)
        {
            LateDestroy();
        }
        Move(0, .1f);

        if (hitRange - planeScale <= 0.3f && hitRange - planeScale >= -0.3f)
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
            Console.WriteLine(planeScale);
            planeScale += planeScale2;
            scaleTimer = 0;
        }
        

    }
    void shootRange()
    {
        if (Input.GetKey(Key.Z))
        {
            hitRange += 0.002f;
        }
        if (Input.GetKey(Key.X))
        {
            hitRange -= 0.002f;
        }

        if(hitRange - planeScale >= 0.61f && hitRange - planeScale >= 0.61f) 
        {
            //blury state
        }
        if(hitRange - planeScale >= .6f && hitRange - planeScale <= .31f && hitRange - planeScale >= -.6f && hitRange - planeScale <= -.31f)
        {
            //middle state 
        }
        if(hitRange + planeScale >= .3f && hitRange - planeScale <= -.3f)
        {
            //sharp state
        }
    }

}
