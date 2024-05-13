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
        gameManager.OnGameLevelCleared += delegate { HUDGame.SetActive(false); };
        gameManager.OnGameOver += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundStart += delegate { HUDGame.SetActive(false); };
        gameManager.OnRoundAction += delegate { HUDGame.SetActive(true); };
        gameManager.OnRoundResolute += delegate { HUDGame.SetActive(false); };
    }
}