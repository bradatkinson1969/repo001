using System.Collections.Generic;

namespace BowlingScore
{
    public interface IFrame
    {
        int? BallOneIndex { get; set; }
        int? BallTwoIndex { get; set; }
        int? BallThreeIndex { get; set; }
        bool BallThreeEnabled { get; set; }
        bool BonusOneEnabled { get; set; }
        int? BonusOneIndex { get; }
        bool BonusTwoEnabled { get; set; }
        int? BonusTwoIndex { get; }
        int FrameNumber { get; set; }
        int? PinsFromBallOne { get; set; }
        int? PinsFromBallTwo { get; set; }
        int? PinsFromBallThree { get; set; }
        int? PinsFromBonusOne { get; set; }
        int? PinsFromBonusTwo { get; set; }

        int? FrameScore(List<Ball> balls);
        int PinsStanding(List<Ball> balls);
    }
}