using GXPEngine;
using GXPEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Background : AnimationSprite
    {
            public Background() : base("Background2.png", 1, 3)
            {
            //SetScaleXY(1f);
            SetOrigin(width / 2 - 720, height  - 800);

                

            
            }
            void Update()
                {
        SetCycle(0, 1);
        if (EnemySpawner.Wave == 5)
        {
            SetCycle(1, 0);
        }
        if (EnemySpawner.Wave == 9)
        {
            SetCycle(2, 0);
        }
        Animate(1f);
                }
}

