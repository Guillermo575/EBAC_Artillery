using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SeguirCamara : MonoBehaviour
{
    #region Variables
    public static GameObject objetivo;
    [Header("Configurar en editor")]
    public float suavizado = 0.05f;
    public Vector2 limiteXY = Vector2.zero;
    [Header("Configuracion Dinamica")]
    public float camZ;
    private GameManager gameManager;
    #endregion

    #region Awake & Fixed Update
    void Start()
    {
        gameManager = GameManager.GetManager();
        gameManager.OnRoundStart += delegate {
            objetivo = null;
        };
    }
    private void Awake()
    {
        camZ = this.transform.position.z;
    }
    private void FixedUpdate()
    {
        Vector3 destino;
        if (objetivo == null)
        {
            destino = Vector3.zero;
        }
        else
        {
            destino = objetivo.transform.position;
        }
        destino.x = Mathf.Max(limiteXY.x, destino.x);
        destino.y = Mathf.Max(limiteXY.y, destino.y);
        destino = Vector3.Lerp(transform.position, destino, suavizado);
        destino.z = camZ;
        transform.position = destino;
        Camera.main.orthographicSize = destino.y + 20;
    }
    #endregion
}