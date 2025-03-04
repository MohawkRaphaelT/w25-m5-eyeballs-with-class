// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Player player;
        Bullet[] bullets;
        int activeBullets = 0;
        int countBulletHitEdges;
        bool isGameOver;
        int maxBulletCount = 1000;
        int hitsRequired;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Bullet Hell");
            Window.SetSize(400, 400);
            ResetGameState();
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            if (isGameOver)
            {
                GameOver();
            }
            else
            {
                PlayGame();
            }
        }

        public void PlayGame()
        {
            Window.ClearBackground(Color.OffWhite);

            player.Update();

            for (int i = 0; i < activeBullets; i++)
            {
                Bullet bullet = bullets[i];
                bullet.Update();
                bullet.Render();
                if (bullet.HasHitScreenEdge())
                {
                    countBulletHitEdges += 1;
                    // TODO: split if hit enough times
                    bool canCreateClone = activeBullets < bullets.Length;
                    bool hasHitEnoughTimes = countBulletHitEdges >= hitsRequired;
                    if (canCreateClone && hasHitEnoughTimes)
                    {
                        // Create a new bullet, add to last spot in array
                        bullets[activeBullets] = bullet.CreateClone();
                        activeBullets++;
                        hitsRequired += activeBullets;

                        // Reset count
                        countBulletHitEdges = 0;
                    }
                }

                // does bullet hit player
                float distance = Vector2.Distance(player.position, bullet.GetPosition());
                if (distance < player.drawSize)
                {
                    isGameOver = true;
                }
            }

            player.Render();
        }

        public void GameOver()
        {
            Window.ClearBackground(Color.Red);

            // If press button, reset game state
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                ResetGameState();
            }
        }

        public void ResetGameState()
        {
            player = new Player();
            player.position = new Vector2(Window.Width / 2, 100);

            bullets = new Bullet[maxBulletCount];
            Vector2 bulletPosition = new Vector2(Window.Width / 2, Window.Height - 100);
            bullets[0] = new Bullet(bulletPosition, 10, Color.Black);
            activeBullets = 1;

            countBulletHitEdges = 0;
            hitsRequired = 1;

            isGameOver = false;
        }
    }

}
