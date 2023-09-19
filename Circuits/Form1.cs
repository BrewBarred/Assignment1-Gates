using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// The main GUI for the COMPX102 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor: Form1()
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

        } // end form1
        #endregion

        #region Class Scope Variables:
        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> gateList = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wiresList = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        protected Gate newGate = null;

        /// <summary>
        /// The compound that is currently being built (A collection of gates)
        /// </summary>
        protected Compound newCompound = null;

        /// <summary>
        /// True if this input is activated (live), else false (dead)
        /// </summary>
        protected bool _isLive = false;
        #endregion

        #region findPin(int x, int y)
        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x">X position of the pin to find</param>
        /// <param name="y">Y position of the pin to find</param>
        /// <returns>The pin that has been selected</returns>
        public Pin findPin(int x, int y)
        {
            // foreach gate in gateslist
            foreach (Gate g in gateList)
            {
                // foreach pin in pinslist of current gate
                foreach (Pin p in g.Pins)
                {
                    // if mouse is on the current pin
                    if (p.isMouseOn(x, y))
                        // returns the pin
                        return p;

                } // end foreach

            } // end foreach

            // if no pin is found, returns null
            return null;

        } // end pin
        #endregion

        #region Form1_MouseMove(object sender, MouseEventArgs e)
        /// <summary>
        /// Handles all events when the mouse is moving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // if the start pin not null
            if (startPin != null)
            {
                // sets current x and y positions
                currentX = e.X;
                currentY = e.Y;
                // causes the control to be redrawn
                Invalidate();
            }
            // else if the start x and y positions are greater than 0 and current isn't null
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                // moves the currently selected gate to the new location
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
                // causes the control to be redrawn at the new location
                Invalidate();
            }
            // else if the new gate is not nulled
            else if (newGate != null)
            {
                // sets the current x and y positions
                currentX = e.X;
                currentY = e.Y;
                // causes the control to be redrawn
                Invalidate();

            } // end if

        } // end void
        #endregion

        #region Form1_MouseUp(object sender, MouseEventArgs e)
        /// <summary>
        /// Handles all events when the mouse button is released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // if the start pin is not nulled
            if (startPin != null)
            {
                // writes start pin info to console
                Console.WriteLine("wire from " + startPin + " to " + e.X + "," + e.Y);
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);

                // if endPin is not nulled
                if (endPin != null)
                {
                    // writes the attempted conncetion info to the console
                    Console.WriteLine("Trying to connect " + startPin + " to " + endPin);

                    // creates an input and output pin object
                    Pin input, output;

                    // if start pin is an output pin
                    if (startPin.IsOutput)
                    {
                        // sets the input pin as the end pin
                        input = endPin;
                        // sets the output pin as the start pin
                        output = startPin;
                    }
                    // else if start pin is an input pin
                    else
                    {
                        // sets the input pin as the start pin
                        input = startPin;
                        // sets the output pin as the end pin
                        output = endPin;

                    } // end if

                    // if pins have been correctly allocated
                    if (input.Input && output.IsOutput)
                    {
                        // if this input pin has no wires attached to it
                        if (input.InputWire == null)
                        {
                            // creates a new wire object between the output 
                            // and the input pins selected by user
                            Wire newWire = new Wire(output, input);
                            // stores this input pins wire so that we can't attach more wires to it
                            input.InputWire = newWire;
                            // adds this wire to the wire list
                            wiresList.Add(newWire);
                        }
                        // else if this input pin has a wire attached to it
                        else
                        {
                            // writes error message to the user
                            MessageBox.Show("That input is already used.");

                        } // end if
                    }
                    // else if user has selected invalid pins
                    else
                    {
                        // writes error message to the user
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");

                    } // end if

                } // end if

                // nulls the start pin
                startPin = null;
                // redraws the current control
                Invalidate();

            } // end if

            // sets start x/y and current x/y to show 
            // that we have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;

        } // end void
        #endregion

        #region Button Click Events:

        #region AndGate
        /// <summary>
        /// Creates a new 'AndGate' object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAnd_Click(object sender, EventArgs e)
        {
            // creates a new AndGate object
            newGate = new AndGate(0, 0);

        } // end void
        #endregion

        #region OrGate
        /// <summary>
        /// Creates a new 'OrGate' object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOr_Click(object sender, EventArgs e)
        {
            // creates a new OrGate object
            newGate = new OrGate(0, 0);

        } // end void
        #endregion

        #region NotGate
        /// <summary>
        /// Creates a new 'NotGate' object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNot_Click(object sender, EventArgs e)
        {
            // creates a new NotGate object
            newGate = new NotGate(0, 0);

        } // end void
        #endregion

        #region Input
        /// <summary>
        /// Creates a new input object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonInput_Click(object sender, EventArgs e)
        {
            // creates a new input object
            newGate = new Input(0, 0);

        } // end void
        #endregion

        #region Output
        /// <summary>
        /// Creates a new output object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOutput_Click(object sender, EventArgs e)
        {
            // creates a new output object
            newGate = new Output(0, 0);

        } // end void
        #endregion

        #region CopyGate
        /// <summary>
        /// Duplicates the gate that is currently selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            // if a gate is currently selected
            if (current != null)
                // inserts a copy of the gate that is currently selected
                newGate = current.Clone();
            else MessageBox.Show("You must select a gate before trying to clone it!");

        } // end void
        #endregion

        #region Start Compounded Circuit
        /// <summary>
        /// Starts a compounded circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonStartCompound_Click(object sender, EventArgs e)
        {
            // if there a compound is not currently being created
            if (newCompound == null)
                // creates a new instance of a compound gate
                newCompound = new Compound(Width, Height);
            // else if a gate has not been selected
            else MessageBox.Show("You are already creating a compound gate!");

        } // end void
        #endregion

        #region End Compounded Circuit
        /// <summary>
        /// Ends a compunded circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonEndCompound_Click(object sender, EventArgs e)
        {
            // if a compound is currently being created
            if (newCompound != null)
            {
                // stores the new compound into the new gate variable
                newGate = newCompound;
                // writes info to console
                Console.WriteLine("Finished building compound circuit");
            }
            // else if a compound is not being created, shows error message
            else MessageBox.Show("You cannot end a compound that hasn't been started yet!");
            // nulls the new compound variable ready for a new one to be created
            newCompound = null;

        } // end void
        #endregion

        #region Evaluate
        /// <summary>
        /// Evaluates a circuit (tests functionality)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                // writes progress message of which gate type we are assessing
                Console.WriteLine("Beginning evaluation process... Please Wait...");
                // counts the number of outputs found
                int outputCount = 0;
                // counts the number of successful evaluations
                int passCount = 0;
                // counts the number of failed evaluations
                int failCount = 0;

                // foreach gate in the gates list
                foreach (Gate g in gateList)
                {
                    // writes evaluation progress message
                    Console.WriteLine(" Evaluating " + g.GetType().Name + "...");

                    // if this gate is an output
                    if (g is Output o)
                    {
                        // increments the output 
                        outputCount++;
                        // writes progress message of which gate type we are assessing
                        Console.WriteLine("Evaluating output " + outputCount + ", Please wait...");

                        // if this output evaluation returns successful
                        if (o.Evaluate())
                        {
                            // writes successful output evaluation result to console window
                            Console.WriteLine(" Output " + outputCount + ": Success!");
                            // increments the pass count
                            passCount++;
                        }
                        // else if this output evaluation is unsuccessful
                        else
                        {
                            // writes failed output evaluation result to console window
                            Console.WriteLine(" Output " + outputCount + ": Failed!");
                            // increments the fail count
                            failCount++;

                        } // end if

                    } // end if

                } // end foreach

                if (outputCount is 0)
                {
                    // writes error to console
                    Console.WriteLine("Evaluation error! Failed to find any outputs to evaluate!");
                    return;

                }
                // else if more than one input was found and evaluated
                else Console.WriteLine("Evaluation report:\n"
                                     + " Total outputs tested: " + outputCount.ToString().PadRight(10)
                                     + "Passed: " + passCount.ToString().PadRight(5)
                                     + "Failed: " + failCount.ToString().PadRight(5));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Evaluation error! Evaluation has failed due to: " + ex.Message);

            } // end try

        } // end void
        #endregion

        #endregion

        #region Form1_Paint(object sender, PaintEventArgs e)
        /// <summary>
        /// Redraws all the graphics for the current circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // foreach gate in gate list
            foreach (Gate g in gateList)
            {
                // draws the gate to the passed graphics object
                g.Draw(e.Graphics);

            } // end foreach

            // foreach wire in the wire list
            foreach (Wire w in wiresList)
            {
                // draws the wire to the passed graphics object
                w.Draw(e.Graphics);

            } // end foreach

            // if startPin is not nulled
            if (startPin != null)
            {
                // draws a start pin based on start x/y and current x/y positions
                e.Graphics.DrawLine(Pens.White, startPin.X, startPin.Y, currentX, currentY);

            } // end if

            // if newGate is not nulled
            if (newGate != null)
            {
                // shows the gate that we are dragging into the circuit
                newGate.MoveTo(currentX, currentY);
                // draws the gate to the passed graphics object
                newGate.Draw(e.Graphics);

            } // end if

        } // end void
        #endregion

        #region Form1_MouseDown(object sender, MouseEventArgs e)
        /// <summary>
        /// Handles events while the mouse button is pressed down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // if no gate is currently selected
            if (current is null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            // else if a compound gate is selected
            else if (current is Compound c)
            {
                // foreach gate in the compound list
                foreach (Gate g in c.CompoundList)
                {
                    // if the mouse is held down on the current gate
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        c.MoveTo(g.Left, g.Top);

                    } // end if

                } // end foreach

            }
            // else if the users mouse is on the currently selected gate
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // starts dragging the current object around
                startX = e.X;
                startY = e.Y;
                // monitors the location of where we are dragging the gate
                currentX = current.Left;
                currentY = current.Top;

            } // end if

        } // end void
        #endregion

        #region Form1_MouseClick(object sender, MouseEventArgs e)
        /// <summary>
        /// Handles all events when a mouse is clicked in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // if there is a gate selected
            if (current != null)
            {
                // unselect the selected gate
                current.Selected = false;
                // nulls the selected gate
                current = null;

            } // end if

            // check if we are inserting a new gate
            if (newGate != null)
            {
                // moves the new gate to the passed x/y position
                newGate.MoveTo(e.X, e.Y);
                // adds the new gate to the gates list
                gateList.Add(newGate);
                // nulls the newGate
                newGate = null;
            }
            // else if we are not inserting a new gate
            else
            {
                // foreach gate in the gatelist
                foreach (Gate g in gateList)
                {
                    // if this gate is a compound gate
                    if (g is Compound c)
                    {
                        // foreach gate in the compound list
                        foreach (Gate thisGate in c.CompoundList)
                        {
                            // if the mouse is hovering over one of these gates on click
                            if (thisGate.IsMouseOn(e.X, e.Y))
                            {
                                // selects all gates in the compound list
                                c.Selected = true;
                                // sets the current gate to this compound
                                current = c;
                                // breaks out of the loop as there is no need to keep checking
                                // if one of the gates have been clicked on
                                break;

                            } // end if

                        } // end foreach

                    }
                    // if the mouse is hovering over this gate current when mouse is clicked
                    else if (g.IsMouseOn(e.X, e.Y))
                    {
                        // and if a compound is currently being strung together
                        if (newCompound != null)
                        {
                            // adds the selected gate to the compound
                            newCompound.AddGate(g);
                        }
                        // else if a compound is not being strung together and this gate is an input
                        else if (g is Input i)
                        {
                            // if this input is currently live
                            if (i.IsLive)
                                // kills this input
                                i.IsLive = false;
                            // else if this input is currently dead
                            else
                                // livens this input
                                i.IsLive = true;

                            // writes current circuit power status to the console
                            Console.WriteLine("Power on: " + i.IsLive);

                        }
                        // else if a compound is not being strung and this gate is not an input
                        else
                        {
                            // selects this gate
                            g.Selected = true;
                            // sets this gate as the currently selected gate
                            current = g;
                        }

                    } // end if

                } // end foreach

            } // end if

            // redraws the control
            Invalidate();

        } // end void
        #endregion

    } // end class

} // end namespace
