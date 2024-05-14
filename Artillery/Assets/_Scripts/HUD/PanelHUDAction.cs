using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PanelHUDAction : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject HUDGame;
    void Start()
    {
        gameManager = GameManager.GetManager();
        gameManager.OnGamePause += delegate { HUDGame.SetActive(false); };
        gameManager.OnGameResume += delegate { HUDGame.SetActive(gameManager.ActualRound == GameManager.RoundState.Action); };
        gameManager.OnGameEnd += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundStart += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundAction += delegate { HUDGame.SetActive(true); };
    }
    public void PauseGame()
    {
        gameManager.PauseGame();
    }
}