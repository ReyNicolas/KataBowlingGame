using System;
using System.Collections;
using UnityEngine;
using Entities;
using UseCases;

namespace Presenter
{
    public class GamePresenter
    {
        IBowlingView bowlingView;
        Match match;
        StartMatchWithValues startMatch;
        PlayerDoesRoll playerDoesRoll;
        EndOfMatch endOfMatch;
        int numberOfFrames = 10;
        int numberOfPinsToHitDownPerFrame = 10;
        int numberOfShotsPerFrame = 2;

        public void Initialize(IBowlingView bowlingView)
        {
            this.bowlingView = bowlingView;
            this.bowlingView.OnStartMatch += StartMatch;
            this.bowlingView.OnPlayerDoesRoll += PlayerDoesRoll;


            startMatch = new StartMatchWithValues();
            playerDoesRoll = new PlayerDoesRoll();
            endOfMatch = new EndOfMatch(new MatchScorer());
        }

        void StartMatch()
        {
            match = startMatch.Create(numberOfFrames, numberOfPinsToHitDownPerFrame, numberOfShotsPerFrame);
        }

        void PlayerDoesRoll(int roll)
        {
            bowlingView.SetFrameRollScore(match.CurrentFrameIndex, match.CurrentFrame().Rolls.Count, roll);
            playerDoesRoll.ResolveRoll(roll, match);

            if (endOfMatch.CheckEndOfMatch(match))
            {
                EndMatch();
                return;
            }

            if (IsEndOfFrame())
            {
                bowlingView.StartNewFrame();
            }

        }

         bool IsEndOfFrame()
        {
            return match.CurrentFrame().Rolls.Count == 0 || (match.IsLastFrame() && !match.CurrentFrame().AreThereAnyPinsToHitDown());
        }

        void EndMatch()
        {
            bowlingView.SetFramesFinalScore(endOfMatch.ScoreEndOfMatch(match));
        }
    }
}

