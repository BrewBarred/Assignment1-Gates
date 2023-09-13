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
        /// True if this input is activated (live), else false (dead)
        /// </summary>
        bool isLive = false;
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
        public override void Draw(Graphics paper)
        {
            // inherits the base drawing method to draw each pin for this gate
            base.Draw(paper);

            // stores the correct color of the brush
            Color color;

            // if this input is currently selected
            if (Selected)
                // sets the drawing color to green
                color = Color.Red;
            // else if this gate is currently unselected and is activated
            else if (isLive)
                color = Color.Green;
            // draws an unselected dead version of this gate object
            else
                color = Color.Gray;

            // creates a pen object to draw a square to represent an input control
            Pen penIsBlack = new Pen(Color.Black);
            // creates a brush object to fill the square to show that it is dead
            SolidBrush brushIsGrey = new SolidBrush(color);

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

            // pins 0 and 1 = input pins (left side)
            pins[0].Location = new Point(x - _GAP, y + _GAP);
            pins[1].Location = new Point(x - _GAP, y + _HEIGHT - _GAP);
            // pin 2 = output pin (right side)
            pins[2].Location = new Point(x + _WIDTH + _GAP, y + _HEIGHT / 2);

        } // end void
        #endregion

    } // end class

} // end namespace
