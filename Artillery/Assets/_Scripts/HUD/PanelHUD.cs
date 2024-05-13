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
        gameManager.OnGameLevelCleared += delegate { HUDGame.SetActive(false); };
        gameManager.OnGameOver += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundStart += delegate { HUDGame.SetActive(true); };
        gameManager.OnRoundAction += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundResolute += delegate { HUDGame.SetActive(true); };
    }
}