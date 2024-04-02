using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager SingletonGameManager;
    public static int VelocidadBala = 30;
    public static int DisparosPorJuego = 10;
    public static float VelocidadRotacion = 1;

    private void Awake()
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
}