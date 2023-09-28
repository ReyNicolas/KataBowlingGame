using Entities;

namespace UseCases
{
    public class PlayerDoesRoll
    {
        public void ResolveRoll(int roll, Match match)
        {
            match.CurrentFrame().AddRoll(roll);

            if (match.IsLastFrame()) return;
            if (IsFrameComplete(match.CurrentFrame())) match.MoveToNextFrame();

        }


        public bool IsFrameComplete(Frame frame)
        {
            return !frame.AreThereAnyPinsToHitDown() || !frame.HaveRollsToDo();
        }

    }

}

