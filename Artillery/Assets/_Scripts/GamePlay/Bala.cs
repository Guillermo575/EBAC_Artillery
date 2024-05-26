using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bala : _DamageElement
{
    #region Variables
    public string Nombre;
    public int FuerzaMinimo = 10;
    public int FuerzaMaximo = 40;
    public int TimeForExplosion = 3;
    public GameObject particulaExplosion;
    private bool Colision;
    #endregion

    #region Start & Update
    void Start()
    {
        gameManager = GameManager.GetManager();
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
        CheckCollision(collision.gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        CheckCollision(collision.gameObject);
    }
    private void CheckCollision(GameObject gameObject)
    {
        if (gameObject.tag == "Suelo" && !Colision)
        {
            Colision = true;
            if (TimeForExplosion <= 0)
            {
                Explotar();
            }
            else
            {
                Invoke("Explotar", TimeForExplosion);
            }
        }
        if (gameObject.tag == "Obstaculo" || gameObject.tag == "Objetivo")
        {
            Colision = true;
            Invoke("Explotar", 0.001f);
        }
    }
    #endregion

    #region Ball Destroy
    public void Explotar()
    {
        GameObject particulas = Instantiate(particulaExplosion, transform.position, Quaternion.identity) as GameObject;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
    #endregion
}