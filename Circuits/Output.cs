using System;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an output with 1x input and no outputs
    /// </summary>
    public class Output : Gate
    {
        #region Constructor: Output(int x, int y) : base(x, y, _WIDTH)
        /// <summary>
        /// Constructs a new output control
        /// </summary>
        /// <param name="x">The x position of the new output</param>
        /// <param name="y">The y position of the new output</param>
        public Output(int x, int y) : base(x, y, _WIDTH)
        {
            // adds an input pin to the gate
            pins.Add(new Pin(this, true));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Constructor: Output(Input g) : base(g.Left, g.Top, g.Width)
        /// <summary>
        /// Clones the passed OutputGate
        /// </summary>
        /// <param name="g">Gate to clone</param>
        public Output(Output g) : base(g.Left, g.Top, g.Width)
        {
            // adds an input pin to the gate
            pins.Add(new Pin(this, true));
            // move the gate and the pins to the position passed in
            MoveTo(0, 0);

        } // end gate
        #endregion

        #region Class Scope Variables:
        /// <summary>
        /// Width of the output
        /// </summary>
        const int _WIDTH = 20;

        /// <summary>
        /// Height of the output (intentionally hides the inherited gate height)
        /// </summary>
        new const int _HEIGHT = 30;

        /// <summary>
        /// True if this output is live, false if it is dead
        /// </summary>
        bool _isLive;

        /// <summary>
        /// stores the width of the light bulb
        /// </summary>
        int bulbWidth = (_WIDTH * 2);

        /// <summary>
        /// stores the height of the light bulb
        /// </summary>
        int bulbHeight = (int)(_HEIGHT * 1.5);
        #endregion

        #region Getters/Setters

        #region IsLive
        /// <summary>
        /// Changes whether the circuit is currently live or dead (true = live, false = dead)
        /// </summary>
        public bool IsLive
        {
            // gets isLive status
            get { return _isLive; }
            // sets isLive status
            set { _isLive = value; }

        } // end bool
        #endregion

        #endregion

        #region Clone()
        /// <summary>
        /// Makes a copy of this gate
        /// </summary>
        public override Gate Clone()
        {
            // returns a clone of this gate
            return new Output(this);

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
                Console.WriteLine(" Evaluation Error: Input pin 1 on \"" + GetType().Name + "\" is not connected to anything!");
            }
            // else if all input pins have a connection
            else
            {
                // stores the gate that is connected to the 1st input pin of this control
                Gate gateA = pins[0].InputWire.FromPin.Owner;

                // if this output evaluates to true
                if (gateA.Evaluate())
                {
                    // livens this output
                    IsLive = true;
                    // evaluates the gate(s) that this control is connected to
                    return true;
                }
                // else if this out evaluates to false
                else
                {
                    // kills this output
                    IsLive = false;

                } // end if

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
            // centres the bulb around the mouse pointer
            x = x - _WIDTH;
            y = y - _HEIGHT / 2;

            // set the position of the gate to the values passed in
            _left = x;
            _top = y;

            // sets the position of the gates pins:

            // pin 0 = input pin (bottom side)
            pins[0].Location = new Point(x, y + (int)(_HEIGHT * 1.87));

        } // end void
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the output control in a set color based on whether it is live or not
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            // BASE PART OF LIGHT BULB (THE SCREW):

            // stores the x position of the light bulbs base
            int baseX = (Left + _WIDTH / 2);
            // stores the y position of the light bulbs base
            int baseY = (int)(Top + _HEIGHT * 1.2);
            // stores the width of the light bulbs base
            int baseWidth = Width * 2 / 2;
            // stores the height of the light bulbs base
            int baseHeight = (int)(_HEIGHT * 0.75);

            // foreach pin in the pin list
            foreach (Pin p in pins)
                // draws the pins on the passed graphics object
                p.Draw(paper);

            // stores the correct color of the brush
            Color brushColor = Color.DarkGray;

            // creates a brush object to fill the square to show that it is dead
            SolidBrush brush = new SolidBrush(brushColor);
            // creates a pen object to draw a square to represent an output control
            Pen penIsBlack = new Pen(Color.Black, 4);

            // draws a colored square to represent lightbulb base - color is based on whether output is live or not
            paper.FillRectangle(brush, baseX, baseY, baseWidth, baseHeight);

            // if this output is live
            if (IsLive)
                // sets the brush color to green
                brush.Color = Color.Yellow;
            // else if this output has been selected
            else if (Selected)
                // sets the brush color to red
                brush.Color = Color.Red;
            // else if this output is dead
            else
                // sets the brush color to gray
                brush.Color = Color.Gray;

            // draws a colored ellipse to represent lightbulb
            paper.FillEllipse(brush, new Rectangle(Left, Top, bulbWidth, bulbHeight));

        } // end void
        #endregion

        #region IsMouseOn(int x, int y)
        /// <summary>
        /// Checks if the output has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public override bool IsMouseOn(int x, int y)
        {
            // if the users mouse pointer is hovering over a gate
            if (Left <= x && x < Left + bulbWidth
                && Top <= y && y < Top + bulbHeight)
                return true;
            // else if the users mouse pointer is not hovering over a gate
            else
                return false;

        } // end bool
        #endregion

    } // end class

} // end namespace
