using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cursor : Sprite
{
    public Cursor() : base("Plan.png")
    {
        
        SetScaleXY(0.5f);
        this.x = width / 2;
        this.y = height / 2;
        SetOrigin(width / 2, height / 2);

    }
        void Update()
        { 
        if (Input.GetKey(Key.W))
        {
            y = y + .5f;
         }
         if (Input.GetKey(Key.S))
         {
             y = y - .5f;
         }
         if (Input.GetKey(Key.D))
         {
             x = x + .5f;
         }
         if (Input.GetKey(Key.A))
         {
             x = x - .5f;
         }

    }

    
}
