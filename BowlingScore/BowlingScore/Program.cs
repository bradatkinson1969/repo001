using System;
using static System.Net.Mime.MediaTypeNames;

namespace BowlingScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = args.Length;
            int[] preloadedBalls;
            IPinPhysics pinPhysics = new SimulatedPinPhysics();

            if (args.Length > 0)
            {
                Console.WriteLine("Loading pre-set ball scores...\n");
                preloadedBalls = new int[arraySize];

                int i = 0;
                foreach (string a in args)
                {
                    preloadedBalls[i] = int.Parse(a);
                    i++;
                }

                pinPhysics = new HardcodedPinPhysics(preloadedBalls);
            }

            Console.WriteLine("Welcome Bowler!");
            Console.WriteLine("");

            GoBowling game = new GoBowling(pinPhysics);
            int pinsNockedDownByThrow;
            CalculateScore calculate = new CalculateScore();

            try
            {
                for (int i = 0; i <= 9; i++)
                {
                    Console.WriteLine("frame: {0}", i + 1);
                    pinsNockedDownByThrow = game.ThrowBall(1);
                    Console.WriteLine("ball 1: {0}", pinsNockedDownByThrow);

                    if ((pinsNockedDownByThrow < 10) || (i == 9 && !game.Frames[9].PinsFromBallTwo.HasValue))
                    {
                        pinsNockedDownByThrow = game.ThrowBall(2);
                        Console.WriteLine("ball 2: {0}", pinsNockedDownByThrow);
                    }

                    if (i == 9 && game.Frames[9].BallThreeEnabled && !game.Frames[9].PinsFromBallThree.HasValue)
                    {
                        pinsNockedDownByThrow = game.ThrowBall(3);
                        Console.WriteLine("ball 3: {0}", pinsNockedDownByThrow);
                    }

                    Console.WriteLine("Total Score: " + calculate.TotalScore(game.Frames, game.Balls, i));
                    Console.WriteLine(" ");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\nNot enough balls PreLoaded for a game.");
                Console.ReadKey();
            }



            //for (int i = 0; i < 10; i++)
            //{
            //    string b2ndx, bonus1ndx, bonus2ndx, b2pins;
            //    int b2nd = 0;

            //    if (game.Frames[i].BallTwoIndex == null)
            //        b2ndx = "null";
            //    else
            //        b2nd = game.Frames[i].BallTwoIndex.GetValueOrDefault();
            //    b2ndx = game.Frames[i].BallTwoIndex.ToString();

            //    if (game.Frames[i].BonusOneIndex == null)
            //        bonus1ndx = "null";
            //    else
            //        bonus1ndx = game.Frames[i].BonusOneIndex.ToString();

            //    if (game.Frames[i].BonusTwoIndex == null)
            //    {
            //        bonus2ndx = "null";
            //        b2pins = "null";
            //    }
            //    else
            //    {
            //        bonus2ndx = game.Frames[i].BonusTwoIndex.ToString();
            //        b2pins = game.Balls[b2nd].PinsNockedDown.ToString();
            //    }





            //    if (game.Frames[i].BallOneIndex != null)
            //    {
            //        Console.WriteLine("frame:{0}, b1ndx:{1}, b1 pins:{2}, bonus1?:{3}, bonus1ndx:{4}, bonus2?:{5}, bonus2ndx:{6}", i + 1, game.Frames[i].BallOneIndex.Value, game.Balls[game.Frames[i].BallOneIndex.GetValueOrDefault()].PinsNockedDown, game.Frames[i].BonusOneEnabled, bonus1ndx, game.Frames[i].BonusTwoEnabled, bonus2ndx);
            //    }

            //    if (game.Frames[i].BallTwoIndex != null && game.Frames[i].BallTwoIndex.GetValueOrDefault() < game.Balls.Count)
            //    {
            //        Console.WriteLine("frame:{0}, b2ndx:{1}, b2 pins:{2}, bonus1?:{3}, bonus1ndx:{4}, bonus2?:{5}, bonus2ndx:{6}", i + 1, b2ndx, b2pins, game.Frames[i].BonusOneEnabled, bonus1ndx, game.Frames[i].BonusTwoEnabled, bonus2ndx);
            //    }

            //    if (game.Frames[i].BallThreeIndex != null)
            //    {
            //        Console.WriteLine("frame:{0}, b3 index:{1}, b 3 pins:{2}", i + 1, game.Frames[i].BallThreeIndex.GetValueOrDefault(), game.Balls[game.Frames[i].BallThreeIndex.GetValueOrDefault()].PinsNockedDown);
            //    }

            //    Console.WriteLine(" ");
            //}


            //int ballIndex = 0;
            //foreach (Ball b in game.Balls)
            //{
            //    Console.WriteLine("b index:{0}, b pins:{1}", ballIndex, b.PinsNockedDown);
            //    ballIndex++;
            //}

        }
    }
}
