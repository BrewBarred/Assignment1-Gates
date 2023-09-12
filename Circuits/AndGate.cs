using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs and one output.
    /// </summary>
    public class AndGate : Gate
    {
        /// <summary>
        /// Initialises the Gate, 'AND' gates always have two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y)
        {
            // adds two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            // add an output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor

        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            // inherits the base drawing method to draw each pin for this gate
            base.Draw(paper);
            // draws an 'AND' gate object
            paper.DrawImage(Properties.Resources.AndGate, Left, Top);
            
        } // end void

        /// <summary>
        /// Moves the gate to the position specified
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public void MoveTo(int x, int y)
        {
            // debugging message
            Console.WriteLine("pins = " + pins.Count);

            // set the position of the gate to the values passed in
            _left = x;
            _top = y;

            pins[0].location =  new Point(x - _GAP, y + _GAP);
            // must move the pins too
            pins[0].X = x - _GAP;
            pins[0].Y = y + _GAP;
            pins[1].X = x - _GAP;
            pins[1].Y = y + _HEIGHT - _GAP;
            pins[2].X = x + _WIDTH + _GAP;
            pins[2].Y = y + _HEIGHT / 2;

        } // end void

    } // end class

} // end namespace
