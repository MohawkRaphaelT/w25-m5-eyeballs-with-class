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
        bool hasHitScreenEdge;
        float speed = 150;


        public Bullet(Vector2 pos, float r, Color c)
        {
            position = pos;
            radius = r;
            color = c;

            // Give bullet a random direction and fixed speed
            velocity = Random.Direction() * speed;
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
            bool isCollideLeft = position.X <= 0;
            bool isCollideRight = position.X >= Window.Width;
            bool isCollideTop = position.Y <= 0;
            bool isCollideBottom = position.Y >= Window.Height;
            hasHitScreenEdge = isCollideLeft || isCollideRight || isCollideTop || isCollideBottom;
            if (hasHitScreenEdge)
            {
                // Horizontal negation
                if (isCollideLeft || isCollideRight)
                    velocity.X = -velocity.X;

                // Vertical negation
                if (isCollideTop || isCollideBottom)
                    velocity.Y = -velocity.Y;

                // Constrain to left
                if (isCollideLeft)
                    position.X = 0;

                // constrain to right
                if (isCollideRight)
                    position.X = Window.Width;

                // constrain to top
                if (isCollideTop)
                    position.Y = 0;

                // constrain to bottom
                if (isCollideBottom)
                    position.Y = Window.Height;
            }
        }

        public bool HasHitScreenEdge()
        {
            bool hitScreenEdge = hasHitScreenEdge;
            hasHitScreenEdge = false;
            return hitScreenEdge;
        }

        public Bullet CreateClone()
        {
            Bullet clone = new Bullet(position, radius, color);

            // Strip speed from velocity, only have direction
            Vector2 direction = Vector2.Normalize(velocity);
            // Add random deviation
            Vector2 deviation1 = Random.Direction() / 3;
            Vector2 deviation2 = Random.Direction() / 3;
            // Reconstruct direction and reapply speed
            this.velocity = Vector2.Normalize(direction + deviation1) * speed;
            clone.velocity = Vector2.Normalize(direction + deviation2) * speed;

            return clone;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
