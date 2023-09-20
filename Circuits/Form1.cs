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
        /// The number of outputs found while evaluating
        /// </summary>
        int _outputCount = 0;

        /// <summary>
        /// The number of successful evaluations
        /// </summary>
        int _passCount = 0;

        /// <summary>
        /// The number of failed evaluations
        /// </summary>
        int _failCount = 0;

        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int _startX, _startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin _startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int _currentX, _currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> _gateList = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> _wiresList = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate _current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        protected Gate _newGate = null;

        /// <summary>
        /// The compound that is currently being built (A collection of gates)
        /// </summary>
        protected Compound _newCompound = null;

        /// <summary>
        /// True if this input is activated (live), else false (dead)
        /// </summary>
        protected bool _isLive = false;
        #endregion

        #region Getters/Setters:

        #region OutputCount
        /// <summary>
        /// The number of outputs evaluated
        /// </summary>
        public int OutputCount
        {
            // gets the output count
            get { return _outputCount; }
            // sets the output count
            set { _outputCount = value; }

        } // end int
        #endregion

        #region PassCount
        /// <summary>
        /// The number of successful evaluations
        /// </summary>
        public int PassCount
        {
            // gets the pass count
            get { return _passCount; }
            // sets the pass count
            set { _passCount = value; }

        } // end int
        #endregion

        #region FailCount
        /// <summary>
        /// The number of failed evaluations
        /// </summary>
        public int FailCount
        {
            // gets the fail count
            get { return _failCount; }
            // sets the fail count
            set { _failCount = value; }

        } // end int
        #endregion

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
            foreach (Gate g in _gateList)
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
            if (_startPin != null)
            {
                // sets current x and y positions
                _currentX = e.X;
                _currentY = e.Y;
                // causes the control to be redrawn
                Invalidate();
            }
            // else if the start x and y positions are greater than 0 and current isn't null
            else if (_startX >= 0 && _startY >= 0 && _current != null)
            {
                // moves the currently selected gate to the new location
                _current.MoveTo(_currentX + (e.X - _startX), _currentY + (e.Y - _startY));
                // causes the control to be redrawn at the new location
                Invalidate();
            }
            // else if the new gate is not nulled
            else if (_newGate != null)
            {
                // sets the current x and y positions
                _currentX = e.X;
                _currentY = e.Y;
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
            if (_startPin != null)
            {
                // writes start pin info to console
                Console.WriteLine("wire from " + _startPin + " to " + e.X + "," + e.Y);
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);

                // if endPin is not nulled
                if (endPin != null)
                {
                    // writes the attempted conncetion info to the console
                    Console.WriteLine("Trying to connect " + _startPin + " to " + endPin);

                    // creates an input and output pin object
                    Pin input, output;

                    // if start pin is an output pin
                    if (_startPin.IsOutput)
                    {
                        // sets the input pin as the end pin
                        input = endPin;
                        // sets the output pin as the start pin
                        output = _startPin;
                    }
                    // else if start pin is an input pin
                    else
                    {
                        // sets the input pin as the start pin
                        input = _startPin;
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
                            _wiresList.Add(newWire);
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
                _startPin = null;
                // redraws the current control
                Invalidate();

            } // end if

            // sets start x/y and current x/y to show 
            // that we have finished moving/dragging
            _startX = -1;
            _startY = -1;
            _currentX = 0;
            _currentY = 0;

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
            _newGate = new AndGate(0, 0);

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
            _newGate = new OrGate(0, 0);

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
            _newGate = new NotGate(0, 0);

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
            _newGate = new Input(0, 0);

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
            _newGate = new Output(0, 0);

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
            if (_current != null)
                // inserts a copy of the gate that is currently selected
                _newGate = _current.Clone();
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
            if (_newCompound == null)
                // creates a new instance of a compound gate
                _newCompound = new Compound(Width, Height);
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
            if (_newCompound != null)
            {
                // add this compound to teh gatelist
                _gateList.Add(_newCompound);
                // stores the new compound into the new gate variable
                _current = _newCompound;

                // writes info to console
                Console.WriteLine("Finished building compound circuit! Removing contained gates from the gate list...");

                // foreach gate in the gate list
                foreach (Gate g in _newCompound.CompoundList)
                {
                    // and if the newcompound list contains this gate
                    if (_newCompound.CompoundList.Contains(g))
                    {
                        // removes this gate from the list, since it is embedded in the compound now
                        _gateList.Remove(g);

                    } // end if

                } // end foreach

            }
            // else if a compound is not being created, shows error message
            else MessageBox.Show("You cannot end a compound that hasn't been started yet!");
            // nulls the new compound variable ready for a new one to be created
            _newCompound = null;

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
                // the number of outputs evaluated
                OutputCount = 0;
                // the number of successful evaluations
                PassCount = 0;
                // the number of failed evaluations
                FailCount = 0;

                // writes progress message of which gate type we are assessing
                Console.WriteLine("Beginning evaluation process... Please Wait...");

                // foreach gate in the gates list
                foreach (Gate g in _gateList)
                {
                    // if this gate is an output
                    if (g is Output o)
                    {
                        // increments the output 
                        OutputCount++;
                        // evaluates this gate for validity
                        Evaluate(o);

                    }
                    // else if this gate is a compound gate
                    else if (g is Compound c)
                    {
                        // evaluates this gate for validity
                        Evaluate(c);

                    } // end if

                } // end foreach

                // if no outputs were found
                if (OutputCount is 0)
                {
                    // writes error to console
                    Console.WriteLine("" + "\nEvaluation error! Failed to find any outputs to evaluate!");
                    return;

                }
                // else if more than one input was found and evaluated
                else Console.WriteLine("Evaluation report:".PadRight(5)
                                     + " Total outputs tested: " + OutputCount.ToString().PadRight(5)
                                     + "Passed: " + PassCount.ToString().PadRight(5)
                                     + "Failed: " + FailCount.ToString().PadRight(5));

                // redraws all controls
                Invalidate();
            }
            catch (Exception ex)
            {
                // writes debugging message to console
                Console.WriteLine("Evaluation error! Evaluation has failed due to: " + ex.Message);

            } // end try

        } // end void
        #endregion

        #region Evaluate(Gate g)
        public void Evaluate(Gate g)
        {
            // writes progress message of which gate type we are assessing
            Console.WriteLine("Evaluating output " + OutputCount + ", Please wait...");

            // if this output evaluation returns successful
            if (g.Evaluate())
            {
                // writes successful output evaluation result to console window
                Console.WriteLine(" Output " + OutputCount + ": Success!");
                // increments the pass count
                PassCount++;
            }
            // else if this output evaluation is unsuccessful
            else
            {
                // writes failed output evaluation result to console window
                Console.WriteLine(" Output " + OutputCount + ": Failed!");
                // increments the fail count
                FailCount++;

            } // end if

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
            foreach (Gate g in _gateList)
            {
                // draws the gate to the passed graphics object
                g.Draw(e.Graphics);

            } // end foreach

            // foreach wire in the wire list
            foreach (Wire w in _wiresList)
            {
                // draws the wire to the passed graphics object
                w.Draw(e.Graphics);

            } // end foreach

            // if startPin is not nulled
            if (_startPin != null)
            {
                // draws a start pin based on start x/y and current x/y positions
                e.Graphics.DrawLine(Pens.White, _startPin.X, _startPin.Y, _currentX, _currentY);

            } // end if

            // if newGate is not nulled
            if (_newGate != null)
            {
                // shows the gate that we are dragging into the circuit
                _newGate.MoveTo(_currentX, _currentY);
                // draws the gate to the passed graphics object
                _newGate.Draw(e.Graphics);

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
            if (_current is null)
            {
                // try to start adding a wire
                _startPin = findPin(e.X, e.Y);
            }
            // else if the users mouse is on the currently selected gate
            else if (_current.IsMouseOn(e.X, e.Y) || _current is Compound)
            {
                // starts dragging the current object around
                _startX = e.X;
                _startY = e.Y;
                // monitors the location of where we are dragging the gate
                _currentX = _current.Left;
                _currentY = _current.Top;

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
            // if user is constructing a new compound circuit
            if (_newCompound != null)
            {

            }
            // if user is not constructing a new compound circuit and a gate is currently selected
            else if (_current != null)
            {
                // unselect the selected gate
                _current.Selected = false;
                // nulls the selected gate
                _current = null;

            } // end if// end if

            // check if we are inserting a new gate
            if (_newGate != null)
            {
                // moves the new gate to the passed x/y position
                _newGate.MoveTo(e.X, e.Y);
                // adds the new gate to the gates list
                _gateList.Add(_newGate);
                // nulls the newGate
                _newGate = null;

            }
            // else if we are not inserting a new gate
            else
            {
                // foreach gate in the gatelist
                foreach (Gate g in _gateList)
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
                                // if this gate is an input and a new compound is not being constructed
                                if (thisGate is Input i && _newCompound == null)
                                {
                                    // if this input is currently live
                                    if (i.IsLive)
                                        // kills this input
                                        i.IsLive = false;
                                    // else if this input is currently dead
                                    else
                                    {
                                        // livens this input
                                        i.IsLive = true;

                                    } // end if

                                }
                                // else if this gate is not an input or a new compound is under construction
                                else
                                {
                                    // selects all gates in the compound list
                                    c.Selected = true;
                                    // sets the current gate to this compound
                                    _current = c;
                                    // breaks out of the loop as there is no need to keep checking
                                    // if one of the gates have been clicked on
                                    break;
                                }

                            } // end if

                        } // end foreach

                    }
                    // else if the mouse is hovering over this gate when mouse is clicked
                    else if (g.IsMouseOn(e.X, e.Y))
                    {
                        // and if a compound is currently being strung together
                        if (_newCompound != null)
                        {
                            // adds the selected gate to the compound
                            _newCompound.AddGate(g);

                        } // end if

                        // if this gate is an input
                        if (g is Input i)
                        {
                            // if this input is currently live
                            if (i.IsLive)
                                // kills this input
                                i.IsLive = false;
                            // else if this input is currently dead
                            else
                            {
                                // livens this input
                                i.IsLive = true;

                            } // end if

                            // writes current circuit power status to the console
                            Console.WriteLine("Power on: " + i.IsLive);

                            // selects this input
                            i.Selected = true;
                            // sets this input to the current gate so it can be moved
                            _current = i;

                        }
                        // else if a compound is not being strung and this gate is not an input
                        else
                        {
                            // selects this gate
                            g.Selected = true;
                            // sets this gate as the currently selected gate
                            _current = g;

                        } // end if

                    } // end if

                } // end foreach

            } // end if

            // evaluates all outputs to see if they should be on/off
            CheckOutputs();
            // redraws all controls
            Invalidate();

        } // end void
        #endregion

        #region Liven()
        /// <summary>
        /// Checks all outputs to see if they should be livened
        /// </summary>
        public void CheckOutputs()
        {
            // foreach gate in this gatelist
            foreach (Gate thisGate in _gateList)
            {
                // if this gate is an output
                if (thisGate is Output gOut)
                {
                    // evaluates this output
                    gOut.Evaluate();
                    // continues to next gate
                    continue;
                }
                // else if this gate is a compound gate
                else if (thisGate is Compound c)
                {
                    // foreach gate in the compound list
                    foreach (Gate g in c.CompoundList)
                    {
                        // if this gate is an output
                        if (g is Output cOut)
                        {
                            // evaluates this output
                            cOut.Evaluate();

                        } // end if

                    } // end foreach

                } // end if

            } // end foreach

        } // end void
        #endregion

    } // end class

} // end namespace
