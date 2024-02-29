using System;
namespace GXPEngine
{
	public class Enemy2 : Enemy
	{
        float angle = 90;
        float radius = 10;

        public Enemy2(int x, int y, Cursor pCursor, int health, float planeSpeed) : base(x,y,pCursor,health,planeSpeed)
		{
		//leave empty, inheritence in effect
        }

        public override void Update()
        {
            base.Update();
            Movement2();
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

        public virtual void Movement2()
        {
            angle -= 0.1f;
            y = y + Mathf.Sin(angle) * radius;
        }
    }
}

