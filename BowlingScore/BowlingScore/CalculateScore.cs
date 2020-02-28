using System.Collections.Generic;

namespace BowlingScore
{
    public class CalculateScore
    {
        public int? TotalScore(List<IFrame> frames, List<Ball> balls, int currentFrameIndex)
        {
            int? score = 0;

            for (int i = 0; i <= currentFrameIndex; i++)
            {
                score += frames[i].FrameScore(balls);
            }

            return score;
        }
    }
}
