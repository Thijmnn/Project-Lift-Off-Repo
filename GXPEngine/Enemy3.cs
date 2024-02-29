using System;
namespace GXPEngine
{
	public class Enemy3 : Enemy
	{
        float angle = 90;
        float radius = 10;

        public Enemy3(int x, int y, Cursor pCursor, int health, float planeSpeed) : base(x, y, pCursor, health, planeSpeed)
        {
        }

        public override void Update()
        {
            base.Update();
            Movement3();
            // Update logic specific to wave enemy
        }


        public override void scaleOverTime()
        {
            base.scaleOverTime();
        }

        public override void shootRange()
        {
            base.shootRange();
        }

        public virtual void Movement3()
        {
            angle -= 0.1f;
            x = x + Mathf.Sin(angle) * radius;
        }







    }
}

