using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class HUDLabelTime : MonoBehaviour
{
    TMP_Text txtLabel;
    void Start()
    {
        txtLabel = this.gameObject.GetComponent<TMP_Text>();
    }
    void Update()
    {
        SetTextTime();
    }
    public void SetTextTime()
    {
        txtLabel.text = Time.timeScale.ToString("#.##");
    }
}
