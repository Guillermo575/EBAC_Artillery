using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bala : _DamageElement
{
    #region Variables
    public string Nombre;
    public int FuerzaMinimo = 10;
    public int FuerzaMaximo = 40;
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
            Invoke("Explotar", 3);
        }
        if (gameObject.tag == "Obstaculo" || gameObject.tag == "Objetivo")
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
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
    #endregion
}