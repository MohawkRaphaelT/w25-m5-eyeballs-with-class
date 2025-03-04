using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position;
        public float drawSize = 15;
        public float colliderSize = 0;
        float speed = 200;

        public void Render()
        {
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
            Draw.Circle(position, drawSize);
        }

        public void Update()
        {
            Move();
            ConstrainToWindow();
        }

        private void ConstrainToWindow()
        {
            bool isTouchingTop = position.Y - colliderSize <= 0;
            bool isTouchingBottom = position.Y + colliderSize >= Window.Height;
            bool isTouchingLeft = position.X - colliderSize <= 0;
            bool isTouchingRight = position.X + colliderSize >= Window.Width;

            if (isTouchingLeft)
                position.X = 0 + colliderSize;

            if (isTouchingRight)
                position.X = Window.Width - colliderSize;

            if (isTouchingTop)
                position.Y = 0 + colliderSize;

            if (isTouchingBottom)
                position.Y = Window.Height - colliderSize;
        }

        private void Move()
        {
            Vector2 movement = Vector2.Zero;

            if (Input.IsKeyboardKeyDown(KeyboardInput.W) ||
                Input.IsAnyControllerButtonDown(ControllerButton.LeftFaceUp))
            {
                movement.Y -= 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.A) ||
                Input.IsAnyControllerButtonDown(ControllerButton.LeftFaceLeft))

            {
                movement.X -= 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.S) ||
                Input.IsAnyControllerButtonDown(ControllerButton.LeftFaceDown))
            {
                movement.Y += 1;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.D) ||
                Input.IsAnyControllerButtonDown(ControllerButton.LeftFaceRight))
            {
                movement.X += 1;
            }

            movement *= speed * Time.DeltaTime;
            position += movement;
        }
    }
}
