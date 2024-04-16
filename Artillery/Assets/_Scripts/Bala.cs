using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bala : MonoBehaviour
{
    #region Variables
    public GameObject particulaExplosion;
    public AudioClip clipExplosion;
    private GameObject SonidoExplosion;
    private AudioSource SourceExplosion;
    private GameManager gameManager;
    private bool Destruyendose;
    #endregion

    #region Start & Update
    void Start()
    {
        gameManager = GameManager.SingletonGameManager;
        SonidoExplosion = GameObject.Find("Sonido_Explosion");
        SourceExplosion = SonidoExplosion.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!Destruyendose && this.gameObject.transform.position.y < gameManager.NivelSuelo)
        {
            StartCoroutine(CoroutineBallDeath());
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Obstaculo" || collision.gameObject.tag == "Enemigo") && !Destruyendose)
        {
            //StartCoroutine(CoroutineBallDeath());
            Destruyendose = true;
            GameObject particulas = Instantiate(particulaExplosion, this.gameObject.transform);
            SourceExplosion.Play();
        }
    }
    #endregion

    #region Ball Destroy
    IEnumerator CoroutineBallDeath()
    {
        Destruyendose = true;
        yield return new WaitForSecondsRealtime(2f);
        Canon.Bloqueado = false;
        Destroy(this.gameObject);
    }
    #endregion
}