using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Entities;

public class FrameTest
{
    
    public int numberOfPins;
    public int numberOfRolls;
    Frame frame;

    [SetUp]
    public void Setup()
    {
        numberOfPins = 10;
        numberOfRolls = 2;
        frame = new Frame(numberOfPins, numberOfRolls);
    }


    // A Test behaves as an ordinary method
    [Test]
    public void InicializeWithANumberOfPinsToHsitDownAndMaxNumberOfRolls()
    {
        Assert.AreEqual(numberOfPins, frame.NumberOfPinsToHitDown);
        Assert.AreEqual(numberOfRolls, frame.MaxNumberOfRolls);
    }
    [Test]
    public void AddRoll_WhenDontHaveRolls_RollsShouldBeOne()
    {
        int roll = 3;

        Assert.IsEmpty(frame.Rolls);
        frame.AddRoll(roll);
        Assert.AreEqual(1, frame.Rolls.Count);
    }
    [Test]
    public void GetPinsHitDown_WhenDontHaveRolls_ReturnZero()
    {
        //Arrange
        int pinsDownExpect = 0;

        //Act
        int result = frame.GetPinsHitDown();

        //Assert
        Assert.IsEmpty(frame.Rolls);
        Assert.AreEqual(pinsDownExpect, result);
    }
    [Test]
    public void GetPinsHitDown_WhenHaveOneRoll_ReturnRoll()
    {
        //Arrange
        int pin = 3;
        int pinsDownExpect = pin;

        //Act
        frame.AddRoll(pin);
        int result = frame.GetPinsHitDown();

        //Assert
        Assert.AreEqual(pinsDownExpect, result);
    }
    [Test]
    public void GetPinsHitDown_WhenHaveMoreThanOneRoll_ReturnRollsSum()
    {
        //Arrange
        int pin1 = 3;
        int pin2 = 2;
        int pinsDownExpect = pin1 + pin2;

        //Act
        frame.AddRoll(pin1);
        frame.AddRoll(pin2);
        int result = frame.GetPinsHitDown();

        //Assert
        Assert.AreEqual(pinsDownExpect, result);
    }
    [Test]
    public void AreThereAnyPinsToHitDown_WhenThereAre_ReturnTrue()
    {
        //Arrange
        int pin1 = 3;
        int pin2 = 2;

        //Act
        frame.AddRoll(pin1);
        frame.AddRoll(pin2);
        bool result = frame.AreThereAnyPinsToHitDown();

        //Assert
        Assert.IsTrue(result);
    }
    [Test]
    public void AreThereAnyPinsToHitDown_WhenThereArenot_ReturnFalse()
    {
        //Arrange
        int pin1 = 5;
        int pin2 = 5;

        //Act
        frame.AddRoll(pin1);
        frame.AddRoll(pin2);
        bool result = frame.AreThereAnyPinsToHitDown();

        //Assert
        Assert.IsFalse(result);
    }
    [Test]
    public void HaveRollsToDo_WhenThereArenot_ReturnFalse()
    {
        //Arrange
        int pin1 = 5;
        int pin2 = 5;

        //Act
        frame.AddRoll(pin1);
        frame.AddRoll(pin2);
        bool result = frame.HaveRollsToDo();

        //Assert
        Assert.IsFalse(result);
    }
    [Test]
    public void HaveRollsToDo_WhenThereAre_ReturnTrue()
    {
        //Arrange
        int pin1 = 5;

        //Act
        frame.AddRoll(pin1);
        bool result = frame.HaveRollsToDo();

        //Assert
        Assert.IsTrue(result);
    }

}
