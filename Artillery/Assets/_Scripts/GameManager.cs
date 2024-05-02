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
    public int VelocidadBala { get => _VelocidadBala; set => _VelocidadBala = value; }
    public int DisparosPorJuego { get => _DisparosPorJuego; set => _DisparosPorJuego = value; }
    public int DisparosPorJuegoTotal { get => _DisparosPorJuegoTotal; set => _DisparosPorJuegoTotal = value; }
    public float VelocidadRotacion { get => _VelocidadRotacion; set => _VelocidadRotacion = value; }
    public float NivelSuelo { get => _NivelSuelo; set => _NivelSuelo = value; }

    [SerializeField] private int _VelocidadBala = 30;
    [SerializeField] private int _DisparosPorJuego = 10;
    [SerializeField] private int _DisparosPorJuegoTotal = 10;
    [SerializeField] private float _VelocidadRotacion = 1;

    private float _NivelSuelo = -1000;
    private List<GameObject> lstObjetivos;
    private MenuManager menuManager;
    #endregion

    #region Level Game Variables
    private bool GameEnd = false;
    public bool IsGameEnd() {  return GameEnd; }

    private bool GamePause = false;
    public bool IsGamePause() { return GamePause; }

    private bool LevelCleared = false;
    public bool IsLevelCleared() { return LevelCleared; }
    #endregion

    #region EventHandlers
    public event EventHandler OnGameStart;
    public event EventHandler OnGamePause;
    public event EventHandler OnGameResume;
    public event EventHandler OnGameEnd;
    public event EventHandler OnGameOver;
    public event EventHandler OnGameExit;
    public event EventHandler OnGameLevelCleared;
    public event EventHandler OnLifeLose;
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
    public void LifeLose()
    {
        OnLifeLose?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    #region Awake, Start & Update
    private void Awake()
    {
        CreateSingleton();
        OnGameStart += delegate { Time.timeScale = 1; };
        OnGamePause += delegate { Time.timeScale = 0; };
        OnGameResume += delegate { Time.timeScale = 1; };
        OnGameEnd += delegate { Time.timeScale = 0; };
        OnGameOver += delegate { Time.timeScale = 0; };
        OnGameExit += delegate { Time.timeScale = 1; };
        OnGameLevelCleared += delegate { Time.timeScale = 0; };
    }
    private void Start()
    {
        var objSuelo = GameObject.Find("Suelo");
        NivelSuelo = objSuelo.gameObject.transform.position.y;
        DisparosPorJuego = DisparosPorJuegoTotal;
        lstObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").ToList();
        menuManager = MenuManager.GetManager();
    }
    private void Update()
    {
        if (DisparosPorJuego <= 0 && !Canon.Bloqueado && !GameEnd)
        {
            StartCoroutine(ComprobarPerderJuego());
        }
    }
    #endregion

    #region Ganar/Perder
    public void RemoverObjetivo(GameObject obj)
    {
        lstObjetivos.Remove(this.gameObject);
    }
    public void GanarJuego()
    {
        if (lstObjetivos.Count == 0)
        {
            Canon.Bloqueado = true;
            GameEnd = true;
            menuManager.menuFinNivel.SetActive(true);
        }
    }
    IEnumerator ComprobarPerderJuego()
    {
        yield return new WaitForSeconds(2);
        if (lstObjetivos.Count > 0)
        {
            PerderJuego();
        }
    }
    public void PerderJuego()
    {
        Canon.Bloqueado = true;
        GameEnd = true;
        menuManager.menuFinJuego.SetActive(true);
    }
    #endregion
}