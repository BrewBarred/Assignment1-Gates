using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an output with 1x input
    /// </summary>
    public class Output : Gate
    {
        #region Class Scope Variables:
        /// <summary>
        /// Width of the output
        /// </summary>
        const int _WIDTH = 20;

        /// <summary>
        /// Height of the output (intentionally hides the inherited gate height)
        /// </summary>
        new const int _HEIGHT = 30;
        #endregion

        #region Output(int x, int y) : base(x, y, _WIDTH)
        public Output(int x, int y) : base(x, y, _WIDTH)
        {
            // adds an input pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the output control in a set color based on whether it is live or not
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            // inherits the base drawing method to draw each pin for this gate
            base.Draw(paper);

            // creates a pen object to draw a square to represent an output control
            Pen penIsBlack = new Pen(Color.Black, 4);

            // stores the correct color of the brush
            Color brushColor;

            // if this input is live
            if (IsLive)
                // sets the brush color to green
                brushColor = Color.Yellow;
            // else if this input is dead
            else
                // sets the brush color to gray
                brushColor = Color.Gray;

            int bulbHeight = _HEIGHT;

            // creates a brush object to fill the square to show that it is dead
            SolidBrush brush = new SolidBrush(brushColor);
            // draws a colored ellipse to represent lightbulb
            paper.FillEllipse(brush, new Rectangle(Left, Top, Width * 2, (int)(bulbHeight * 1.5)));
            // draws a colored square to represent lightbulb base - color is based on whether output is live or not
            paper.FillRectangle(brush, Left + Width / 2, (int)(Top + _HEIGHT * 1.2), Width * 2 / 2, (int)(_HEIGHT * 0.75));

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

            // pin 0 = input pin (bottom side)
            pins[0].Location = new Point(x + _WIDTH / 2, y + (int)(_HEIGHT * 2.75));

        } // end void
        #endregion

    } // end class

} // end namespace
