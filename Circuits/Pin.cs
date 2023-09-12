using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// Each Pin represents an input or an output of a gate.
    /// Every Pin knows which gate it belongs to
    /// (and the Gate property returns this).
    /// 
    /// Input pins can be connected to at most one wire
    /// (see the InputWire property).
    /// 
    /// Output pins may have lots of wires pointing to them,
    /// but they don't know anything about this.
    /// </summary>
    public class Pin
    {
        #region Class Scope Variables:
        /// <summary>
        /// The x and y position of the pin
        /// </summary>
        protected Point _location;
        /// <summary>
        /// The input value coming into the pin
        /// </summary>
        protected bool _input;
        /// <summary>
        /// The length of a pin
        /// </summary>
        protected const int _pinLength = 20;
        /// <summary>
        /// The height of a pin
        /// </summary>
        protected const int _pinHeight = 3;
        /// <summary>
        /// The gate the pin belongs to
        /// </summary>
        protected Gate _owner;
        /// <summary>
        /// The wire connected to the pin
        /// </summary>
        protected Wire _connection;
        #endregion

        #region Constructor: Pin(Gate gate, bool isInput, int length)
        /// <summary>
        /// Initialises the object to the values passed in.
        /// </summary>
        /// <param name="gate">The gate that this pin is attached to</param>
        /// <param name="isInput">The type of pin (True for input, false for output)</param>
        public Pin(Gate gate, bool isInput)
        {
            // the gate this pin belongs to
            _owner = gate;
            // the input value coming to this pin (true if input, false if output)
            _input = isInput;

        } // end pin
        #endregion

        #region Getters/Setters

        #region IsInput
        /// <summary>
        /// A read-only property that returns true for input pins
        /// and false for output pins.
        /// </summary>
        public bool IsInput
        {
            // gets input pin status
            get { return _input; }

        } // end bool
        #endregion

        #region IsOutput
        /// <summary>
        /// Returns true for output pins, false for input pins.
        /// </summary>
        public bool IsOutput
        {
            // gets output pin status
            get { return !_input; }

        } // end bool
        #endregion

        #region Owner
        /// <summary>
        /// This read-only property returns the gate that this pin
        /// belongs to.
        /// </summary>
        public Gate Owner
        {
            // gets the owner of the current gate
            get { return _owner; }

        } // end con
        #endregion

        #region InputWire
        /// <summary>
        /// For input pins, this gets or sets the wire that is coming
        /// into the pin.  (Input pins can only be connected to one wire)
        /// For output pins, sets are ignored and get always returns null.
        /// </summary>
        public Wire InputWire
        {
            // gets the wire that is coming into this pin
            get
            {
                // returns the wire coming into this pin
                return _connection;

            } // end get

            // sets the wire that is coming into this pin
            set
            {
                // if this pin is an input pin
                if (_input)
                {
                    // sets the wire coming into this pin to the passed value
                    _connection = value;

                } // end if

            } // end set

        } // end wire
        #endregion

        #region location
        /// <summary>
        /// Gets or sets the location of this pin.
        /// For input pins, this is at the left hand side of the pin
        /// For output pins, this is at the right hand side of the pin
        /// </summary>
        public Point Location
        {
            // gets this pins current location
            get { return _location; }

            // sets this pins new location
            set { _location = value; }

        } // end point
        #endregion

        #region X
        /// <summary>
        /// Gets the x position of this pin
        /// </summary>
        public int X
        { get { return Location.X; } }
        #endregion

        #region Y
        /// <summary>
        /// Gets the y position of this pin
        /// </summary>
        public int Y
        { get { return Location.Y; } }
        #endregion

        #endregion

        #region isMouseOn(int mouseX, int mouseY)
        /// <summary>
        /// True if (mouseX, mouseY) is within 3 pixels of the business
        /// end of the pin.
        /// </summary>
        /// <param name="mouseX">The X position of the mouse</param>
        /// <param name="mouseY">The Y position of the mouse</param>
        /// <returns>true if mouse is close to the main end of the pin</returns>
        public bool isMouseOn(int mouseX, int mouseY)
        {
            // sets x diff to the difference between mouse x pos and pins x pos
            int diffX = mouseX - _location.X;
            // sets y diff to the difference between mouse y pos and pings y pos
            int diffY = mouseY - _location.Y;
            // true if diff x squared plus diff y squared is less than 25 (don't ask me why)
            return diffX * diffX + diffY * diffY <= 5 * 5;

        } // end bool
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws a pin to a passed graphics object
        /// </summary>
        /// <param name="paper">Graphics object to draw the pin on</param>
        public void Draw(Graphics paper)
        {
            // creates a brush object to draw with
            Brush brush = Brushes.DarkGray;

            // if this pin is an input pin
            if (_input)
            {
                // draws a rectangle to represent a pin on the left-hand side of the gates body
                paper.FillRectangle(brush, Location.X - 1, Location.Y - 1, _pinLength, _pinHeight); ;
            }
            // else if this pin is an output pin
            else
            {
                // draws a rectangle to represent a pin on the right-hand side of the gates body
                paper.FillRectangle(brush, Location.X - _pinLength + 1, Location.Y - 1, _pinLength, _pinHeight);

            } // end if

        } // end void
        #endregion

        #region ToString()
        /// <summary>
        /// Gets the x and y position of the Pin
        /// </summary>
        /// <returns>The x and y position of the pin as a string</returns>
        public override string ToString()
        {
            // if this pin is an input pin
            if (_input)
                // returns the input pins info as a string
                return "InPin(" + Location.X + "," + Location.Y + ")";
            // else if this pin is an output pin
            else
                // returns th output pins info as a string
                return "OutPin(" + Location.X + "," + Location.Y + ")";

        } // end string
        #endregion

    } // end class

} // end namespace
