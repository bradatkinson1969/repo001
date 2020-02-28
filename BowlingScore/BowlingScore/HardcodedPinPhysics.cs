using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScore
{
    public class HardcodedPinPhysics : IPinPhysics
    {
        private int[] _preLoadedBalls;

        public HardcodedPinPhysics(int[] preLoadedBalls)
        {
            _preLoadedBalls = preLoadedBalls;
        }

        public int PinsFall(int pinsStandingBeforeShot, int ballIndex)
        {
            int retVal;

            retVal = _preLoadedBalls[ballIndex];
            
            return retVal;
        }
    }
}
