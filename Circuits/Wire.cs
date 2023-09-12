using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// A wire connects between two pins.
    /// That is, it connects the output pin FromPin 
    /// to the input pin ToPin.
    /// </summary>
    public class Wire
    {
        #region Class Scope Variables:
        /// <summary>
        /// Returns true if the wire has been selected
        /// </summary>
        protected bool _selected = false;
        /// <summary>
        /// The pins the wire is connected to
        /// </summary>
        protected Pin _fromPin, _toPin;
        #endregion

        #region Constructor: Wire(Pin from, Pin to)
        /// <summary>
        /// Initialises the object to the pins it is connected to.
        /// </summary>
        /// <param name="from">The pin the wire starts from</param>
        /// <param name="to">The pin the wire ends at</param>
        public Wire(Pin from, Pin to)
        {
            // the pin that this wire comes from
            _fromPin = from;
            // the pin that this wire goes to
            _toPin = to;

        } // end wire
        #endregion

        #region Selected
        /// <summary>
        /// Indicates whether this gate is currently selected or not
        /// </summary>
        public bool Selected
        {
            // gets the selection status of this gate
            get { return _selected; }
            // returns the select
            set { _selected = value; }

        } // end bool
        #endregion

        #region Getters/Setters:

        #region FromPin
        /// <summary>
        /// The output pin that this wire is connected to.
        /// </summary>
        public Pin FromPin
        {
            // gets the the output pin that this wire is connceted to
            get { return _fromPin; }

        } // end pin
        #endregion

        #region ToPin
        /// <summary>
        /// The input pin that this wire is connected to.
        /// </summary>
        public Pin ToPin
        {
            // gets the input pin this wire is connected to
            get { return _toPin; }

        } // end pin
        #endregion

        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the wire.
        /// </summary>
        /// <param name="paper"></param>
        public void Draw(Graphics paper)
        {
            //This is a short-hand way of doing an if statement.  It is saying if selected == true then 
            //use Color.Red else use Color.White and then create the wire
            Pen wire = new Pen(_selected ? Color.Red : Color.White, 3);
            //Draw the wire
            paper.DrawLine(wire, _fromPin.X, _fromPin.Y, _toPin.X, _toPin.Y);

        } // end void
        #endregion

    } // end class

} // end namespace
