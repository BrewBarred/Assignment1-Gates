namespace Circuits
{
    /// <summary>
    /// This class copies an existing gate and duplicates it
    /// </summary>
    public class CopyGate : Gate
    {
        protected int _gateWidth = 0;

        //########## TEMPORARYILY ADDED TO STOP ERROR FROM INHERITING GATE WITHOUT A VALID CONSTRUCTOR #########
        public CopyGate(int x, int y, int gateWidth) : base(x, y, gateWidth)
        {
            // sets gateWidth field to the passed gateWidth
            _gateWidth = gateWidth;
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
