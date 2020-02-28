using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScore
{
    public class SimulatedPinPhysics : IPinPhysics
    {
        public int PinsFall(int pinsStandingBeforeShot, int ballIndex)
        {
            Random howManyPinsFall = new Random();
            int pinsFell = howManyPinsFall.Next(0, pinsStandingBeforeShot);

            // CHEAT AND ADD PINS so my AutoBowler doesnt suck
            pinsFell += 3;
            if (pinsFell > pinsStandingBeforeShot)
                pinsFell = pinsStandingBeforeShot;

            return pinsFell;
        }
    }
}
