using System;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an AndGate with 2x inputs and 1x output.
    /// </summary>
    public class AndGate : Gate
    {
        #region Constructor: AndGate(int x, int y)
        /// <summary>
        /// Initializes the Gate, 'AND' gates always have two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y) : base(x, y, _WIDTH)
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

        #region Class Scope Variables:
        /// <summary>
        /// Width of an AndGates body
        /// </summary>
        protected const int _WIDTH = 55;

        #endregion

        #region Evaluate()
        /// <summary>
        /// Evaluates this control for validity
        /// </summary>
        /// <returns>True if all inputs are connected, false if any of the inputs have no connections to them</returns>
        public override bool Evaluate()
        {
            // if gate A has no connection to it
            if (pins[0].InputWire is null || pins[1] is null)
            {
                // writes error to console
                Console.WriteLine("Error! One or more pins on \"" + GetType().Name + "\" is not connected to anything!");
                return false;
            }
            // else if all input pins have a connection
            else
            {
                // stores the gate that is connected to the 1st input pin of this control
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                // stores the gate that is connected to the 2nd input pin of this control
                Gate gateB = pins[1].InputWire.FromPin.Owner;
                // writes progress message of which gate type we are assessing
                Console.WriteLine("Evaluating \"" + GetType().Name + "\", Please wait...");
                // writes info on each gates connection status
                Console.WriteLine("Gate A is connected: \"" + pins[0].IsConnected + "\", Gate B is connected: \"" + pins[1].IsConnected);
                // evaluates the gate(s) that this control is connected to
                return gateA.Evaluate() && gateB.Evaluate();

            } // end 

            /*
            // true if all input pins have wires connected to them
            bool isConnected = true;

            // foreach pin that this control has
            foreach (Pin p in Pins)
            {
                // if this pin is an input pin
                if (p.Input is true)
                    // and if this pin has a wire connected to it
                    if (p.IsConnected)
                        // continues to loop through the rest of the pins
                        continue;
                    // else if this input point has no wires connected to it
                    else
                    {
                        // writes error to console
                        Console.WriteLine("Error! Input " + p.Info() + " has no connection on \"" + base.ToString() + "\"");
                        // sets the connection status to false
                        isConnected = false;

                    } // end if

            } // end foreach

            // returns true since we cannot get to this
            // point if any of the input pins are invalid
            return isConnected;
            */

        } // end bool
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

            // if this gate is currently selected
            if (Selected)
                // draws a selected version of this gate object
                paper.DrawImage(Properties.Resources.AndGateAllRed, Left, Top);
            // else if this gate is not currently selected
            else
                // draws an unselected version of this gate object
                paper.DrawImage(Properties.Resources.AndGate, Left, Top);

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
