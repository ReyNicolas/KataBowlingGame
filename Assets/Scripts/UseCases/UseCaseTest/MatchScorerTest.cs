using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Entities;
using UseCases;
using UnityEngine.TestTools;

public class MatchScorerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void Score_WhenMatchHaveAStrike()
    {
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2};
        Match match = new Match(frames);        
        MatchScorer matchScorer= new MatchScorer();
        frame1.AddRoll(10);
        frame2.AddRoll(3);
        frame2.AddRoll(5);
        List<int> expectedScores = new List<int>() { 18, 26 };

        //Act
        List<int> results = matchScorer.Score(match);

        //Assert
        Assert.AreEqual(expectedScores, results);


    }
    [Test]
    public void Score_WhenMatchHaveASpare()
    {
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        Frame frame3 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2, frame3 };
        Match match = new Match(frames);
        MatchScorer matchScorer = new MatchScorer();
        frame1.AddRoll(4);
        frame1.AddRoll(3);
        frame2.AddRoll(4);
        frame2.AddRoll(6);
        frame3.AddRoll(5);
        frame3.AddRoll(4);
        List<int> expectedScores = new List<int>() { 7, 22, 31 };

        //Act
        List<int> results = matchScorer.Score(match);

        //Assert
        Assert.AreEqual(expectedScores, results);
    }
}
