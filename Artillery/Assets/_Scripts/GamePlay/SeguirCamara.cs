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
    private Vector3 InitialPosition;
    private float InitialSize;
    private GameManager gameManager;
    #endregion

    #region Awake & Fixed Update
    void Start()
    {
        gameManager = GameManager.GetManager();
        gameManager.OnRoundStart += delegate {
            objetivo = null;
        };
        InitialPosition = this.transform.position;
        InitialSize = Camera.main.orthographicSize;
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
            destino.x = InitialPosition.x;
            destino.y = InitialPosition.y;
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
        if (objetivo != null)
        {
            Camera.main.orthographicSize = destino.y + InitialSize;
        }
        else
        {
            Camera.main.orthographicSize = InitialSize;
        }
    }
    #endregion
}