using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Canon : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject BalaPrefab;
    public GameObject particulaDisparo;
    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;

    private GameObject puntaCanon;
    private float rotacion;
    private GameManager gameManager;
    public static bool Bloqueado;
    #endregion

    #region Start & Update
    void Start()
    {
        gameManager = GameManager.SingletonGameManager;
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("Sonido_Disparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
    }
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * gameManager.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
        if (Input.GetKeyDown(KeyCode.Space) && !Bloqueado)
        {
            if (gameManager.DisparosPorJuego > 0)
            {
                GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                SeguirCamara.objetivo = temp;
                Vector3 direccionDisparo = transform.rotation.eulerAngles;
                direccionDisparo.y = 90 - direccionDisparo.x;
                Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
                GameObject particulas = Instantiate(particulaDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
                tempRB.velocity = direccionDisparo.normalized * gameManager.VelocidadBala;
                gameManager.DisparosPorJuego--;
                //SourceDisparo.PlayOneShot(clipDisparo);
                SourceDisparo.Play();
                Bloqueado = true;
            }
        }
    }
    #endregion
}