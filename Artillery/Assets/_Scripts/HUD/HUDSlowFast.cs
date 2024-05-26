using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameManager;
public class HUDSlowFast : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;
    private InputManager inputManager;
    private InputAction TimeSlow;
    private InputAction TimeFast;
    #endregion

    #region Awake & Start & Update
    private void Awake()
    {
    }
    void Start()
    {
        gameManager = GameManager.GetManager();
        inputManager = InputManager.GetManager();
        TimeSlow = inputManager.GetAction("Time_Slow");
        TimeSlow.performed += SlowGameKey;
        TimeFast = inputManager.GetAction("Time_Fast");
        TimeFast.performed += FastGameKey;
        gameManager.OnRoundAction += delegate { Time.timeScale = 1; };
        gameManager.OnRoundResolute += delegate { Time.timeScale = 1; };
    }
    void Update()
    {
        switch (gameManager.ActualRound)
        {
            case RoundState.Action:
                habilitarControles();
                break;
            default:
                deshabilitarControles();
                Time.timeScale = 1;
                break;
        }
    }
    #endregion

    #region Function
    public void habilitarControles()
    {
        TimeSlow.Enable();
        TimeFast.Enable();
    }
    public void deshabilitarControles()
    {
        TimeSlow.Disable();
        TimeFast.Disable();
    }
    public void SlowGameKey(InputAction.CallbackContext context)
    {
        SlowGame(-0.5f);
    }
    public void SlowGame(float time = -0.5f)
    {
        time = time > 0 ? -time : time;
        changeTime(time);
    }
    public void FastGameKey(InputAction.CallbackContext context)
    {
        FastGame(0.5f);
    }
    public void FastGame(float time = 0.5f)
    {
        time = time < 0 ? -time : time;
        changeTime(time);
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
        SumTimeScale = SumTimeScale <= 0.1f ? 0.1f : SumTimeScale;
        if (SumTimeScale < 0 || SumTimeScale > 3) return;
        Time.timeScale = SumTimeScale;
    }
    #endregion
}