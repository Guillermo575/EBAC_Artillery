using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;
    private MenuManager menuManager;
    private GameObject menuPausa;
    private GameObject menuOpciones;
    #endregion

    #region Awake & Update
    private void Start()
    {
        gameManager = GameManager.GetManager();
        menuManager = MenuManager.GetManager();
        gameManager.OnGamePause += MostrarMenuPausa;
        gameManager.OnGameResume += OcultarMenuPausa;
        menuPausa = menuManager.menuPausa;
        menuOpciones = menuManager.menuOpciones;
    }
    private void Update()
    {
        if (!gameManager.IsGameEnd())
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameManager.IsGamePause())
                {
                    gameManager.ResumeGame();
                }
                else
                {
                    gameManager.PauseGame();
                }
            }
        }
    }
    #endregion

    #region Mostrar/Ocultar menu
    private void MostrarMenuPausa(object sender, EventArgs e)
    {
        menuManager.ShowMenu(menuPausa);
    }
    public void OcultarMenuPausa(object sender, EventArgs e)
    {
        menuManager.DeleteMenuTree();
    }
    #endregion

    #region Botones Interfaz
    public void RegresarAPantallaPrincipal()
    {
        MostrarPantallaConfirmar(EventoRegresarAPantallaPrincipal, "¿Desea regresar al menu principal?");
    }
    private void EventoRegresarAPantallaPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void ReintentarNivel()
    {
        MostrarPantallaConfirmar(EventoReintentarNivel, "¿Desea reiniciar el nivel?");
    }
    public void EventoReintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MostrarMenuOpciones()
    {
        menuManager.ShowMenu(menuOpciones);
    }
    public void ResumeGame()
    {
        gameManager.ResumeGame();
    }
    public void BackMenu()
    {
        menuManager.BackMenu();
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