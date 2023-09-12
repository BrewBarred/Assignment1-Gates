namespace Circuits
{
    /// <summary>
    /// This class evaluates the current circuit to test it for correct functionality
    /// </summary>
    public abstract class Evaluate : Gate
    {
        /// <summary>
        /// Width of the input
        /// </summary>
        protected int _componentWidth;

        //########## TEMPORARYILY ADDED TO STOP ERROR FROM INHERITING GATE WITHOUT A VALID CONSTRUCTOR #########
        public Evaluate(int x, int y, int componentWidth) : base(x, y, componentWidth)
        {
            // sets gateWidth field to the passed gateWidth
            _componentWidth = componentWidth;
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
