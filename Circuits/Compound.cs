namespace Circuits
{
    /// <summary>
    /// This class compounds a circuit into a single gate
    /// </summary>
    public class Compound : Gate
    {
        /// <summary>
        /// Width of the input
        /// </summary>
        protected int _inputWidth;

        //########## TEMPORARYILY ADDED TO STOP ERROR FROM INHERITING GATE WITHOUT A VALID CONSTRUCTOR #########
        public Compound(int x, int y, int inputWidth) : base(x, y, inputWidth)
        {
            // sets gateWidth field to the passed gateWidth
            _inputWidth = inputWidth;
            // adds two input pins to the gate
            pins.Add(new Pin(this, true));
            pins.Add(new Pin(this, true));
            // add an output pin to the gate
            pins.Add(new Pin(this, false));
            // move the gate and the pins to the position passed in
            MoveTo(x, y);

        } // end constructor

    } // end class

} // end namespace
