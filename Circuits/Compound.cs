using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    public class Compound : Gate
    {
        #region Constructor:
        /// <summary>
        /// Constructs a new group of gates incl. pins + wires and groups them as a compound.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public Compound(Gate thisGate) : base(thisGate)
        {

        } // end compound
        #endregion

        #region Class Scope variables:
        /// <summary>
        /// List of gates contained within this compound
        /// </summary>
        List<Gate> gateList = new List<Gate>();
        #endregion

        #region AddGate()
        /// <summary>
        /// Adds a gate to this compound
        /// </summary>
        public void AddGate(Gate thisGate)
        {
            // adds the passed gate to the compound
            gateList.Add(thisGate);

        } // end void
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            // inherits the base drawing method to draw each pin for this gate
            base.Draw(paper);

            // foreach gate in the compound
            foreach (Gate thisGate in gateList)
            {
                // draws the current gate
                thisGate.Draw(paper);

            } // end foreach

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
            foreach (Gate thisGate in gateList)
            {
                x = thisGate.Left;
                y = thisGate.Top;
                int width = thisGate.Width;
                // centres this input control around the mouse pointer
                x = x - width / 2;
                y = y - _HEIGHT / 2;

                // uses the base MoveTo method to move the gates body
                base.MoveTo(x, y);

                // sets the position of the gates pins:

                // pins 0 and 1 = input pins (left side)
                pins[0].Location = new Point(x - _GAP, y + _GAP);
                pins[1].Location = new Point(x - _GAP, y + _HEIGHT - _GAP);
                // pin 2 = output pin (right side)
                pins[2].Location = new Point(x + width + _GAP, y + _HEIGHT / 2);
            }

        } // end void
        #endregion

        #region Evaluate()
        /// <summary>
        /// Evaluates all controls in this compound for validity
        /// </summary>
        /// <returns>True if all controls are valid</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool Evaluate()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Clone()
        /// <summary>
        /// Makes a copy of this compound
        /// </summary>
        /// <returns></returns>
        public override Gate Clone()
        {

            return null;

        } // end void
        #endregion

    } // end class

} // end namespace
