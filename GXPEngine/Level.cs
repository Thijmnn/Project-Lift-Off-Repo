using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    public class Level : GameObject
    {
    Background background = new Background();

        public Level()
        {
            EnemySpawner enemySpawner;
            Cursor cursor = new Cursor();
            AddChild(background);
            Camera cam1 = new Camera(0, 0, 1366, 768);
            cam1.SetScaleXY(1);
            cursor.AddChild(cam1);
            enemySpawner = new EnemySpawner(cursor);
            AddChild(enemySpawner);
            AddChild(cursor);


        // Console.WriteLine("MyGame initialized");
    }


    }

