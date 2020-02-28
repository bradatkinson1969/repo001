using BowlingScore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bowling.Tests
{
    class CalculateScoreTests
    {
        private List<Ball> balls;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTotalScore_AllStrikes()
        {
            //Assemble
            List<IFrame> frames = new List<IFrame>(10);

            IFrame frame1 = new Frame() { FrameNumber = 1, BallOneIndex = 0, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame1);
            IFrame frame2 = new Frame() { FrameNumber = 2, BallOneIndex = 1, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame2);
            IFrame frame3 = new Frame() { FrameNumber = 3, BallOneIndex = 2, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame3);
            IFrame frame4 = new Frame() { FrameNumber = 4, BallOneIndex = 3, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame4);
            IFrame frame5 = new Frame() { FrameNumber = 5, BallOneIndex = 4, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame5);
            IFrame frame6 = new Frame() { FrameNumber = 6, BallOneIndex = 5, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame6);
            IFrame frame7 = new Frame() { FrameNumber = 7, BallOneIndex = 6, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame7);
            IFrame frame8 = new Frame() { FrameNumber = 8, BallOneIndex = 7, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame8);
            IFrame frame9 = new Frame() { FrameNumber = 9, BallOneIndex = 8, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame9);
            IFrame frame10 = new Frame10() { FrameNumber = 10, BallOneIndex = 9, BallTwoIndex = 10, BallThreeEnabled = true, BallThreeIndex = 11 };
            frames.Add(frame10);

            balls = new List<Ball>()
            {
                new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
            };

            //Act
            CalculateScore calculator = new CalculateScore();
            int? totalScore = calculator.TotalScore(frames, balls, 9);

            //Assert
            Assert.AreEqual(300, totalScore);
        }

        [Test]
        public void TestTotalScore_AllSpares()
        {
            //Assemble
            List<IFrame> frames = new List<IFrame>(10);

            IFrame frame1 = new Frame() { FrameNumber = 1, BallOneIndex = 0, BallTwoIndex = 1, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame1);
            IFrame frame2 = new Frame() { FrameNumber = 2, BallOneIndex = 2, BallTwoIndex = 3, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame2);
            IFrame frame3 = new Frame() { FrameNumber = 3, BallOneIndex = 4, BallTwoIndex = 5, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame3);
            IFrame frame4 = new Frame() { FrameNumber = 4, BallOneIndex = 6, BallTwoIndex = 7, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame4);
            IFrame frame5 = new Frame() { FrameNumber = 5, BallOneIndex = 8, BallTwoIndex = 9, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame5);
            IFrame frame6 = new Frame() { FrameNumber = 6, BallOneIndex = 10, BallTwoIndex = 11, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame6);
            IFrame frame7 = new Frame() { FrameNumber = 7, BallOneIndex = 13, BallTwoIndex = 14, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame7);
            IFrame frame8 = new Frame() { FrameNumber = 8, BallOneIndex = 15, BallTwoIndex = 16, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame8);
            IFrame frame9 = new Frame() { FrameNumber = 9, BallOneIndex = 17, BallTwoIndex = 18, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame9);
            IFrame frame10 = new Frame10() { FrameNumber = 10, BallOneIndex = 19, BallTwoIndex = 20, BallThreeEnabled = false };
            frames.Add(frame10);

            balls = new List<Ball>()
            {
                new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
            };

            //Act
            CalculateScore calculator = new CalculateScore();
            int? totalScore = calculator.TotalScore(frames, balls, 9);

            //Assert
            Assert.AreEqual(145, totalScore);
        }


        [Test]
        public void TestTotalScore_AllSparesAfterFrame5()
        {
            //Assemble
            List<IFrame> frames = new List<IFrame>(5);

            IFrame frame1 = new Frame() { FrameNumber = 1, BallOneIndex = 0, BallTwoIndex = 1, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame1);
            IFrame frame2 = new Frame() { FrameNumber = 2, BallOneIndex = 2, BallTwoIndex = 3, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame2);
            IFrame frame3 = new Frame() { FrameNumber = 3, BallOneIndex = 4, BallTwoIndex = 5, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame3);
            IFrame frame4 = new Frame() { FrameNumber = 4, BallOneIndex = 6, BallTwoIndex = 7, BonusOneEnabled = false, BonusTwoEnabled = true };
            frames.Add(frame4);
            IFrame frame5 = new Frame() { FrameNumber = 5, BallOneIndex = 8, BallTwoIndex = 9, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame5);

            balls = new List<Ball>()
            {
                new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 4 }
            };

            //Act
            CalculateScore calculator = new CalculateScore();
            int? totalScore = calculator.TotalScore(frames, balls, 4);

            //Assert
            Assert.AreEqual(69, totalScore);
        }

        [Test]
        public void TestTotalScore_NoSparesAfterFrame5()
        {
            //Assemble
            List<IFrame> frames = new List<IFrame>(5);

            IFrame frame1 = new Frame() { FrameNumber = 1, BallOneIndex = 0, BallTwoIndex = 1, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame1);
            IFrame frame2 = new Frame() { FrameNumber = 2, BallOneIndex = 2, BallTwoIndex = 3, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame2);
            IFrame frame3 = new Frame() { FrameNumber = 3, BallOneIndex = 4, BallTwoIndex = 5, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame3);
            IFrame frame4 = new Frame() { FrameNumber = 4, BallOneIndex = 6, BallTwoIndex = 7, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame4);
            IFrame frame5 = new Frame() { FrameNumber = 5, BallOneIndex = 8, BallTwoIndex = 9, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame5);

            balls = new List<Ball>()
            {
                new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 4 }
                ,new Ball {PinsNockedDown = 3 }
                ,new Ball {PinsNockedDown = 2 }
                ,new Ball {PinsNockedDown = 1 }
                ,new Ball {PinsNockedDown = 0 }
                ,new Ball {PinsNockedDown = 1 }
                ,new Ball {PinsNockedDown = 2 }
                ,new Ball {PinsNockedDown = 3 }
                ,new Ball {PinsNockedDown = 4 }
            };

            //Act
            CalculateScore calculator = new CalculateScore();
            int? totalScore = calculator.TotalScore(frames, balls, 4);

            //Assert
            Assert.AreEqual(25, totalScore);
        }

        [Test]
        public void TestTotalScore_PendingBonusAfterFrame1ReturnNull()
        {
            //Assemble
            List<IFrame> frames = new List<IFrame>(5);

            IFrame frame1 = new Frame() { FrameNumber = 1, BallOneIndex = 0, BallTwoIndex = 1, BonusOneEnabled = false, BonusTwoEnabled = false };
            frames.Add(frame1);
            IFrame frame2 = new Frame() { FrameNumber = 2, BallOneIndex = 2, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };
            frames.Add(frame2);

            balls = new List<Ball>()
            {
                new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 4 }
                ,new Ball {PinsNockedDown = 10 }
            };

            //Act
            CalculateScore calculator = new CalculateScore();
            int? totalScore = calculator.TotalScore(frames, balls, 1);

            //Assert
            Assert.AreEqual(null, totalScore);
        }
    }
}
