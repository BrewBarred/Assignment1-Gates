namespace Circuits
{
    /// <summary>
    /// This class implements an output with 1x input
    /// </summary>
    public class Output : Gate
    {
        /// <summary>
        /// Width of the input
        /// </summary>
        protected int _outputWidth;

        //########## TEMPORARYILY ADDED TO STOP ERROR FROM INHERITING GATE WITHOUT A VALID CONSTRUCTOR #########
        #region Output (int x, int y, int outputWidth) : base (x, y, outputWidth)
        public Output(int x, int y, int outputWidth) : base(x, y, outputWidth)
        {
            // sets gateWidth field to the passed gateWidth
            _outputWidth = outputWidth;
            // adds two input pins to the gate
            pins.Add(new Pin(this, true));
            pins.Add(new Pin(this, true));
            // adds an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor
        #endregion

    } // end class

} // end namespace
