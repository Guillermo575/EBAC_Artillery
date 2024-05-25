using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDSliderFuerza : MonoBehaviour
{
    #region Variables
    private Canon jugador;
    private Slider slider;
    private GameManager gameManager;
    #endregion

    #region Start & Update
    void Start()
    {
        jugador = GameObject.FindObjectsByType<Canon>(FindObjectsSortMode.InstanceID)[0];
        slider = this.GetComponent<Slider>();
        gameManager = GameManager.GetManager();
    }
    void Update()
    {
        slider.minValue = jugador.GetBalaPrefab().FuerzaMinimo;
        slider.maxValue = jugador.GetBalaPrefab().FuerzaMaximo;
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
    #endregion
}