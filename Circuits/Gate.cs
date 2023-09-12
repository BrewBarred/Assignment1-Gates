using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// The length of the gate (dictates the starting point of pins)
        /// </summary>
        protected int _length;

        /// <summary>
        /// True if the gate is currently selected
        /// </summary>
        protected bool _selected = false;

        /// <summary>
        /// Width and height of the gates body
        /// </summary>
        protected const int _WIDTH = 40;
        protected const int _HEIGHT = 40;

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







        /// <summary>
        /// Gets the left hand edge of the gate.
        /// </summary>
        public int Left
        {
            // gets the left hand edge of the gate
            get { return _left; }

        } // end int

        /// <summary>
        /// Gets the top edge of the gate.
        /// </summary>
        public int Top
        {
            // gets the top edge of the gate
            get { return _top; }
        
        } // end int

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

        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public bool IsMouseOn(int x, int y)
        {
            // if the users mouse pointer is hovering over a gate
            if (_left <= x && x < _left + _WIDTH
                && _top <= y && y < _top + _HEIGHT)
                return true;
            // else if the users mouse pointer is not hovering over a gate
            else
                return false;

        } // end bool

        /// <summary>
        /// Gets the list of pins for the gate.
        /// </summary>
        public List<Pin> Pins
        {
            // gets the list of pins 
            get { return pins; }

        } // end list

        /// <summary>
        /// Base drawing method for a gate - this will be overriden to add
        /// the correct image from resources in each unique gate class
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public virtual void Draw(Graphics paper)
        {
            // foreach pin in the pin list
            foreach (Pin p in pins)
                // draws the pins on the passed graphics object
                p.Draw(paper);

        } // end void

    } // end class

} // end namespace
