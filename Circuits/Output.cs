using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This class implements an output with 1x input
    /// </summary>
    public class Output : Gate
    {
        #region Constructor: Output(int x, int y) : base(x, y, _WIDTH)
        public Output(int x, int y) : base(x, y, _WIDTH)
        {
            // adds an input pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
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
        /// Draws the output control in a set color based on whether it is live or not
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            // foreach pin in the pin list
            foreach (Pin p in pins)
                // draws the pins on the passed graphics object
                p.Draw(paper);

            // BULB PART OF LIGHT BULB (THE GLASS):

            // stores the width of the light bulb
            int bulbWidth = (Width * 2);
            // stores the height of the light bulb
            int bulbHeight = (int)(_HEIGHT * 1.5);

            // BASE PART OF LIGHT BULB (THE SCREW):

            // stores the x position of the light bulbs base
            int baseX = (int)(Left + Width / 2);
            // stores the y position of the light bulbs base
            int baseY = (int)(Top + _HEIGHT * 1.2);
            // stores the width of the light bulbs base
            int baseWidth = (int)Width * 2 / 2;
            // stores the height of the light bulbs base
            int baseHeight = (int)(_HEIGHT * 0.75);

            // stores the correct color of the brush
            Color brushColor = Color.DarkGray;

            // creates a brush object to fill the square to show that it is dead
            SolidBrush brush = new SolidBrush(brushColor);
            // creates a pen object to draw a square to represent an output control
            Pen penIsBlack = new Pen(Color.Black, 4);

            // draws a colored square to represent lightbulb base - color is based on whether output is live or not
            paper.FillRectangle(brush, baseX, baseY, baseWidth, baseHeight);

            // if this input is live
            if (IsLive)
                // sets the brush color to green
                brush.Color = Color.Yellow;
            // else if this input is dead
            else
                // sets the brush color to gray
                brush.Color = Color.Gray;

            // draws a colored ellipse to represent lightbulb
            paper.FillEllipse(brush, new Rectangle(Left, Top, bulbWidth, bulbHeight));

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
            // centres the bulb around the mouse pointer
            x = x - _WIDTH;
            y = y - _HEIGHT / 2;

            // uses the base MoveTo method to move the gates body
            base.MoveTo(x, y);

            // sets the position of the gates pins:

            // pin 0 = input pin (bottom side)
            pins[0].Location = new Point(x + _WIDTH / 2, y + (int)(_HEIGHT * 1.87));

        } // end void
        #endregion

    } // end class

} // end namespace
