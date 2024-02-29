using GXPEngine;
using System;

public class Boss : AnimationSprite
    {
        private int health;

        public int bossStage = 1;
        float moveSpeed;

        int bossHealth = 100; //still lost on health, cant test


        bool bossMove = true;

        private Random random = new Random();
        bool locationPicking = true;
        float storedTargetX;
        float storedTargetY;
        float moveTimer = 3000;  // Set the initial timer value

        int previousRandomValue = 0;
        int previousRandomXValue = 0;

        public Boss(float x, float y, int health)
            : base("boss.png", 1, 1)
        {
            SetOrigin(width / 2, height / 2);
            this.x = x;
            this.y = y;
            this.health = health;
        }

        public void Update()
        {
            MoveToNextStage();

            if (bossStage >= 4)
            {
                Environment.Exit(0);
            }
        }

        private void MoveToNextStage()
        {
            if (bossMove == true)
            {
                if (locationPicking == true)
                {
                    storedTargetX = GetTargetXForCurrentStage();
                    storedTargetY = GetTargetYForCurrentStage();
                    locationPicking = false;
                }

                float angle = Mathf.Atan2(storedTargetY - y, storedTargetX - x);
                // moveSpeed = 3;
                x += moveSpeed * Mathf.Cos(angle);
                y += moveSpeed * Mathf.Sin(angle);

                // Check if the boss has reached the target point
                float distanceToTarget = Mathf.Sqrt((x - storedTargetX) * (x - storedTargetX) + (y - storedTargetY) * (y - storedTargetY));

                float threshold = 3; // note - anything below 3 can jitter

                if (distanceToTarget <= threshold)
                {
                    // Set the boss's position to the exact target point to avoid jittering
                    x = storedTargetX;
                    y = storedTargetY;
                    moveSpeed = 0;
                    //bossMove = false;
                    CountdownTimer();

                    // Optionally, you can perform additional actions when the boss reaches the target point
                }
                else
                {
                    moveSpeed = 3;
                }
            }
        }

        private float GetTargetXForCurrentStage()
        {
            switch (bossStage)
            {
                case 1:
                    return game.width / 2;
                case 2:
                    return game.width / 5 * 4;
                case 3:
                    int randomXValue;
                    do
                    {
                        randomXValue = random.Next(3, 5); // Change upper bound to 6
                    } while (randomXValue == previousRandomXValue);

                    Console.WriteLine(randomXValue);
                    // Update the previous value for the next call to GetTargetYForCurrentStage
                    previousRandomXValue = randomXValue;

                    return game.width / 6 * randomXValue;
                default: return game.width - 100;
            }
        }

        private float GetTargetYForCurrentStage()
        {
            switch (bossStage)
            {
                case 1:
                    return game.height / 2;
                case 2:
                    int randomValue;
                    do
                    {
                        randomValue = random.Next(1, 5); // Change upper bound to 6
                    } while (randomValue == previousRandomValue);

                    Console.WriteLine(randomValue);
                    // Update the previous value for the next call to GetTargetYForCurrentStage
                    previousRandomValue = randomValue;

                    return game.height / 5 * randomValue;

                case 3:
                    do
                    {
                        randomValue = random.Next(1, 5); // Change upper bound to 6
                    } while (randomValue == previousRandomValue);

                    Console.WriteLine(randomValue);
                    // Update the previous value for the next call to GetTargetYForCurrentStage
                    previousRandomValue = randomValue;

                    return game.height / 5 * randomValue;

                default:
                    return game.height / 2;
            }
        }

    private void CountdownTimer()
    {
        if (locationPicking == false)
        {

            if (moveTimer > 0)
            {
                moveTimer -= Time.deltaTime;

                if (moveTimer <= 0)
                {
                    bossMove = true;
                    locationPicking = true;
                    moveTimer = 3000; //move in seconds/1000
                }
            }
        }
    }
}


