using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class Gate
    {
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
        protected bool selected = false;

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
        }

    } // end class

} // end namespace
