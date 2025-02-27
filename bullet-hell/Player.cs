using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position;
        public float size = 15;
        float speed = 150;

        public void Render()
        {
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position, size);
        }

        public void Update()
        {
            Vector2 movement = Vector2.Zero;

            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                movement.Y -= 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                movement.X -= 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                movement.Y += 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                movement.X += 1;
            }

            movement *= speed * Time.DeltaTime;
            position += movement;
        }
    }
}
