using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

public class Enemy : AnimationSprite
{

    //int _score;
    public static float hitRange = 2f;
    public static float Range;
    public int enemyHealth;
    public float planeSpeed;
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

    bool isDead;

    public Enemy(int x, int y, Cursor pCursor, int enemyHealth, float planeSpeed) : base("EnemyPlane.png" ,4,5)
    {
            this.x = x;
            this.y = y;
            _startX = x;
            _startY = y;
            this.enemyHealth = enemyHealth;
            this.planeSpeed = planeSpeed;
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
    public virtual void Update(){
        planeDistance = 200 - (planeScale * 100f);
        textDisplayer.Clear(Color.Empty);
        //textDisplayer.Text("Distance: "+planeDistance.ToString());
        scaleOverTime();
        shootRange();
        if (isDead)
        {
            Animate(0.1f);
        }
        else
        {
            Animate(0.2f);
        }

        SetScaleXY(planeScale);

        //Animate(0.05f);

        
        Move(0, planeSpeed);
        

        if (hitRange - planeScale <= 0.2f && hitRange - planeScale >= -0.2f)
        {
            if (Input.GetKeyDown(Key.F))
            {
                if (HitTestPoint(cursor.x, cursor.y))
                {
                    if (Player.ammo >= 1)
                    {
                        
                            enemyHealth--;
                        
                    }
                }
            }
        }
        
        if (enemyHealth <= 0)
        {
            if(isDead == false)
            {
                SetCycle(4, 5);
                isDead = true;
                Animate(0.03f);
            }
            if (currentFrame >= 8)
            {
                LateDestroy();
            }

            //Console.WriteLine(currentFrame);
        }
        if (y >= 400f)
        {
            if (isDead == false)
            {
                SetCycle(8, 5);
                isDead = true;
                Animate(0.03f);
            }
            if (currentFrame >= 12)
            {
                LateDestroy();
                Player.playerHealth -= 1;
            }
            


        }
    }



    public virtual void scaleOverTime()
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

    public virtual void shootRange()
    {
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
        

        if (rangeDiff >= 41 || rangeDiff <= -41 && isDead == false)
        {
            //blury state
            SetCycle(16, 4);
            //Console.WriteLine(" Blur1");
        }
        if ((rangeDiff <= 40 && rangeDiff >= 21) || (rangeDiff >= -40 && rangeDiff <= -21) && isDead == false)
        {
            //middle state 
            SetCycle(12, 4);
            //Console.WriteLine(" Blur2");
        }
        if (rangeDiff <= 20f && rangeDiff >= -20f && isDead == false)
        {
            //sharp state
            SetCycle(0, 4);
           // Console.WriteLine(" Blur3");
        }
    }
        

}
