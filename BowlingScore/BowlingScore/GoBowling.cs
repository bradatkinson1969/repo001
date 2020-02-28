using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScore
{
    public class GoBowling
    {
        public List<IFrame> Frames { get; private set; }
        public List<Ball> Balls { get; private set; }
        public int CurrentFrame { get; set; }
        private int _currentBallIndex;
        private readonly IPinPhysics _pinPhysics;

        public GoBowling(IPinPhysics pinPhysics)
        {
            _pinPhysics = pinPhysics;
            InitializeGame();
        }

        private void InitializeGame()
        {
            Frames = new List<IFrame>(10);
            for (int i = 1; i <= 10; i++)
            {
                if (i == 10)
                    Frames.Add(new Frame10() { FrameNumber = i, BonusOneEnabled = false, BonusTwoEnabled = false, BallThreeEnabled = false });
                else
                    Frames.Add(new Frame() { FrameNumber = i, BonusOneEnabled = false, BonusTwoEnabled = false, BallThreeEnabled = false });
            }

            Balls = new List<Ball>();
            CurrentFrame = 1;
            _currentBallIndex = 0;
        }

        public int ThrowBall(int whichBallInFrame)
        {
            int pinsNockedDown = NockDownPins(_currentBallIndex);
            
            RecordPinsNockedDown(whichBallInFrame, _currentBallIndex, pinsNockedDown);
            
            Balls.Add(new Ball { PinsNockedDown = pinsNockedDown });
            _currentBallIndex++;
            
            return pinsNockedDown;
        }

        public void NextFrame() 
        {
                CurrentFrame++; 
        }

        private int IndexOfCurrentFrame 
        {
            get { return CurrentFrame - 1; }
        }

        private int NockDownPins(int ballIndex)
        {
            int pinsStandingBeforeShot = Frames[IndexOfCurrentFrame].PinsStanding(Balls);
            return _pinPhysics.PinsFall(pinsStandingBeforeShot, ballIndex);
        }

        private void RecordPinsNockedDown(int whichBallInFrame, int ballIndex, int nockedDownPins)
        {
            switch (whichBallInFrame)
            {
                case 1:
                    if (nockedDownPins == 10)
                    {
                        RecordStrike(whichBallInFrame, ballIndex);
                    }
                    else
                    {
                        RecordNonStrike(whichBallInFrame, nockedDownPins, ballIndex);
                    }
                    break;
                case 2:
                    if (CurrentFrame == 10)
                    {
                        if (nockedDownPins == 10)
                        {
                            RecordStrike(whichBallInFrame, ballIndex);
                        }
                        else
                        {
                            RecordNonStrike(whichBallInFrame, nockedDownPins, ballIndex);
                        }
                    }
                    else
                    {
                        if (Frames[IndexOfCurrentFrame].PinsStanding(Balls) - nockedDownPins == 0)
                        {
                            RecordSpare(nockedDownPins, ballIndex);
                        }
                        else
                        {
                            RecordMissedSpare(nockedDownPins, ballIndex);
                        }
                    }
                    break;
                case 3:
                    RecordBonusBall(nockedDownPins, ballIndex);
                    break;
            }
        }
        
        private void RecordBonusBall(int knockedDownPins, int ballIndex)
        {
            RecordPinsFall(3, knockedDownPins, ballIndex);
        }

        private void RecordNonStrike(int whichBallInFrame, int knockedDownPins, int ballIndex)
        {
            RecordPinsFall(whichBallInFrame, knockedDownPins, ballIndex);
        }

        private void RecordStrike(int whichBallInFrame, int currentBallIndex)
        {
            RecordPinsFall(whichBallInFrame, 10, currentBallIndex);

            QueueStrikeBonuses();

            if (CurrentFrame == 10)
            {
                if (whichBallInFrame == 1)
                    EnableExtraBall();
            }
            else
            {
                NextFrame();
            }
        }

        private void EnableExtraBall()
        {
            Frames[9].BallThreeEnabled = true;
        }

        private void QueueStrikeBonuses()
        {
                Frames[IndexOfCurrentFrame].BonusOneEnabled = true;
                Frames[IndexOfCurrentFrame].BonusTwoEnabled = true;
        }

        private void RecordSpare(int knockedDownPins, int ballIndex)
        {
            RecordPinsFall(2, knockedDownPins, ballIndex);
            QueueSpareBonus();
            NextFrame();
        }

        private void RecordMissedSpare(int knockedDownPins, int ballIndex)
        {
            RecordPinsFall(2, knockedDownPins, ballIndex);
            NextFrame();
        }

        private void QueueSpareBonus()
        {
            Frames[IndexOfCurrentFrame].BonusTwoEnabled = true;
        }

        private void RecordPinsFall(int whichBallInFrame, int pins, int ballIndex)
        {
            switch (whichBallInFrame)
            {
                case 1:
                    Frames[IndexOfCurrentFrame].PinsFromBallOne = pins;
                    Frames[IndexOfCurrentFrame].BallOneIndex = ballIndex;
                    break;
                case 2:
                    Frames[IndexOfCurrentFrame].PinsFromBallTwo = pins;
                    Frames[IndexOfCurrentFrame].BallTwoIndex = ballIndex;
                    break;
                case 3:
                    Frames[IndexOfCurrentFrame].PinsFromBallThree = pins;
                    Frames[IndexOfCurrentFrame].BallThreeIndex = ballIndex;
                    break;
            }
        }
    }
}
