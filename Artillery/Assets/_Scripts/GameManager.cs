using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager SingletonGameManager;
    private GameManager()
    {
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
    private bool JuegoTerminado = false;
    public GameObject CanvasGanar;
    public GameObject CanvasPerder;
    #endregion

    #region Awake
    private void Awake()
    {
        if (SingletonGameManager == null)
        {
            SingletonGameManager = this;
            var objSuelo = GameObject.Find("Suelo");
            NivelSuelo = objSuelo.gameObject.transform.position.y;
            DisparosPorJuego = DisparosPorJuegoTotal;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }
    private void Update()
    {
        if (DisparosPorJuego <= 0 && !Canon.Bloqueado && !JuegoTerminado)
        {
            PerderJuego();
        }
    }
    #endregion

    #region Ganar/Perder
    public void GanarJuego()
    {
        Canon.Bloqueado = true;
        JuegoTerminado = true;
        CanvasGanar.SetActive(true);
    }
    public void PerderJuego()
    {
        Canon.Bloqueado = true;
        JuegoTerminado = true;
        CanvasPerder.SetActive(true);
    }
    #endregion
}