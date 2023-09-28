using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Presenter;
using Views;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IBowlingView
{
    [SerializeField] FrameScorerView[] frameScorerViews;
    [SerializeField] Transform pinSpawnTransform;
    [SerializeField] GameObject pinControllerPrefab;
    [SerializeField] Pin pinController;
    [SerializeField] Ball ballScript;
    [SerializeField] Button rollButton;
    
    public event Action OnStartMatch;
    public event Action<int> OnPlayerDoesRoll;
    private GamePresenter presenter;
    // Start is called before the first frame update
    void Start()
    {
        presenter = new GamePresenter();
        presenter.Initialize(this);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("FinishRoll", 2f);
        }
    }
    
    public void StarMatch()
    {
        OnStartMatch?.Invoke();
    }

    public void StartNewFrame()
    {
        Destroy(pinController.gameObject);
        Invoke("InstatiatePinController", 0.1f);
    }
    void InstatiatePinController()
    {
        pinController = Instantiate(pinControllerPrefab, pinSpawnTransform.position, pinSpawnTransform.rotation).GetComponent<Pin>();
    
    }
    public void SetRoll(int roll)
    {
        OnPlayerDoesRoll?.Invoke(roll);
    }


    public void SetFrameRollScore(int currentFrameIndex, int currentFrameLastRollIndex, int roll)
    {
        frameScorerViews[currentFrameIndex].SetScoreWithIndex(currentFrameLastRollIndex, roll);
    }

    public void SetFramesFinalScore(List<int> finalScores)
    {
        rollButton.interactable = false;
        for (int i = 0; i < finalScores.Count; i++)
        {
            frameScorerViews[i].SetScoreLast(finalScores[i]);
        }
    }
    void FinishRoll()
    {
        SetRoll(pinController.GetNumberOfPinsHitDown());
        if (pinController != null) pinController.ResetCount();
        ballScript.SetStartPosition();
    }


    public void ResetGame()
    {
        rollButton.interactable = true;
        SceneManager.LoadScene("SampleScene");
    }
}
