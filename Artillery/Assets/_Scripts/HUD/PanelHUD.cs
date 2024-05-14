using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PanelHUD : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject HUDGame;
    void Start()
    {
        gameManager = GameManager.GetManager();
        gameManager.OnGamePause += delegate { HUDGame.SetActive(false); };
        gameManager.OnGameResume += delegate { HUDGame.SetActive(gameManager.ActualRound == GameManager.RoundState.Preparation); };
        gameManager.OnGameEnd += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundStart += delegate { HUDGame.SetActive(true); };
        gameManager.OnRoundAction += delegate { HUDGame.SetActive(false); };
    }
    public void PauseGame()
    {
        gameManager.PauseGame();
    }
}