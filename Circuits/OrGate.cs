using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an OrGate with 2x inputs and 1x output
    /// </summary>
    public class OrGate : Gate
    {
        #region Constructor: AndGate(int x, int y)
        /// <summary>
        /// Initializes the Gate, 'OR' gates always have two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public OrGate(int x, int y) : base(x, y, _WIDTH)
        {
            // adds two input pins to the gate
            pins.Add(new Pin(this, true));
            pins.Add(new Pin(this, true));
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Class Scope Variables:
        /// <summary>
        /// Width of an OrGates body
        /// </summary>
        protected const int _WIDTH = 70;

        #endregion

        #region Evaluate()
        /// <summary>
        /// Evaluates this input and returns the result
        /// </summary>
        /// <returns>True if the input is activated/live, false if the output is activated/live</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool Evaluate()
        {
            throw new System.NotImplementedException();

        } // end bool
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            // inherits the base drawing method to draw each pin for this gate
            base.Draw(paper);

            // if this gate is currently selected
            if (Selected)
                // draws a selected version of this gate object
                paper.DrawImage(Properties.Resources.OrGateAllRed, Left, Top);
            // else if this gate is not currently selected
            else
                // draws an unselected version of this gate object
                paper.DrawImage(Properties.Resources.OrGate, Left, Top);

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
            // centres this input control around the mouse pointer
            x = x - _WIDTH / 2;
            y = y - _HEIGHT / 2;

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
