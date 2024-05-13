using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager SingletonGameManager;
    private GameManager()
    {
    }
    private void CreateSingleton()
    {
        if (SingletonGameManager == null)
        {
            SingletonGameManager = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }
    public static GameManager GetManager()
    {
        return SingletonGameManager;
    }
    #endregion

    #region Variables
    public float VelocidadBala { get => _VelocidadBala; set => _VelocidadBala = value; }
    public int DisparosPorJuego { get => _DisparosPorJuego; set => _DisparosPorJuego = value; }
    public int DisparosPorJuegoTotal { get => _DisparosPorJuegoTotal; set => _DisparosPorJuegoTotal = value; }
    public float VelocidadRotacion { get => _VelocidadRotacion; set => _VelocidadRotacion = value; }
    public float NivelSuelo { get => _NivelSuelo; set => _NivelSuelo = value; }

    [SerializeField] private float _VelocidadBala = 30;
    [SerializeField] private int _DisparosPorJuego = 10;
    [SerializeField] private int _DisparosPorJuegoTotal = 10;
    [SerializeField] private float _VelocidadRotacion = 1;

    private float _NivelSuelo = -1000;
    private int _ObjetivosTotales;
    public int ObjetivosTotales { get { return _ObjetivosTotales; } }

    private bool _IsBlock;
    public bool IsBlock { get { return _IsBlock; } }
    public void setBlock(bool Bloqueado) { this._IsBlock = Bloqueado; }

    public RoundState ActualRound { get; set; } = 0;
    public enum RoundState
    {
        NoMoreRounds = 0,
        Preparation = 1,
        Action = 2,
        Resolution = 3,
    }
    #endregion

    #region Level Game Variables
    private bool GameEnd = false;
    public bool IsGameEnd { get { return GameEnd; } }

    private bool GamePause = false;
    public bool IsGamePause { get { return GamePause; } }

    private bool LevelCleared = false;
    public bool IsLevelCleared { get { return LevelCleared; } }
    public bool IsGameActive { get { return !GameEnd && !GamePause && !LevelCleared; } }
    public bool IsGameConstrolsDisabled { get { return !IsGameActive || IsBlock; } }
    #endregion

    #region EventHandlers
    public event EventHandler OnGameStart;
    public event EventHandler OnGamePause;
    public event EventHandler OnGameResume;
    public event EventHandler OnGameEnd;
    public event EventHandler OnGameOver;
    public event EventHandler OnGameExit;
    public event EventHandler OnGameLevelCleared;
    public event EventHandler OnRoundStart;
    public event EventHandler OnRoundAction;
    public event EventHandler OnRoundResolute;
    public void StartGame()
    {
        GameEnd = false;
        OnGameStart?.Invoke(this, EventArgs.Empty);
    }
    public void PauseGame()
    {
        GamePause = true;
        OnGamePause?.Invoke(this, EventArgs.Empty);
    }
    public void ResumeGame()
    {
        GamePause = false;
        OnGameResume?.Invoke(this, EventArgs.Empty);
    }
    public void ExitGame()
    {
        OnGameExit?.Invoke(this, EventArgs.Empty);
    }
    public void LevelClearedGame()
    {
        GameEnd = true;
        LevelCleared = true;
        OnGameLevelCleared?.Invoke(this, EventArgs.Empty);
    }
    public void GameOver()
    {
        GameEnd = true;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }
    public void StartRound()
    {
        OnRoundStart?.Invoke(this, EventArgs.Empty);
    }
    public void ActionRound()
    {
        OnRoundAction?.Invoke(this, EventArgs.Empty);
    }
    public void ResoluteRound()
    {
        OnRoundResolute?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    #region Awake, Start & Update
    private void Awake()
    {
        CreateSingleton();
        OnGameStart += delegate { Time.timeScale = 1; StartRound(); };
        OnGamePause += delegate { Time.timeScale = 0; };
        OnGameResume += delegate { Time.timeScale = 1; };
        OnGameEnd += delegate { Time.timeScale = 0; ActualRound = RoundState.NoMoreRounds; };
        OnGameOver += delegate { Time.timeScale = 0; ActualRound = RoundState.NoMoreRounds; };
        OnGameExit += delegate { Time.timeScale = 1; ActualRound = RoundState.NoMoreRounds; };
        OnGameLevelCleared += delegate { Time.timeScale = 0; ActualRound = RoundState.NoMoreRounds; };
        OnRoundStart += delegate { Time.timeScale = 1; ActualRound = RoundState.Preparation; setBlock(false); };
        OnRoundAction += delegate { ActualRound = RoundState.Action; setBlock(true); };
        OnRoundResolute += delegate { ResoluteGame(); };
    }
    private void Start()
    {
        var objSuelo = GameObject.Find("Suelo");
        NivelSuelo = objSuelo.gameObject.transform.position.y;
        DisparosPorJuego = DisparosPorJuegoTotal;
        _ObjetivosTotales = GameObject.FindGameObjectsWithTag("Objetivo").ToList().Count;
        StartGame();
    }
    private void Update()
    {
        switch (ActualRound)
        {
            case RoundState.Preparation:
                if (CheckWin())
                {
                    LevelClearedGame();
                }
                break;
            case RoundState.Action:
                var lstDamageElement = GameObject.FindObjectsByType<_DamageElement>(FindObjectsSortMode.InstanceID);
                lstDamageElement = (from x in lstDamageElement where x.enabled select x).ToArray();
                var lstObstruct = GameObject.FindObjectsByType<Obstaculo>(FindObjectsSortMode.InstanceID);
                lstObstruct = (from x in lstObstruct where !x.IsSleep() select x).ToArray();
                if (lstDamageElement.Length == 0 && lstObstruct.Length == 0)
                {
                    ResoluteRound();
                }
                break;
        }
    }
    #endregion

    #region Ganar/Perder
    public void RemoverObjetivo()
    {
        _ObjetivosTotales--;
    }
    public void ResoluteGame()
    {
        if (CheckWin())
        {
            LevelClearedGame();
        }
        else if( CheckLose()) 
        {
            GameOver();
        }
        else
        {
            StartRound();
        }
    }
    public bool CheckWin()
    {
        return _ObjetivosTotales <= 0;
    }
    public bool CheckLose()
    {
        return DisparosPorJuego <= 0 && _ObjetivosTotales > 0;
    }
    #endregion
}