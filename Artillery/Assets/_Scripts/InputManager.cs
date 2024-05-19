using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    #region Singleton
    private static InputManager SingletonGameManager;
    private InputManager()
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
    public static InputManager GetManager()
    {
        return SingletonGameManager;
    }
    #endregion

    #region Variables
    public InputActionAsset MainInput;
    public List<InputActionAsset> lstInputs;
    #endregion

    #region Awake & Start & Update
    void Awake()
    {
        CreateSingleton();
        MainInput = MainInput == null ? lstInputs.First() : MainInput;
    }
    void Start()
    {
    }
    void Update()
    {
    }
    #endregion

    #region General
    public InputAction GetAction(string actionName)
    {
        return MainInput.FindAction(actionName);
    }
    #endregion
}