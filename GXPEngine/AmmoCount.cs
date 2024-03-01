using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


    public class AmmoCount : AnimationSprite
    {
        public AmmoCount() : base("AmmoCount.png",1,11)
        {
        this.x = 190; this.y = 320;
        SetCycle(10);
        }
        
        void Update()
    {
        switch(Player.ammo){
            case (0):
                SetCycle(0);
                break;

            case (1):
                SetCycle (1);
            break; 

            case (2):
                SetCycle(2);
                break;

            case (3):
                SetCycle(3);
                break;

            case (4):
                SetCycle(4);
                break;

            case (5):
                SetCycle(5);
                break;

            case (6):
                SetCycle(6);
                break;

            case (7):
                SetCycle(7);
                break;

            case (8):
                SetCycle(8);
                break;

            case (9):
                SetCycle(9);
                break;

            case (10):
                SetCycle(10);
                break;
        }
                //Animate(1f);
    }
    }

