using System;
using System.Collections.Generic;
using System.Drawing;

namespace Circuits
{
    public class Compound : Gate
    {
        #region Constructor: Compound()
        /// <summary>
        /// Constructs a new group of gates incl. pins + wires and groups them as a compound.
        /// </summary>
        public Compound()
        {


        } // end compound
        #endregion

        #region Constructor: Compound(Compound thisCompound)
        /// <summary>
        /// Constructs a cloned group of gates incl. pins + wires and groups them as a compound.
        /// </summary>
        public Compound(Compound thisCompound)
        {
            // clones the passed compound list and stores it into this compound list
            _compoundList = thisCompound._compoundList;

        } // end compound
        #endregion

        #region Class Scope variables:
        /// <summary>
        /// List of gates contained within this compound
        /// </summary>
        protected List<Gate> _compoundList = new List<Gate>();
        #endregion

        #region Getters/Setters

        #region CompoundList
        /// <summary>
        /// Gets the compound list
        /// </summary>
        public List<Gate> CompoundList
        {
            // gets the compound list
            get { return _compoundList; }

        } // end compound
        #endregion

        #endregion

        #region Select(bool value)
        /// <summary>
        /// Selects/Deselects all gates in the compound list
        /// </summary>
        public void IsSelected(bool value)
        {
            // foreach gate in the compound
            foreach (Gate g in CompoundList)
            {
                // sets the current gate selection to true or false based on passed bool
                g.Selected = value;

            } // end foreach

            // writes debugging info to console
            Console.WriteLine("Compound circuit selection status = " + value);

        } // end bool
        #endregion

        #region AddGate(Gate thisGate)
        /// <summary>
        /// Adds a gate to this compound
        /// </summary>
        public void AddGate(Gate thisGate)
        {
            // if the gate list doesn't already contain the selected gate
            if (!_compoundList.Contains(thisGate))
            {
                // adds the passed gate to the compound
                _compoundList.Add(thisGate);
                // writes info to console
                Console.WriteLine("Added " + thisGate.GetType().Name + " to the compound");
            }
            // else if the gate list already contains the selected gate
            else Console.WriteLine("Failed to add " + thisGate.GetType().Name + " because it is already apart of the compound!");

        } // end void
        #endregion

        #region Draw(Graphics paper)
        /// <summary>
        /// Draws all of the gates in this compound
        /// </summary>
        /// <param name="paper">Graphics object to draw on</param>
        public override void Draw(Graphics paper)
        {
            // foreach gate in the compound
            foreach (Gate thisGate in CompoundList)
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
            // foreach gate in the gate list
            foreach (Gate thisGate in CompoundList)
            {
                // moves this gate to the new x and y position
                thisGate.MoveTo(x, y);

            } // end foreach

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
            // clones this compound list
            return new Compound(this);

        } // end void
        #endregion

    } // end class

} // end namespace
