﻿using System;
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
        public Compound()
        {


        } // end compound
        #endregion

        #region Class Scope variables:
        /// <summary>
        /// List of gates contained within this compound
        /// </summary>
        List<Gate> compound = new List<Gate>();
        #endregion

        #region AddGate(Gate thisGate)
        /// <summary>
        /// Adds a gate to this compound
        /// </summary>
        public void AddGate(Gate thisGate)
        {
            // if the gate list doesn't already contain the selected gate
            if (!compound.Contains(thisGate))
            {
                // adds the passed gate to the compound
                compound.Add(thisGate);
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
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            // foreach gate in the compound
            foreach (Gate thisGate in compound)
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
            foreach (Gate thisGate in compound)
            {
                // moves this gate to the new x and y position
                thisGate.MoveTo(x + thisGate.Left, y + thisGate.Top);

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
            return new Compound();

        } // end void
        #endregion

    } // end class

} // end namespace
