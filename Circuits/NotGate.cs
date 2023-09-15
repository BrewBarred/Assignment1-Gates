using System;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements a NotGate with 2x inputs and 1x output
    /// </summary>
    public class NotGate : Gate
    {
        #region Constructor: NotGate(int x, int y)
        /// <summary>
        /// Constructs a new 'NOT' Gate. 'NOT' gates always have two inputs (pins 0 & 1)
        /// and one output pin (pin 2).
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public NotGate(int x, int y) : base(x, y, _WIDTH)
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

        #region Constructor: NotGate(AndGate g) : base(g.Left, g.Top, g.Width)
        /// <summary>
        /// Clones the passed OrGate
        /// </summary>
        /// <param name="g">Gate to clone</param>
        public NotGate(NotGate g) : base(g.Left, g.Top, g.Width)
        {
            // adds two input pins to the gate
            pins.Add(new Pin(this, true));
            pins.Add(new Pin(this, true));
            // add an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(0, 0);

        } // end gate
        #endregion

        #region Class Scope Variables:
        /// <summary>
        /// Width of a NotGates body
        /// </summary>
        protected const int _WIDTH = 55;

        #endregion

        #region Clone()
        /// <summary>
        /// Makes a copy of this gate
        /// </summary>
        public override Gate Clone()
        {
            // returns a clone of this gate
            return new NotGate(this);

        } // end void
        #endregion

        #region Evaluate()
        /// <summary>
        /// Evaluates this control for validity
        /// </summary>
        /// <returns>True if all inputs are connected, false if any of the inputs have no connections to them</returns>
        public override bool Evaluate()
        {
            // writes progress message of which gate type we are assessing
            Console.WriteLine("Evaluating \"" + GetType().Name + "\", Please wait...");

            // if gate A has no connection to it
            if (pins[0].IsConnected is false)
            {
                // writes error to console
                Console.WriteLine("Evaluation Error: Input pin 1 on \"" + GetType().Name + "\" is not connected to anything!");
            }
            // else if gate B has no connection to it
            else if (pins[1].IsConnected is false)
            {
                // writes error to console
                Console.WriteLine("Evaluation Error: Input pin 2 on \"" + GetType().Name + "\" is not connected to anything!");
            }
            // else if all input pins have a connection
            else
            {
                // stores the gate that is connected to the 1st input pin of this control
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                // stores the gate that is connected to the 2nd input pin of this control
                Gate gateB = pins[1].InputWire.FromPin.Owner;
                // writes info on each gates connection status
                Console.WriteLine("Gate A is connected: \"" + pins[0].IsConnected + "\", Gate B is connected: \"" + pins[1].IsConnected);
                // evaluates the gate(s) that this control is connected to
                return gateA.Evaluate() && gateB.Evaluate();

            } // end if

            // if we get to this point, one or more pins are not connected
            return false;

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
                paper.DrawImage(Properties.Resources.NotGateAllRed, Left, Top);
            // else if this gate is not currently selected
            else
                // draws an unselected version of this gate object
                paper.DrawImage(Properties.Resources.NotGate, Left, Top);

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
