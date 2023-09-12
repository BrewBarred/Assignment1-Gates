using System;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs and one output.
    /// </summary>
    public class AndGate : Gate
    {

        #region AndGate(int x, int y)
        /// <summary>
        /// Initializes the Gate, 'AND' gates always have two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y) : base(x, y)
        {
            // adds two input pins to the gate
            pins.Add(new Pin(this, true));
            pins.Add(new Pin(this, true));
            // add an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            // inherits the base drawing method to draw each pin for this gate
            base.Draw(paper);
            // draws an 'AND' gate object
            paper.DrawImage(Properties.Resources.AndGate, Left, Top);

        } // end void
        #endregion

        #region MoveTo(int x, int y)
        /// <summary>
        /// Moves the gate to the position specified
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public void MoveTo(int x, int y)
        {
            // debugging message
            Console.WriteLine("Number of pins = " + pins.Count);

            // set the position of the gate to the values passed in
            _left = x;
            _top = y;

            // sets the position of the gates pins
            pins[0].location = new Point(x - _GAP, y + _GAP);
            pins[1].location = new Point(x - _GAP, y + _HEIGHT - _GAP);
            pins[2].location = new Point(x + _WIDTH + _GAP, y + _HEIGHT / 2);

        } // end void
        #endregion

    } // end class

} // end namespace
