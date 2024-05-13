using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class HUDLabelBalas : MonoBehaviour
{
    private GameManager gameManager;
    TMP_Text txtLabel;
    void Start()
    {
        gameManager = GameManager.GetManager();
        txtLabel = this.gameObject.GetComponent<TMP_Text>();
        gameManager.OnRoundStart += delegate { setTextBalas(); };
        gameManager.OnRoundAction += delegate { setTextBalas(); };
        gameManager.OnRoundResolute += delegate { setTextBalas(); };
    }
    void Update()
    {
    }
    private void setTextBalas()
    {
        txtLabel.text = "x " + gameManager.DisparosPorJuego;
    }
}