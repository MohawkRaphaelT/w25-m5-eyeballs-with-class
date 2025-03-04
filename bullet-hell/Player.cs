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
            // Create input vector. Values will be assigned later.
            Vector2 movement = Vector2.Zero;
            // Get keyboard input. Create X and Y axis from negative and positive keys.
            float keyboardX = Input.GetAxis(KeyboardInput.A, KeyboardInput.D);
            float keyboardY = Input.GetAxis(KeyboardInput.S, KeyboardInput.W);
            // Get controller input from controller 1 (index 0) specifically.
            float controllerX = Input.GetControllerAxis(0, ControllerAxis.RightX);
            float controllerY = Input.GetControllerAxis(0, ControllerAxis.RightY);

            // Set movement to controller input.
            movement.X = controllerX;
            movement.Y = controllerY;

            // Override controller input if keyboard kets pressed.
            if (keyboardX != 0)
                movement.X = keyboardX;
            if (keyboardY != 0)
                movement.Y = keyboardY;

            // Normalize vector is magnitude is greater than 1, e.g. diagonals of 1.4f
            if (movement.Length() > 1)
                movement = Vector2.Normalize(movement);

            // Apply movement
            movement *= speed * Time.DeltaTime;
            position += movement;
        }
    }
}
