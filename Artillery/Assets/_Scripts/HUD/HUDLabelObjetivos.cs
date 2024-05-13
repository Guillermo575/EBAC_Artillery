using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class HUDLabelObjetivos : MonoBehaviour
{
    private GameManager gameManager;
    TMP_Text txtLabel;
    void Start()
    {
        gameManager = GameManager.GetManager();
        txtLabel = this.gameObject.GetComponent<TMP_Text>();
        gameManager.OnRoundStart += delegate { setTextObjetivos(); };
        gameManager.OnRoundAction += delegate { setTextObjetivos(); };
        gameManager.OnRoundResolute += delegate { setTextObjetivos(); };
    }
    void Update()
    {
    }
    private void setTextObjetivos()
    {
        txtLabel.text = "x " + gameManager.ObjetivosTotales;
    }
}