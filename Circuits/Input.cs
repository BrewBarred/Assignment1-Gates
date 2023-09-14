using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an input object with no inputs and 1x output
    /// </summary>
    public class Input : Gate
    {
        #region Class Scope Variables:
        /// <summary>
        /// Width of the input 
        /// </summary>
        const int _WIDTH = 30;

        /// <summary>
        /// Height of the input (intentionally hides the inherited gate height)
        /// </summary>
        new const int _HEIGHT = 30;
        #endregion

        #region Input(int x, int y) : base(x, y, _WIDTH)
        public Input(int x, int y) : base(x, y, _WIDTH)
        {
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the input control in a set color based on whether it is live or not
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper, bool isLive)
        {
            // foreach pin in the pin list
            foreach (Pin p in pins)
                // draws the pins on the passed graphics object
                p.Draw(paper);

            // stores the correct color of the brush
            Color brushColor;

            // if this input is live
            if (isLive)
                // sets the brush color to green
                brushColor = Color.Green;
            // else if this input is dead
            else
                // sets the brush color to gray
                brushColor = Color.Gray;

            // creates a pen object to draw a square to represent an input control
            Pen penIsBlack = new Pen(Color.Black, 4);
            // draws a black square to represent the outline of the input control
            paper.DrawRectangle(penIsBlack, Left, Top, Width, _HEIGHT);
            // creates a brush object to fill the square to show that it is dead
            SolidBrush brush = new SolidBrush(brushColor);
            // draws a colored square based on whether the input is live or dead
            paper.FillRectangle(brush, Left, Top, Width, _HEIGHT);

        } // end void
        #endregion

        #region MoveTo(int x, int y)
        /// <summary>
        /// Moves the gate to the position specified
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public override void MoveTo(int x, int y)
        {
            // uses the base MoveTo method to move the gates body
            base.MoveTo(x, y);

            // sets the position of the gates pins:

            // pin 0 = output pin (right side)
            pins[0].Location = new Point(x + _WIDTH + _GAP, y + _HEIGHT / 2);

        } // end void
        #endregion

    } // end class

} // end namespace
