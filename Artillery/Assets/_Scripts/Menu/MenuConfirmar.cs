using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class MenuConfirmar : MonoBehaviour
{
    #region Variables
    public TMP_Text txtTitulo;
    UnityEvent EventoConfirmar;
    private MenuManager menuManager;
    #endregion

    #region Awake
    void Start()
    {
        menuManager = MenuManager.GetManager();
    }
    #endregion

    #region General
    public void OpenWindow(UnityEvent EventoConfirmar, string titulo = null)
    {
        menuManager = MenuManager.GetManager();
        menuManager.ShowMenu(this.gameObject);
        this.EventoConfirmar = EventoConfirmar;
        if (!string.IsNullOrEmpty(titulo))
        {
            txtTitulo.text = titulo;
        }
    }
    public void ConfirmarNo()
    {
        menuManager.BackMenu();
    }
    public void ConfirmarSi()
    {
        EventoConfirmar.Invoke();
        menuManager.BackMenu();
    }
    #endregion
}