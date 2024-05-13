using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameManager;
public class HUDSlowFast : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;
    public CanonControls canonControls;
    private InputAction modificarVelocidad;
    #endregion

    #region Awake & Start & Update
    private void Awake()
    {
        canonControls = new CanonControls();
    }
    void Start()
    {
        gameManager = GameManager.GetManager();
        modificarVelocidad = canonControls.Canon.ModificarTiempo;
    }
    void Update()
    {
        switch (gameManager.ActualRound)
        {
            case RoundState.Action:
                var ValorFuerza = modificarVelocidad.ReadValue<float>();
                if (ValorFuerza < 0) SlowGame();
                if (ValorFuerza > 0) SlowGame();
                break;
            default:
                Time.timeScale = 1;
                break;
        }
    }
    #endregion

    #region Function
    public void SlowGame()
    {
        changeTime(-0.5f);
    }
    public void FastGame()
    {
        changeTime(0.5f);
    }
    public void changeTime(float TimeScale)
    {
        if (Time.timeScale < 1) 
        {
            if (TimeScale < 0)
            {
                TimeScale = -0.1f;
            } else
            if (TimeScale > 0)
            {
                TimeScale = 0.1f;
            }
        }
        float SumTimeScale = Time.timeScale + TimeScale;
        if (SumTimeScale < 0 || SumTimeScale > 3) return;
        Time.timeScale = SumTimeScale;
    }
    #endregion
}