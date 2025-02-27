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
        Eyeball[] eyeballs = [
                new Eyeball(),
                new Eyeball(),
                new Eyeball(),
                new Eyeball(new Vector2(200, 200), 50, 30, 18, Color.Green),
                new Eyeball(new Vector2(100, 100), 35, 25, 10, Color.Blue),
            ];
        int numberOfClicks = 0;


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Eyeballs with Classes");
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            for (int i = 0; i < eyeballs.Length; i++)
            {
                eyeballs[i].Render();
                if (eyeballs[i].HasClickedOnEye())
                {
                    numberOfClicks += 1;
                }
            }

            Text.Draw($"Clicks: {numberOfClicks}", 10, 10);


            if (numberOfClicks >= eyeballs.Length)
            {
                Window.ClearBackground(Color.Red);
                Text.Draw("Winner", 100, 200);
            }
        }
    }

}
