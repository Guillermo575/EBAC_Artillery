using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bala : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;
    private bool Destruyendose;
    #endregion

    #region Start & Update
    void Start()
    {
        gameManager = GameManager.SingletonGameManager;
    }
    void Update()
    {
        if (!Destruyendose && this.gameObject.transform.position.y < gameManager.NivelSuelo)
        {
            Destruyendose = true;
            StartCoroutine(CoroutineBallDeath());
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Enemigo")
        //{
        //    StartCoroutine(CoroutineBallDeath());
        //}
    }
    #endregion

    #region Ball Destroy
    IEnumerator CoroutineBallDeath()
    {
        yield return new WaitForSecondsRealtime(2f);
        Canon.Bloqueado = false;
        Destroy(this.gameObject);
    }
    #endregion
}