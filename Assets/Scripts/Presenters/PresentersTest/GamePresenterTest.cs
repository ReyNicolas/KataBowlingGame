using NSubstitute;
using NUnit.Framework;
using Presenter;
using System;
using System.Collections.Generic;

public class GamePresenterTest 
{
    IBowlingView view;
    GamePresenter gamePresenter;

    [SetUp]
    public void Setup()
    {
        view = Substitute.For<IBowlingView>();
        gamePresenter = new GamePresenter();
        gamePresenter.Initialize(view);
        view.OnStartMatch += Raise.Event<Action>();
    }
    [Test]
    public void OnPlayerDoesRoll_SetFrameRollScoreInView()
    {
        var expectedRoll = 10;
        view.OnPlayerDoesRoll += Raise.Event<Action<int>>(expectedRoll);

        view.Received().SetFrameRollScore(Arg.Any<int>(), Arg.Any<int>(), expectedRoll);
    }
    [Test]
    public void OnPlayerDoesRoll_IsNotEndOfMatch_And_IsEndOfFrame_StartNewFrame()
    {
        var expectedRoll = 10;
        view.OnPlayerDoesRoll += Raise.Event<Action<int>>(expectedRoll);

        view.Received().StartNewFrame();
    }
    [Test]
    public void OnPlayerDoesRoll_IsNotEndOfMatch_ViewSetFramesFinalScore()
    {
        AllRollsOver();

        view.Received().SetFramesFinalScore(Arg.Any<List<int>>());
    }

    private void AllRollsOver()
    {
        var expectedRoll = 10;
        for (int i = 0; i < 12; i++)
        {
            view.OnPlayerDoesRoll += Raise.Event<Action<int>>(expectedRoll);
        }
    }
}
