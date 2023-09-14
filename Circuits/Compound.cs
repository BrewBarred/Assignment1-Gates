namespace Circuits
{
    /// <summary>
    /// This class compounds a circuit into a single gate
    /// </summary>
    public class Compound : Gate
    {
        //########## TEMPORARYILY ADDED TO STOP ERROR FROM INHERITING GATE WITHOUT A VALID CONSTRUCTOR #########
        #region Constructor: CopyGate(int x, int y, int gateWidth) : base(x, y, gateWidth)
        public Compound(int x, int y, int gateWidth) : base(x, y, gateWidth)
        {
            // adds two input pins to the gate
            pins.Add(new Pin(this, true));
            pins.Add(new Pin(this, true));
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

        #region Class Scope Variables:
        /// <summary>
        /// Width of the input
        /// </summary>
        protected int _inputWidth;

        #endregion

        #region
        /// <summary>
        /// Evaluates this input and returns the result
        /// </summary>
        /// <returns>True if the input is activated/live, false if the output is activated/live</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool Evaluate()
        {
            throw new System.NotImplementedException();

        } // end bool
        #endregion

    } // end class

} // end namespace
