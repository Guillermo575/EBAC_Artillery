using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bala : MonoBehaviour
{
    #region Variables
    public GameObject particulaExplosion;
    private GameManager gameManager;
    private bool Colision;
    #endregion

    #region Start & Update
    void Start()
    {
        gameManager = GameManager.SingletonGameManager;
    }
    void Update()
    {
        if (transform.position.y < gameManager.NivelSuelo)
        {
            Explotar();
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Colision = true;
            Invoke("Explotar", 3);
        }
        if ((collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Objetivo") && !Colision)
        {
            Colision = true;
            Explotar();
        }
    }
    #endregion

    #region Ball Destroy
    public void Explotar()
    {
        GameObject particulas = Instantiate(particulaExplosion, transform.position, Quaternion.identity) as GameObject;
        Canon.Bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
    #endregion
}