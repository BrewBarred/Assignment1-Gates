using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This is the superclass for all gate objects within the application
    /// </summary>
    public abstract class Gate
    {
        #region Constructor: Gate(int y, int y, int gateLength)
        /// <summary>
        /// Base constructor for each gate type
        /// </summary>
        /// <param name="x">The x position of the left edge of the gate object</param>
        /// <param name="y">The y position of the top edge of the gate object</param>
        /// <param name="gateLength">Length of the gate objects</param>
        public Gate(int x, int y, int gateLength)
        {
            // sets the gates left edge
            _left = x;
            // sets the gates top edge
            _top = y;
            // sets the gates body length
            _gateLength = gateLength;

        } // end gate
        #endregion

        #region Constructor: Gate()
        /// <summary>
        /// Alternative constructor for a Gate
        /// </summary>
        /// <param name="thisGate"></param>
        public Gate()
        {

        } // end gate
        #endregion

        #region Class Scope Variables/Constants:
        /// <summary>
        /// Left-hand side of the gates body (Helps with marking the location of the pins)
        /// </summary>
        protected int _left;

        /// <summary>
        /// Top-side of the gates body
        /// </summary>
        protected int _top;

        /// <summary>
        /// Length of the gates body
        /// </summary>
        protected int _gateLength;

        /// <summary>
        /// True if the gate is currently selected
        /// </summary>
        protected bool _selected;

        /// <summary>
        /// Height of the gates body
        /// </summary>
        protected const int _HEIGHT = 50;

        /// <summary>
        /// Length of the connector legs sticking out left and right
        /// </summary>
        protected const int _GAP = 10;

        /// <summary>
        /// Color of a selected gates body
        /// </summary>
        protected Brush selectedBrush = Brushes.Red;
        /// <summary>
        /// Color of an unselected gates body
        /// </summary>
        protected Brush normalBrush = Brushes.LightGray;

        /// <summary>
        /// This is the list of all the pins of a gate.
        /// </summary>
        protected List<Pin> pins = new List<Pin>();
        #endregion

        #region Getters/Setters:

        #region Left
        /// <summary>
        /// Gets the left hand edge of the gate.
        /// </summary>
        public int Left
        {
            // gets the left hand edge of the gate
            get { return _left; }

        } // end int
        #endregion

        #region Top
        /// <summary>
        /// Gets the top edge of the gate.
        /// </summary>
        public int Top
        {
            // gets the top edge of the gate
            get { return _top; }

        } // end int
        #endregion

        #region Width
        /// <summary>
        /// Gets the length of the gate
        /// </summary>
        public int Width
        {
            // gets the width of the gate
            get { return _gateLength; }

        } // end int
        #endregion

        #region Selected
        /// <summary>
        /// Gets and sets whether the gate is selected or not.
        /// </summary>
        public bool Selected
        {
            // gets the selection status of the gate
            get { return _selected; }
            // sets the selection status of the gate
            set
            { _selected = value; }

        } // end bool

        /// <summary>
        /// Gets the gates pin list
        /// </summary>
        public dynamic PinList
        {
            // gets the pin list
            get { return pins; }

        } // end list
        #endregion

        #region IsMouseOn(int x, int y)
        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public virtual bool IsMouseOn(int x, int y)
        {
            // if the users mouse pointer is hovering over a gate
            if (Left <= x && x < Left + Width
                && Top <= y && y < Top + _HEIGHT)
                return true;
            // else if the users mouse pointer is not hovering over a gate
            else
                return false;

        } // end bool
        #endregion

        #region Pins
        /// <summary>
        /// Gets the list of pins for the gate.
        /// </summary>
        public List<Pin> Pins
        {
            // gets the list of pins 
            get { return pins; }

        } // end list
        #endregion

        #endregion

        #region Abstract Methods:
        public abstract Gate Clone();
        public abstract bool Evaluate();
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Base method for drawing a gate - this will be overriden in each
        /// unique gate class to add the correct image from resources
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public virtual void Draw(Graphics paper)
        {
            // foreach pin in the pin list
            foreach (Pin p in pins)
                // draws the pins on the passed graphics object
                p.Draw(paper);

        } // end void
        #endregion

        #region MoveTo(int x, int y)
        /// <summary>
        /// Base method for moving a gate - this will be overriden in each
        /// unique gate class to move the pins too
        /// </summary>
        /// <param name="x">The left edge of this gate</param>
        /// <param name="y">The top edge of this gate</param>
        public abstract void MoveTo(int x, int y);
        #endregion

        #region ToString()
        /// <summary>
        /// Overrides ToString() method to show control name/type
        /// </summary>
        /// <returns>The name of the extended control as a string</returns>
        public override string ToString()
        {
            // gets this controls type and returns it's name
            return GetType().Name;

        } // end string
        #endregion

    } // end class

} // end namespace
