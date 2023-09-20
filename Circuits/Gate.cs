using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This is the superclass for all gate objects within the application
    /// </summary>
    public abstract class Gate
    {
        #region Constructor: Gate(int y, int y, int gateWidth)
        /// <summary>
        /// Base constructor for each gate type
        /// </summary>
        /// <param name="x">The x position of the left edge of the gate object</param>
        /// <param name="y">The y position of the top edge of the gate object</param>
        /// <param name="gateWidth">Width of the gate objects</param>
        public Gate(int x, int y, int gateWidth)
        {
            // sets the gates left edge
            Left = x;
            // sets the gates top edge
            Top = y;
            // sets the gates body length
            Width = gateWidth;

        } // end gate
        #endregion

        #region Constructor: Gate(int x, int y)
        /// <summary>
        /// Alternative constructor for a Gate
        /// </summary>
        public Gate(int x, int y)
        {
            // sets the left position of this gate to the passed x value
            Left = x;
            // sets the top of this gate to the passed y value
            Top = y;

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
        protected int _width;

        /// <summary>
        /// Height of the gates body
        /// </summary>
        protected int _height = 50;

        /// <summary>
        /// Location of this gate (x and y pos)
        /// </summary>
        protected Point _location;

        /// <summary>
        /// Length of the connector legs sticking out left and right
        /// </summary>
        protected const int _GAP = 10;

        /// <summary>
        /// True if the gate is currently selected
        /// </summary>
        protected bool _selected;

        /// <summary>
        /// Height of the gates body
        /// </summary>
        protected const int _HEIGHT = 50;

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

        #region Abstract Methods:
        /// <summary>
        /// Makes a copy of the extended control
        /// </summary>
        /// <returns>A duplicate of the gate that is currently selected</returns>
        public abstract Gate Clone();
        /// <summary>
        /// Evaluates circuits for validity
        /// </summary>
        /// <returns>True is circuit is validated, else returns false</returns>
        public abstract bool Evaluate();
        /// <summary>
        /// Moves a gate to the passed x and y position
        /// </summary>
        /// <param name="x">The left edge of this gate</param>
        /// <param name="y">The top edge of this gate</param>
        public abstract void MoveTo(int x, int y);
        #endregion

        #region Getters/Setters:

        #region Left
        /// <summary>
        /// Gets/sets the left hand edge of the gate.
        /// </summary>
        public int Left
        {
            // gets the left hand edge of the gate
            get { return _left; }
            // sets the left hand edge of the gate
            set
            {
                // sets the x value in the location point
                _location = new Point(value, _location.Y);
                // sets the left hand edge of the gate
                _left = value;

            } // end set

        } // end int
        #endregion

        #region Top
        /// <summary>
        /// Gets/sets the top edge of the gate.
        /// </summary>
        public int Top
        {
            // gets the top edge of the gate
            get { return _top; }
            // sets the top edge of the gate
            set
            {
                // sets the y value of the location point
                _location = new Point(_location.X, value);
                // sets the top edge of the gate
                _top = value;
            }

        } // end int
        #endregion

        #region Width
        /// <summary>
        /// Gets/sets the width of the gate
        /// </summary>
        public int Width
        {
            // gets the width of the gate
            get { return _width; }
            // sets the width of the gate
            set { _width = value; }

        } // end int
        #endregion

        #region Height
        /// <summary>
        /// Gets the height of the gate
        /// </summary>
        public int Height
        {
            // gets the height of the gate
            get { return _height; }
            // sets the height of the gate
            set { _height = value; }

        } // end int
        #endregion

        #region Location
        /// <summary>
        /// Gets/sets this gates location (x, y)
        /// </summary>
        public Point Location
        {
            // gets this gates location
            get { return new Point(_location.X, _location.Y); }
            // sets this gates location
            set
            {
                // sets this gates location
                _location = value;
                // sets this gates x position
                _left = _location.X;
                // sets this gates y position
                _top = _location.Y;

            } // end set

        } // end point
        #endregion

        #region Selected
        /// <summary>
        /// Gets and sets whether the gate is selected or not.
        /// </summary>
        public virtual bool Selected
        {
            // gets the selection status of this gate
            get { return _selected; }
            // sets the selection status of this gate
            set
            {
                // if this gate is a compound gate
                if (this is Compound c)
                    // sets each gate in the compound to the passed value
                    c.IsSelected(value);
                // sets the selection status of this gate to the passed value
                _selected = value;

            } // end set

        } // end bool
        #endregion

        #region PinList
        /// <summary>
        /// Gets the gates pin list
        /// </summary>
        public List<Pin> PinList
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

    } // end class

} // end namespace
