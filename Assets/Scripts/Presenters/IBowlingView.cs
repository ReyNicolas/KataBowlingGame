using System;
using System.Collections.Generic;

public interface IBowlingView
{
    void SetFramesFinalScore(List<int> finalScores);
    void SetFrameRollScore(int currentFrameIndex, int currentFrameLastRollIndex, int roll);

     void StartNewFrame();

    event Action OnStartMatch;
    event Action<int> OnPlayerDoesRoll;
}
