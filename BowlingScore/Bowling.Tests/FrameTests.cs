using BowlingScore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bowling.Tests
{
    public class Tests
    {
        private List<Ball> balls;
        
        [SetUp]
        public void Setup()
        {
            balls = new List<Ball>()
            {
                new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }

                ,new Ball {PinsNockedDown = 6 }
                ,new Ball {PinsNockedDown = 3 }

                ,new Ball {PinsNockedDown = 10 }
                
                ,new Ball {PinsNockedDown = 7 }
                ,new Ball {PinsNockedDown = 2 }
                
                ,new Ball {PinsNockedDown = 8 }
                ,new Ball {PinsNockedDown = 2 }
                
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 5 }
                
                ,new Ball {PinsNockedDown = 0 }
                ,new Ball {PinsNockedDown = 6 }
                
                ,new Ball {PinsNockedDown = 0 }
                ,new Ball {PinsNockedDown = 7 }
                
                ,new Ball {PinsNockedDown = 2 }
                ,new Ball {PinsNockedDown = 2 }
                
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 4 }
                ,new Ball {PinsNockedDown = 4 }
            };
        }

        [Test]
        public void TestFrameScore_WhenSpareFollowedByOpenSpare()
        {
            //Assemble
            Frame frame = new Frame() { FrameNumber = 1, BallOneIndex = 0, BallTwoIndex = 1, BonusOneEnabled = true, BonusTwoEnabled = false };

            //Act
            int? frameScore = frame.FrameScore(balls);

            //Assert
            Assert.AreEqual(15 , frameScore);
        }

        [Test]
        public void TestFrameScore_WhenOpenSpare()
        {
            //Assemble
            Frame frame = new Frame() { FrameNumber = 2, BallOneIndex = 2, BallTwoIndex = 3, BonusOneEnabled = false, BonusTwoEnabled = false };

            //Act
            int? frameScore = frame.FrameScore(balls);

            //Assert
            Assert.AreEqual(9, frameScore);
        }

        [Test]
        public void TestFrameScore_StrikeFollowedByOpenSpare()
        {
            //Assemble
            Frame frame = new Frame() { FrameNumber = 3, BallOneIndex = 4, BallTwoIndex = null, BonusOneEnabled = true, BonusTwoEnabled = true };

            //Act
            int? frameScore = frame.FrameScore(balls);

            //Assert
            Assert.AreEqual(19, frameScore);
        }

        [Test]
        public void TestFrameScore_SpareFollowedBySpare()
        {
            //Assemble
            Frame frame = new Frame() { FrameNumber = 5, BallOneIndex = 7, BallTwoIndex = 8, BonusOneEnabled = false, BonusTwoEnabled = true };

            //Act
            int? frameScore = frame.FrameScore(balls);

            //Assert
            Assert.AreEqual(15, frameScore);
        }
        
        [Test]
        public void TestFrame10Score_StrikeFollowedByTwoNonStrike()
        {
            //Assemble
            Frame10 frame10 = new Frame10() { FrameNumber = 10, BallOneIndex = 17, BallTwoIndex = 18, BallThreeIndex = 19};

            //Act
            int? frameScore = frame10.FrameScore(balls);

            //Assert
            Assert.AreEqual(18, frameScore);
        }

        [Test]
        public void TestFrame10Score_StrikeFollowedByStrikeThenNonStrike()
        {
            //Assemble
            Frame10 frame10 = new Frame10() { FrameNumber = 10, BallOneIndex = 0, BallTwoIndex = 1, BallThreeIndex = 2 };
            
            balls = new List<Ball>() {
                new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 5 }
                ,new Ball {PinsNockedDown = 6 }
            };

            //Act
            int? frameScore = frame10.FrameScore(balls);

            //Assert
            Assert.AreEqual(21, frameScore);
        }

        [Test]
        public void TestFrame10Score_NonStrikeFollowedByStrike()
        {
            //Assemble
            Frame10 frame10 = new Frame10() { FrameNumber = 10, BallOneIndex = 0, BallTwoIndex = 1, BallThreeIndex = null };

            balls = new List<Ball>() {
                new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 5 }
            };

            //Act
            int? frameScore = frame10.FrameScore(balls);

            //Assert
            Assert.AreEqual(15, frameScore);
        }

        [Test]
        public void TestFrame10Score_3Strikes()
        {
            //Assemble
            Frame10 frame10 = new Frame10() { FrameNumber = 10, BallOneIndex = 0, BallTwoIndex = 1, BallThreeIndex = 2 };

            balls = new List<Ball>() {
                new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
                ,new Ball {PinsNockedDown = 10 }
            };

            //Act
            int? frameScore = frame10.FrameScore(balls);

            //Assert
            Assert.AreEqual(30, frameScore);
        }
    }
}