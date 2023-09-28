using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Entities;
using UseCases;
public class PlayerDoesRollTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ResolveRoll_WhenCurrentFrameDontChange()
    {
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2 };
        Match match = new Match(frames);
        PlayerDoesRoll playerDoesRoll= new PlayerDoesRoll();
        int expectedRoll = 2;

        playerDoesRoll.ResolveRoll(expectedRoll, match);
        var result = match.CurrentFrame().Rolls.First();

        // Use the Assert class to test conditions
        Assert.AreEqual(expectedRoll, result);
    }
    [Test]
    public void ResolveRoll_WhenCurrentFrameChange() 
    {
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2 };
        Match match = new Match(frames);
        PlayerDoesRoll playerDoesRoll = new PlayerDoesRoll();
        int roll = 10;

        playerDoesRoll.ResolveRoll(roll, match);
        var result = match.CurrentFrame();

        Assert.AreEqual(frame2, result);

    }

    
}
