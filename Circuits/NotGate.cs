﻿using System;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements a NotGate with 2x inputs and 1x output
    /// </summary>
    public class NotGate : Gate
    {
        #region Constructor: NotGate(int x, int y) : base(x, y, _WIDTH)
        /// <summary>
        /// Constructs a new 'NOT' Gate. 'NOT' gates only have 1 input (pin 0)
        /// and one output pin (pin 1).
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public NotGate(int x, int y) : base(x, y, _WIDTH)
        {
            // adds an input pin to the gate
            pins.Add(new Pin(this, true));
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Constructor: NotGate(AndGate g) : base(g.Left, g.Top, g.Width)
        /// <summary>
        /// Clones the passed NotGate
        /// </summary>
        /// <param name="g">Gate to clone</param>
        public NotGate(NotGate g) : base(g.Left, g.Top, g.Width)
        {
            // adds an input pin to the gate
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
            // if gate A has no connection to it
            if (pins[0].IsConnected is false)
            {
                // writes error to console
                Console.WriteLine(" Evaluation Error: Input pin on \"" + GetType().Name + "\" is not connected to anything!");
            }
            // else if all input pins have a connection
            else
            {
                // stores the gate that is connected to the input pin of this control
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                // evaluates the gate(s) that this control is connected to
                return !gateA.Evaluate();

            } // end if

            // if we get to this point, one or more pins are not connected
            return false;

        } // end bool
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

            // set the position of the gate to the values passed in
            _left = x;
            _top = y;

            // sets the position of the gates pins:

            // pins 0 and 1 = input pins (left side)
            pins[0].Location = new Point(x - _GAP, y + _HEIGHT / 2);
            // pin 1 = output pin (right side)
            pins[1].Location = new Point(x + _WIDTH + _GAP, y + _HEIGHT / 2);

        } // end void
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

    } // end class

} // end namespace
