using System.Collections.Generic;
using System.Linq;
//using System.Text.RegularExpressions;
using Entities;

namespace UseCases
{
    public class EndOfMatch
    {
        MatchScorer matchScorer;

        public EndOfMatch(MatchScorer matchScorer)
        {
            this.matchScorer = matchScorer;
        }

        public bool CheckEndOfMatch(Match match)
        {
            return (match.IsLastFrame() && IsFrameComplete(match.CurrentFrame()));
        }

        bool IsFrameComplete(Frame frame)
        {
            if (frame.Rolls.Sum() >= frame.NumberOfPinsToHitDown) return frame.Rolls.Count == frame.MaxNumberOfRolls + 1;



            return !frame.HaveRollsToDo();
        }


        public List<int> ScoreEndOfMatch(Match match)
        {
            return matchScorer.Score(match);
        }
    }
}


