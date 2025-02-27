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
        Bullet bullet;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Bullet Hell");
            Window.SetSize(400, 400);

            player = new Player();
            player.position = new Vector2(Window.Width / 2, 100);

            Vector2 bulletPosition = new Vector2(Window.Width / 2, Window.Height - 100);
            bullet = new Bullet(bulletPosition, 5, Color.Black);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            bullet.Update();

            bullet.Render();
            player.Render();
            
        }
    }

}
