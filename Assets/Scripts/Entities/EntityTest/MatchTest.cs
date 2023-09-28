using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Entities;

//using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class MatchTest
{
    [SetUp]
    public void Setup()
    {
       
    }
    [Test]
    public void InicializeWithAListOfFrames()
    {
        List<Frame> frames = new List<Frame>() { new Frame(10, 2) };
        Match match = new Match(frames);

        var result = match.Frames;

        Assert.AreEqual(frames, result);
    }
    [Test]
    public void CurrentFrame_WhenInicialize_ReturnFirstFrame()
    {
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2 };
        Match match = new Match(frames);

        var result = match.CurrentFrame();

        Assert.AreEqual(frame1, result);
    }
    [Test]
    public void MoveToNextFrame_WhenActualIsFirstFrame_ActualFrameWillBeSecond()
    {
        //Arrange
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2 };
             
        Match match = new Match(frames);
        
        //Act
        Assert.AreEqual(frame1, match.CurrentFrame());
        match.MoveToNextFrame();
        var result = match.CurrentFrame();
        //Assert
        Assert.AreEqual(frame2, result);
    }
    [Test]
    public void IsLastFrame_WhenCurrentFrameIsLast_ReturnTrue()
    {
        //Arrange
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2 };

        Match match = new Match(frames);

        //Act
        match.MoveToNextFrame();
        bool result = match.IsLastFrame();

        //Assert
        Assert.AreEqual(frames.Last(), match.CurrentFrame());
        Assert.IsTrue(result);
    }
    [Test]
    public void GetTheNextNumberOfRollsAfterThisFrame_WhenNumberIsTwoFrameIsTheSecondAndThirdFrameHaveTwoRolls()
    {
        //Arrange
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        Frame frame3 = new Frame(10, 2);
        Frame frame4 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2, frame3, frame4 };
        List<int> expectedRolls = new List<int>() { 3, 7};


        Match match = new Match(frames);

        //Act
        frame1.AddRoll(2);
        frame1.AddRoll(2);

        frame2.AddRoll(4);
        frame2.AddRoll(5);

        frame3.AddRoll(expectedRolls[0]);
        frame3.AddRoll(expectedRolls[1]);

        frame4.AddRoll(3);
        frame4.AddRoll(2);

        List<int> result = match.GetTheNextNumberOfRollsAfterThisFrame(2, frame2);

        //Assert
        Assert.AreEqual(expectedRolls, result);
    }
    [Test]
    public void GetTheNextNumberOfRollsAfterThisFrame_WhenNumberIsTwoFrameIsTheSecondAndThirdFrameHaveOneRolls()
    {
        //Arrange
        Frame frame1 = new Frame(10, 2);
        Frame frame2 = new Frame(10, 2);
        Frame frame3 = new Frame(10, 2);
        Frame frame4 = new Frame(10, 2);
        List<Frame> frames = new List<Frame>() { frame1, frame2, frame3, frame4 };
        List<int> expectedRolls = new List<int>() { 10,  4};


        Match match = new Match(frames);

        //Act
        frame1.AddRoll(2);
        frame1.AddRoll(2);

        frame2.AddRoll(4);
        frame2.AddRoll(5);

        frame3.AddRoll(expectedRolls[0]);

        frame4.AddRoll(expectedRolls[1]);
        frame4.AddRoll(2);

        List<int> result = match.GetTheNextNumberOfRollsAfterThisFrame(2, frame2);

        //Assert
        Assert.AreEqual(expectedRolls, result);
    }

}
