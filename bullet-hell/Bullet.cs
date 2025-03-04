using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Bullet
    {
        Vector2 position;
        Vector2 direction;
        float speed = 200;
        float radius;
        Color color;
        bool hasHitScreenEdge;


        public Bullet(Vector2 pos, float r, Color c)
        {
            position = pos;
            radius = r;
            color = c;

            // Give bullet a random direction and fixed speed
            direction = Random.Direction();
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
            // add to speed
            speed += Time.DeltaTime * 3;

            // Add velocity to position, scaled by time
            position += direction * speed * Time.DeltaTime;

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
                    direction.X = -direction.X;

                // Vertical negation
                if (isCollideTop || isCollideBottom)
                    direction.Y = -direction.Y;

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

            // Add random deviation
            Vector2 deviation1 = Random.Direction() / 3;
            Vector2 deviation2 = Random.Direction() / 3;
            // Reconstruct direction and reapply speed
            this.direction = Vector2.Normalize(direction + deviation1);
            clone.direction = Vector2.Normalize(direction + deviation2);

            return clone;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
