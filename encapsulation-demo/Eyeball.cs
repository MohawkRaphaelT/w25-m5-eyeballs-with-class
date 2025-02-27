// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Eyeball
    {
        public Vector2 position;
        public float corneaRadius;
        public float irisRadius;
        public float pupilRadius;
        public Color irisColor;
        bool isClickedOn;

        // Constructor
        public Eyeball()
        {
            position = Random.Vector2(Window.Size);
            corneaRadius = Random.Integer(10, 50);
            irisRadius = corneaRadius * 0.6f;
            pupilRadius = irisRadius * 0.6f;
            irisColor = Random.Color();
        }

        public Eyeball(Vector2 position, float corneaR, float irisR, float pupilR, Color color)
        {
            this.position = position;
            corneaRadius = corneaR;
            irisRadius = irisR;
            pupilRadius = pupilR;
            irisColor = color;
        }

        public void Render()
        {
            // Cornea
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.White;
            Draw.Circle(position, corneaRadius);

            if (isClickedOn)
            {
                // Line for closed eye
                Draw.Line(position.X - corneaRadius, position.Y, position.X + corneaRadius, position.Y);
            }
            else
            {
                // Iris
                Draw.FillColor = irisColor;
                Draw.Circle(position, irisRadius);
                // Pupil
                Draw.FillColor = Color.Black;
                Draw.Circle(position, pupilRadius);
            }
        }

        public bool HasClickedOnEye()
        {
            // Short circuit function. Return false if this
            // has already been clicked on
            if (isClickedOn)
            {
                return false;
            }

            // See if mouse is clicking on eye this frame
            float distanceMouseToEye = Vector2.Distance(position, Input.GetMousePosition());
            bool isMouseOnEye = distanceMouseToEye < corneaRadius;
            if (isMouseOnEye && Input.IsMouseButtonPressed(MouseInput.Left))
            {
                isClickedOn = true;
                return true;
            }

            return false;
        }
    }
}
