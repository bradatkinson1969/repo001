using BowlingScore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bowling.Tests
{
    public class GoBowlingTests
    {
        private int[] balls_AllStrikes;
        private int[] balls_AllSpares;
        private int[] balls_NoSpares;
        private int[] balls_Mix;

        [SetUp]
        public void Setup()
        {
            balls_AllStrikes = new int[12] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            balls_AllSpares = new int[20] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            balls_NoSpares = new int[20] { 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4 };
            balls_Mix = new int[20] { 5, 5, 6, 3, 10, 7, 2, 8, 2, 5, 5, 0, 6, 0, 7, 2, 2, 10, 4, 4 };
        }

        [Test]
        public void TestBowling_AllStrikes()
        {
            //Assemble
            HardcodedPinPhysics physics = new HardcodedPinPhysics(balls_AllStrikes);
            GoBowling bowl = new GoBowling(physics);

            //Act
            int pinsNockedDown01 = bowl.ThrowBall(1);
            int pinsNockedDown02 = bowl.ThrowBall(1);
            int pinsNockedDown03 = bowl.ThrowBall(1);
            int pinsNockedDown04 = bowl.ThrowBall(1);
            int pinsNockedDown05 = bowl.ThrowBall(1);
            int pinsNockedDown06 = bowl.ThrowBall(1);
            int pinsNockedDown07 = bowl.ThrowBall(1);
            int pinsNockedDown08 = bowl.ThrowBall(1);
            int pinsNockedDown09 = bowl.ThrowBall(1);
            int pinsNockedDown10 = bowl.ThrowBall(1);
            int pinsNockedDown11 = bowl.ThrowBall(2);
            int pinsNockedDown12 = bowl.ThrowBall(3);

            //Assert
            Assert.AreEqual(10, pinsNockedDown01);
            Assert.AreEqual(10, pinsNockedDown02);
            Assert.AreEqual(10, pinsNockedDown03); 
            Assert.AreEqual(10, pinsNockedDown04);
            Assert.AreEqual(10, pinsNockedDown05);
            Assert.AreEqual(10, pinsNockedDown06);
            Assert.AreEqual(10, pinsNockedDown07);
            Assert.AreEqual(10, pinsNockedDown08);
            Assert.AreEqual(10, pinsNockedDown09);
            Assert.AreEqual(10, pinsNockedDown10);
            Assert.AreEqual(10, pinsNockedDown11);
            Assert.AreEqual(10, pinsNockedDown12);

            CalculateScore calculate = new CalculateScore();
            int? totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 9);
            Assert.AreEqual(300, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 5);
            Assert.AreEqual(180, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 0);
            Assert.AreEqual(30, totalScore.Value);
        }

        [Test]
        public void TestBowling_AllSpares()
        {
            //Assemble
            HardcodedPinPhysics physics = new HardcodedPinPhysics(balls_AllSpares);
            GoBowling bowl = new GoBowling(physics);

            //Act
            int pinsNockedDown01 = bowl.ThrowBall(1);
            int pinsNockedDown02 = bowl.ThrowBall(2);
            int pinsNockedDown03 = bowl.ThrowBall(1);
            int pinsNockedDown04 = bowl.ThrowBall(2);
            int pinsNockedDown05 = bowl.ThrowBall(1);
            int pinsNockedDown06 = bowl.ThrowBall(2);
            int pinsNockedDown07 = bowl.ThrowBall(1);
            int pinsNockedDown08 = bowl.ThrowBall(2);
            int pinsNockedDown09 = bowl.ThrowBall(1);
            int pinsNockedDown10 = bowl.ThrowBall(2);
            int pinsNockedDown11 = bowl.ThrowBall(1);
            int pinsNockedDown12 = bowl.ThrowBall(2);
            int pinsNockedDown13 = bowl.ThrowBall(1);
            int pinsNockedDown14 = bowl.ThrowBall(2);
            int pinsNockedDown15 = bowl.ThrowBall(1);
            int pinsNockedDown16 = bowl.ThrowBall(2);
            int pinsNockedDown17 = bowl.ThrowBall(1);
            int pinsNockedDown18 = bowl.ThrowBall(2);
            int pinsNockedDown19 = bowl.ThrowBall(1);
            int pinsNockedDown20 = bowl.ThrowBall(2);

            //Assert
            Assert.AreEqual(5, pinsNockedDown01);
            Assert.AreEqual(5, pinsNockedDown02);
            Assert.AreEqual(5, pinsNockedDown03);
            Assert.AreEqual(5, pinsNockedDown04);
            Assert.AreEqual(5, pinsNockedDown05);
            Assert.AreEqual(5, pinsNockedDown06);
            Assert.AreEqual(5, pinsNockedDown07);
            Assert.AreEqual(5, pinsNockedDown08);
            Assert.AreEqual(5, pinsNockedDown09);
            Assert.AreEqual(5, pinsNockedDown10);
            Assert.AreEqual(5, pinsNockedDown11);
            Assert.AreEqual(5, pinsNockedDown12);
            Assert.AreEqual(5, pinsNockedDown13);
            Assert.AreEqual(5, pinsNockedDown14);
            Assert.AreEqual(5, pinsNockedDown15);
            Assert.AreEqual(5, pinsNockedDown16);
            Assert.AreEqual(5, pinsNockedDown17);
            Assert.AreEqual(5, pinsNockedDown18);
            Assert.AreEqual(5, pinsNockedDown19);
            Assert.AreEqual(5, pinsNockedDown20);

            CalculateScore calculate = new CalculateScore();
            int? totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 9);

            Assert.AreEqual(145, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 5);
            Assert.AreEqual(90, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 0);
            Assert.AreEqual(15, totalScore.Value);
        }

        [Test]
        public void TestBowling_NoSpares()
        {
            //Assemble
            HardcodedPinPhysics physics = new HardcodedPinPhysics(balls_NoSpares);
            GoBowling bowl = new GoBowling(physics);

            //Act
            int pinsNockedDown01 = bowl.ThrowBall(1);
            int pinsNockedDown02 = bowl.ThrowBall(2);
            int pinsNockedDown03 = bowl.ThrowBall(1);
            int pinsNockedDown04 = bowl.ThrowBall(2);
            int pinsNockedDown05 = bowl.ThrowBall(1);
            int pinsNockedDown06 = bowl.ThrowBall(2);
            int pinsNockedDown07 = bowl.ThrowBall(1);
            int pinsNockedDown08 = bowl.ThrowBall(2);
            int pinsNockedDown09 = bowl.ThrowBall(1);
            int pinsNockedDown10 = bowl.ThrowBall(2);
            int pinsNockedDown11 = bowl.ThrowBall(1);
            int pinsNockedDown12 = bowl.ThrowBall(2);
            int pinsNockedDown13 = bowl.ThrowBall(1);
            int pinsNockedDown14 = bowl.ThrowBall(2);
            int pinsNockedDown15 = bowl.ThrowBall(1);
            int pinsNockedDown16 = bowl.ThrowBall(2);
            int pinsNockedDown17 = bowl.ThrowBall(1);
            int pinsNockedDown18 = bowl.ThrowBall(2);
            int pinsNockedDown19 = bowl.ThrowBall(1);
            int pinsNockedDown20 = bowl.ThrowBall(2);

            //Assert
            Assert.AreEqual(5, pinsNockedDown01);
            Assert.AreEqual(4, pinsNockedDown02);
            Assert.AreEqual(5, pinsNockedDown03);
            Assert.AreEqual(4, pinsNockedDown04);
            Assert.AreEqual(5, pinsNockedDown05);
            Assert.AreEqual(4, pinsNockedDown06);
            Assert.AreEqual(5, pinsNockedDown07);
            Assert.AreEqual(4, pinsNockedDown08);
            Assert.AreEqual(5, pinsNockedDown09);
            Assert.AreEqual(4, pinsNockedDown10);
            Assert.AreEqual(5, pinsNockedDown11);
            Assert.AreEqual(4, pinsNockedDown12);
            Assert.AreEqual(5, pinsNockedDown13);
            Assert.AreEqual(4, pinsNockedDown14);
            Assert.AreEqual(5, pinsNockedDown15);
            Assert.AreEqual(4, pinsNockedDown16);
            Assert.AreEqual(5, pinsNockedDown17);
            Assert.AreEqual(4, pinsNockedDown18);
            Assert.AreEqual(5, pinsNockedDown19);
            Assert.AreEqual(4, pinsNockedDown20);

            CalculateScore calculate = new CalculateScore();
            int? totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 9);

            Assert.AreEqual(90, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 5);
            Assert.AreEqual(54, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 0);
            Assert.AreEqual(9, totalScore.Value);
        }


        [Test]
        public void TestBowling_Mix()
        {
            //Assemble
            HardcodedPinPhysics physics = new HardcodedPinPhysics(balls_Mix);
            GoBowling bowl = new GoBowling(physics);

            //Act
            int pinsNockedDown01 = bowl.ThrowBall(1);
            int pinsNockedDown02 = bowl.ThrowBall(2);
            int pinsNockedDown03 = bowl.ThrowBall(1);
            int pinsNockedDown04 = bowl.ThrowBall(2);
            int pinsNockedDown05 = bowl.ThrowBall(1);
            int pinsNockedDown06 = bowl.ThrowBall(1);
            int pinsNockedDown07 = bowl.ThrowBall(2);
            int pinsNockedDown08 = bowl.ThrowBall(1);
            int pinsNockedDown09 = bowl.ThrowBall(2);
            int pinsNockedDown10 = bowl.ThrowBall(1);
            int pinsNockedDown11 = bowl.ThrowBall(2);
            int pinsNockedDown12 = bowl.ThrowBall(1);
            int pinsNockedDown13 = bowl.ThrowBall(2);
            int pinsNockedDown14 = bowl.ThrowBall(1);
            int pinsNockedDown15 = bowl.ThrowBall(2);
            int pinsNockedDown16 = bowl.ThrowBall(1);
            int pinsNockedDown17 = bowl.ThrowBall(2);
            int pinsNockedDown18 = bowl.ThrowBall(1);
            int pinsNockedDown19 = bowl.ThrowBall(2);
            int pinsNockedDown20 = bowl.ThrowBall(3);

            //Assert
            Assert.AreEqual(5, pinsNockedDown01);
            Assert.AreEqual(5, pinsNockedDown02);
            Assert.AreEqual(6, pinsNockedDown03);
            Assert.AreEqual(3, pinsNockedDown04);
            Assert.AreEqual(10, pinsNockedDown05);
            Assert.AreEqual(7, pinsNockedDown06);
            Assert.AreEqual(2, pinsNockedDown07);
            Assert.AreEqual(8, pinsNockedDown08);
            Assert.AreEqual(2, pinsNockedDown09);
            Assert.AreEqual(5, pinsNockedDown10);
            Assert.AreEqual(5, pinsNockedDown11);
            Assert.AreEqual(0, pinsNockedDown12);
            Assert.AreEqual(6, pinsNockedDown13);
            Assert.AreEqual(0, pinsNockedDown14);
            Assert.AreEqual(7, pinsNockedDown15);
            Assert.AreEqual(2, pinsNockedDown16);
            Assert.AreEqual(2, pinsNockedDown17);
            Assert.AreEqual(10, pinsNockedDown18);
            Assert.AreEqual(4, pinsNockedDown19);
            Assert.AreEqual(4, pinsNockedDown20);

            CalculateScore calculate = new CalculateScore();
            int? totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 9);

            Assert.AreEqual(113, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 5);
            Assert.AreEqual(78, totalScore.Value);

            totalScore = calculate.TotalScore(bowl.Frames, bowl.Balls, 0);
            Assert.AreEqual(16, totalScore.Value);
        }
    }
}
