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
    public static int playerHealth = 10;
    public static int ammo = 10;
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
    int reloadTimer;

    Cursor cursor;

    public EasyDraw textDisplayer;

    bool isDead;

    public Enemy(int x, int y, Cursor pCursor, int enemyHealth, float planeSpeed) : base("small Plane1.png" ,8,3)
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
            Animate(0.05f);
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
                    if (ammo >= 1)
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
                SetCycle(0, 10);
                isDead = true;
                Animate(0.03f);
            }
            if (currentFrame >= 9)
            {
                LateDestroy();
            }

            Console.WriteLine(currentFrame);
        }
        if (y >= 500f)
        {

            SetCycle(0, 9);
            playerHealth -= 1;
            LateDestroy();
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
            SetCycle(20, 6);
            //Console.WriteLine(" Blur1");
        }
        if ((rangeDiff <= 40 && rangeDiff >= 21) || (rangeDiff >= -40 && rangeDiff <= -21) && isDead == false)
        {
            //middle state 
            SetCycle(16, 3);
            //Console.WriteLine(" Blur2");
        }
        if (rangeDiff <= 20f && rangeDiff >= -20f && isDead == false)
        {
            //sharp state
            SetCycle(9, 6);
           // Console.WriteLine(" Blur3");
        }
    }
        

}
