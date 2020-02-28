using System.Collections.Generic;

namespace BowlingScore
{
    public class Frame10 : IFrame
    {
        public int FrameNumber { get; set; }
        public int? BallOneIndex { get; set; }
        public int? BallTwoIndex { get; set; }
        public int? BallThreeIndex { get; set; }
        public int? PinsFromBallOne { get; set; }
        public int? PinsFromBallTwo { get; set; }
        public int? PinsFromBallThree { get; set; }
        public bool BallThreeEnabled { get; set; }
        public bool BonusOneEnabled { get; set; }
        public bool BonusTwoEnabled { get; set; }
        public int? BonusOneIndex { get { return null; } }
        public int? BonusTwoIndex { get { return null; } }
        public int? PinsFromBonusOne { get; set; }
        public int? PinsFromBonusTwo { get; set; }

        public int PinsStanding(List<Ball> balls)
        {
            int retVal;
            int pinsNockedDownFromBallOne = 0;
            int pinsNockedDownFromBallTwo = 0;

            if (BallOneIndex.HasValue)
                pinsNockedDownFromBallOne = balls[BallOneIndex.Value].PinsNockedDown.GetValueOrDefault();
            
            if (BallTwoIndex.HasValue)
                pinsNockedDownFromBallTwo = balls[BallTwoIndex.Value].PinsNockedDown.GetValueOrDefault();

            if(pinsNockedDownFromBallOne == 10 || pinsNockedDownFromBallTwo == 10)
                retVal = 10; //this is reloading when a strike
            else
                retVal = 10 - pinsNockedDownFromBallOne - pinsNockedDownFromBallTwo;

            if (retVal < 0)
                retVal = 0;

            return retVal;
        }

        public int? FrameScore(List<Ball> balls)
        {
            int? score = null;

            if (BallOneIndex.HasValue)
            {
                score = balls[BallOneIndex.Value].PinsNockedDown.GetValueOrDefault();

                if (BallTwoIndex.HasValue)
                    score += balls[BallTwoIndex.Value].PinsNockedDown.GetValueOrDefault();

                if (BallThreeIndex.HasValue)
                    score += balls[BallThreeIndex.Value].PinsNockedDown.GetValueOrDefault();
            }

            return score;
        }
    }
}