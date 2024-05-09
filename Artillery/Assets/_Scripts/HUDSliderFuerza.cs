using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDSliderFuerza : MonoBehaviour
{
    #region Variables
    private Slider slider;
    private GameManager gameManager;
    #endregion

    void Start()
    {
        slider = this.GetComponent<Slider>();
        gameManager = GameManager.GetManager();
    }
    void Update()
    {
        slider.minValue = 10;
        slider.maxValue = 40;
        slider.value = (int)gameManager.VelocidadBala;
        if (gameManager.IsBlock)
        {
            var scale = slider.gameObject.transform.localScale;
            scale.x = 0;
            slider.gameObject.transform.localScale = scale;
        }
        else
        {
            var scale = slider.gameObject.transform.localScale;
            scale.x = 1;
            slider.gameObject.transform.localScale = scale;
        }
    }
}