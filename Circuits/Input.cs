using System;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an input object with no inputs and 1x output
    /// </summary>
    public class Input : Gate
    {
        #region Constructor: Input(int x, int y) : base(x, y, _WIDTH)
        /// <summary>
        /// Constructs a new input control
        /// </summary>
        /// <param name="x">The x position of the new input</param>
        /// <param name="y">The y position of the new input</param>
        public Input(int x, int y) : base(x, y, _WIDTH)
        {
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Constructor: Input(Input g) : base(g.Left, g.Top, g.Width)
        /// <summary>
        /// Clones the passed InputGate
        /// </summary>
        /// <param name="g">Gate to clone</param>
        public Input(Input g) : base(g.Left, g.Top, g.Width)
        {
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(0, 0);

        } // end gate
        #endregion

        #region Class Scope Variables:
        /// <summary>
        /// Width of the input 
        /// </summary>
        const int _WIDTH = 30;

        /// <summary>
        /// Height of the input (intentionally hides the inherited gate height)
        /// </summary>
        new const int _HEIGHT = 30;

        /// <summary>
        /// True if this input is live, false if it is dead
        /// </summary>
        bool _isLive;

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
            return new Input(this);

        } // end void
        #endregion

        #region Evaluate()
        /// <summary>
        /// Evaluates if this input is currently activated or not
        /// </summary>
        /// <returns>True if the input is activated/live, false if the output is activated/live</returns>
        public override bool Evaluate()
        {
            // if this input is live/activated
            if (IsLive)
            {
                // returns the current state of the input (activated/deactivated)
                return true;
            }
            // else if this input is dead/deactivated
            else
            {
                // writes an error to the console
                Console.WriteLine(" Error! " + base.ToString() + " has not been turned on!");
                return false;

            } // end if

        } // end bool
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the input control in a set color based on whether it is live or not
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            // foreach pin in the pin list
            foreach (Pin p in pins)
                // draws the pins on the passed graphics object
                p.Draw(paper);

            // stores the correct color of the brush
            Color brushColor;

            // if this input is live
            if (IsLive)
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
            // centres this input control around the mouse pointer
            x = x - _WIDTH / 2;
            y = y - _HEIGHT / 2;

            // uses the base MoveTo method to move the gates body
            base.MoveTo(x, y);

            // pin 0 = output pin (right side)
            pins[0].Location = new Point(x + _WIDTH + _GAP, y + _HEIGHT / 2);

        } // end void
        #endregion

    } // end class

} // end namespace
