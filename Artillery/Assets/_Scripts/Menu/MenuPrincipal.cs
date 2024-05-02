using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    #region Variables
    private MenuManager menuManager;
    private GameObject menuOpciones;
    #endregion

    #region Awake
    void Start()
    {
        Time.timeScale = 1;
        menuManager = MenuManager.GetManager();
        menuOpciones = menuManager.menuOpciones;
    }
    #endregion

    #region Interfaz
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void MostrarOpciones()
    {
        menuManager.ShowMenu(menuOpciones);
    }
    public void FinalizarJuego()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        menuManager.BackMenu();
    }
    #endregion
}