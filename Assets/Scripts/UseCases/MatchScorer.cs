using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entities;

namespace UseCases
{
    public class MatchScorer
    {
        public List<int> Score(Match match)
        {
            List<int> results = new List<int>();
            int accScore = 0;
            foreach (Frame frame in match.Frames)
            {
                accScore += ScoreFrameFromMatch(frame, match);
                results.Add(accScore);
            }
            return results;
        }
        int ScoreFrameFromMatch(Frame frame, Match match)
        {
            if (!frame.AreThereAnyPinsToHitDown())
            {
                if (frame.Rolls.Count == 1) return frame.GetPinsHitDown() + (match.GetTheNextNumberOfRollsAfterThisFrame(2, frame)).Sum();
                return frame.GetPinsHitDown() + (match.GetTheNextNumberOfRollsAfterThisFrame(1, frame)).Sum();
            }
            return frame.GetPinsHitDown();
        }
    }
}
