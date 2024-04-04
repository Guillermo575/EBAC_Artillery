using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bala : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;
    #endregion

    #region Start & Update
    void Start()
    {
        gameManager = GameManager.SingletonGameManager;
    }
    void Update()
    {
        if (this.gameObject.transform.position.y < gameManager.NivelSuelo)
        {
            StartCoroutine(CoroutineBallDeath());
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Solido")
        {
            StartCoroutine(CoroutineBallDeath());
        }
    }
    #endregion

    #region Ball Destroy
    IEnumerator CoroutineBallDeath()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(this.gameObject);
    }
    #endregion
}