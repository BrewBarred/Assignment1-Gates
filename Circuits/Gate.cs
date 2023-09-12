using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    /// <summary>
    /// This is the superclass for all gate objects within the application
    /// </summary>
    public class Gate
    {
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
        /// True if the gate is currently selected
        /// </summary>
        protected bool _selected = false;

        /// <summary>
        /// Width of the gates body
        /// </summary>
        protected const int _WIDTH = 55;

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

        #region Constructor: Gate(int y, int y, int gateLength)
        /// <summary>
        /// Constructs a new gate object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Gate(int x, int y)
        {
            // sets the left field to the passed x pos
            _left = x;
            // sets the top field to the passed y pos
            _top = y;

        } // end gate
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

        #region Selected
        /// <summary>
        /// Gets and sets whether the gate is selected or not.
        /// </summary>
        public bool Selected
        {
            // gets the selection status of the gate
            get { return _selected; }
            // sets the selection status of the gate
            set { _selected = value; }

        } // end bool
        #endregion

        #region IsMouseOn(int x, int y)
        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public bool IsMouseOn(int x, int y)
        {
            // if the users mouse pointer is hovering over a gate
            if (Left <= x && x < Left + _WIDTH
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

        #region MoveTo(int x, int y)
        /// <summary>
        /// Base method for moving a gate - this will be overriden in each
        /// unique gate class to move the pins too
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void MoveTo(int x, int y)
        {
            // set the position of the gate to the values passed in
            _left = x;
            _top = y;

        } // end void
        #endregion

    } // end class

} // end namespace
