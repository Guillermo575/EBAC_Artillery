using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuFinNivel : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;
    private MenuManager menuManager;
    private GameObject menuFinNivel; //Ganar
    private GameObject menuFinJuego; //Perder
    #endregion

    #region Awake
    private void Start()
    {
        menuManager = MenuManager.GetManager();
        if (menuManager != null)
        {
            menuFinNivel = menuManager.menuFinNivel;
            menuFinJuego = menuManager.menuFinJuego;
            gameManager = GameManager.GetManager();
            if (gameManager != null)
            {
                gameManager.OnGameLevelCleared += delegate { menuManager.ShowMenu(menuFinNivel); };
                gameManager.OnGameOver += delegate { menuManager.ShowMenu(menuFinJuego); };
            }
        }
    }
    #endregion

    #region Eventos
    public void SiguienteNivel()
    {
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ReintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RegresarAPantallaPrincipal()
    {
        MostrarPantallaConfirmar(EventoRegresarAPantallaPrincipal, "¿Desea regresar al menu principal?");
    }
    private void EventoRegresarAPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    #region Panel Confirmar
    private void MostrarPantallaConfirmar(UnityAction evt, String msg)
    {
        var menuConfirmar = menuManager.menuConfirmar;
        if (menuConfirmar != null)
        {
            UnityEvent objEvent = new UnityEvent();
            objEvent.AddListener(evt);
            menuConfirmar.OpenWindow(objEvent, msg);
        }
        else
        {
            evt();
        }
    }
    #endregion
}