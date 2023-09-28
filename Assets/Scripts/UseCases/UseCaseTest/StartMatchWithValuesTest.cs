using System.Collections.Generic;
using NUnit.Framework;
using UseCases;
using Entities;
public class StartMatchWithValuesTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ShouldReturn_ReturnMatch()
    {
        StartMatchWithValues startMatchWithValues = new StartMatchWithValues();
        int numberOfFrames = 10;
        int numberOfPinsToHitDownPerFrame = 10;
        int numberOfShotsPerFrame = 2;
        Match expectedType = new Match(new List<Frame>() { new Frame(10,2)});

        var result = startMatchWithValues.Create(numberOfFrames, numberOfPinsToHitDownPerFrame, numberOfShotsPerFrame);


        Assert.IsInstanceOf(expectedType.GetType(), result);

    }
    [Test]
    public void ShouldReturn_ReturnMatchWithAListOfFrames()
    {
        StartMatchWithValues startMatchWithValues = new StartMatchWithValues();
        int numberOfFrames = 10;
        int numberOfPinsToHitDownPerFrame = 10;
        int numberOfShotsPerFrame = 2;
        Match expectedType = new Match(new List<Frame>() { new Frame(10, 2) });

        var result = startMatchWithValues.Create(numberOfFrames, numberOfPinsToHitDownPerFrame, numberOfShotsPerFrame).Frames.Count;


        Assert.AreEqual(numberOfFrames, result);

    }

}
