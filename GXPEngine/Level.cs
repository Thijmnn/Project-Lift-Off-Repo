using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Level : GameObject
    {
        public Level()
        {
            EnemySpawner enemySpawner;

            Cursor cursor = new Cursor();
            AddChild(cursor);
            enemySpawner = new EnemySpawner(cursor);
            AddChild(enemySpawner);


            Console.WriteLine("MyGame initialized");
        }


    }
}
