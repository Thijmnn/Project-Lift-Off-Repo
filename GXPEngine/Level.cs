using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    public class Level : GameObject
    {
        public Level()
        {
            EnemySpawner enemySpawner;

            Cursor cursor = new Cursor();
            AddChild(cursor);
            
            Camera cam1 = new Camera(0, 0, 800, 600);
            cam1.SetScaleXY(2.5f, 2.5f);
            cursor.AddChild(cam1);
            enemySpawner = new EnemySpawner(cursor);
            AddChild(enemySpawner);


           // Console.WriteLine("MyGame initialized");
        }


    }

