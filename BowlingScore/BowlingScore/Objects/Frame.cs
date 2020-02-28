using System.Collections.Generic;

namespace BowlingScore
{
    public class Frame : IFrame
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
        public int? BonusOneIndex {
            get {
                int? retVal = null;

                if (BonusOneEnabled) 
                {
                    retVal = BallOneIndex + 1;
                }

                return retVal;
            }
        }
        public int? BonusTwoIndex
        {
            get
            {
                int? retVal = null;

                if (BonusTwoEnabled)
                    retVal = BallOneIndex + 2;

                return retVal;
            }
        }
        public int? PinsFromBonusOne { get; set; }
        public int? PinsFromBonusTwo { get; set; }
        public int PinsStanding(List<Ball> balls)
        {
            int retVal = 10;

            if (BallOneIndex.HasValue && BallTwoIndex.HasValue)
                retVal = 10 - balls[BallOneIndex.Value].PinsNockedDown.GetValueOrDefault() + balls[BallTwoIndex.Value].PinsNockedDown.GetValueOrDefault();
            else if (BallOneIndex.HasValue && !BallTwoIndex.HasValue)
                retVal = 10 - balls[BallOneIndex.Value].PinsNockedDown.GetValueOrDefault();
            else if (!BallOneIndex.HasValue && BallTwoIndex.HasValue)
                retVal = 10 - balls[BallTwoIndex.Value].PinsNockedDown.GetValueOrDefault();
            
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
            }

            if (BonusOneEnabled || BonusTwoEnabled)
            {
                if (BonusOneEnabled)
                {
                    if (balls.Count > BonusOneIndex.GetValueOrDefault())
                    {
                        score += balls[BonusOneIndex.Value].PinsNockedDown;
                    }
                    else
                    {
                        score = null;
                    }
                }

                if (BonusTwoEnabled)
                {
                    if (balls.Count > BonusTwoIndex.GetValueOrDefault())
                    {
                        score += balls[BonusTwoIndex.Value].PinsNockedDown;
                    }
                    else
                    {
                        score = null;
                    }
                }
            }
                        
            return score;
        }
    }
}