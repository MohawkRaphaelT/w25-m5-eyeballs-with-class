using System;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace MohawkGame2D
{
    public class Bullet
    {
        Vector2 position;
        Vector2 velocity;
        float radius;
        Color color;


        public Bullet(Vector2 pos, float r, Color c)
        {
            position = pos;
            radius = r;
            color = c;

            // Give bullet a random direction and fixed speed
            velocity = Random.Direction() * 100;
        }

        public void Render()
        {
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Circle(position, radius);
        }

        public void Update()
        {
            // Add velocity to position, scaled by time
            position += velocity * Time.DeltaTime;

            // Constrain to left and right sides of the window
            if (position.X <= 0 || position.X >= Window.Width)
            {
                velocity.X = -velocity.X;
            }

            // Constrain to top and bottom sides of the window
            if (position.Y <= 0 || position.Y >= Window.Height)
            {
                velocity.Y = -velocity.Y;
            }
        }
    }
}
