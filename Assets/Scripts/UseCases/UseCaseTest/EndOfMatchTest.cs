using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Entities;
using UseCases;


    public class EndOfMatchTest
{
        // A Test behaves as an ordinary method
        [Test]
        public void CheckEndOfMatch_WhenLastFrameIsComplete_ReturnTrue()
        {
            MatchScorer matchScorer = new MatchScorer();
            EndOfMatch endOfMatch = new EndOfMatch(matchScorer);

            Frame frame1 = new Frame(10, 2);
            Frame frame2 = new Frame(10, 2);
            List<Frame> frames = new List<Frame>() { frame1, frame2 };
            Match match = new Match(frames);

            match.CurrentFrame().AddRoll(10);
            match.MoveToNextFrame();
            match.CurrentFrame().AddRoll(3);
            match.CurrentFrame().AddRoll(7);

            var result = endOfMatch.CheckEndOfMatch(match);

            Assert.IsTrue(result);
        }
        [Test]
        public void CheckEndOfMatch_WhenLastFrameIsNotComplete_ReturnFalse()
        {
            MatchScorer matchScorer = new MatchScorer();
            EndOfMatch endOfMatch = new EndOfMatch(matchScorer);

            Frame frame1 = new Frame(10, 2);
            Frame frame2 = new Frame(10, 2);
            List<Frame> frames = new List<Frame>() { frame1, frame2 };
            Match match = new Match(frames);

            match.CurrentFrame().AddRoll(10);
            match.MoveToNextFrame();
            match.CurrentFrame().AddRoll(3);

            var result = endOfMatch.CheckEndOfMatch(match);

            Assert.IsFalse(result);
        }
        [Test]
        public void CheckEndOfMatch_WhenNotLastFrame_ReturnFalse()
        {
            MatchScorer matchScorer = new MatchScorer();
            EndOfMatch endOfMatch = new EndOfMatch(matchScorer);

            Frame frame1 = new Frame(10, 2);
            Frame frame2 = new Frame(10, 2);
            List<Frame> frames = new List<Frame>() { frame1, frame2 };
            Match match = new Match(frames);

            match.CurrentFrame().AddRoll(5);

            var result = endOfMatch.CheckEndOfMatch(match);

            Assert.IsFalse(result);
        }



    }


