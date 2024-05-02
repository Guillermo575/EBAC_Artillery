using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Canon : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject BalaPrefab;
    public LineRenderer lineaRastro;
    public GameObject particulaDisparo;
    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;

    private GameObject puntaCanon;
    private float rotacion;
    private float rotacionAnterior = -999;
    private GameManager gameManager;
    public static bool Bloqueado;
    #endregion

    #region Controles
    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;
    #endregion

    #region Start & Update
    private void Awake()
    {
        canonControls = new CanonControls();
    }
    private void OnEnable()
    {
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificarFuerza;
        disparar = canonControls.Canon.Disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += ShotBullet;
    }
    void Start()
    {
        gameManager = GameManager.GetManager();
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("Sonido_Disparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
    }
    void Update()
    {
        ChangeAngle();
        if (Bloqueado)
        {
            lineaRastro.positionCount = 0;
        }
    }
    public void ChangeAngle()
    {
        if (gameManager.IsGamePause()) return;
        rotacion += apuntar.ReadValue<float>() * gameManager.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
        if (rotacion != rotacionAnterior)
        {
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            rotacionAnterior = rotacion;
            if (!Bloqueado)
                UpdateTrajectory(puntaCanon.transform.position, (direccionDisparo.normalized * gameManager.VelocidadBala), Physics.gravity);
        }
    }
    public void ShotBullet(InputAction.CallbackContext context)
    {
        if (gameManager.IsGamePause()) return;
        if (!Bloqueado)
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
    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = 100; // for example
        float timeDelta = 1.0f / initialVelocity.magnitude; // for example
        lineaRastro.positionCount = (numSteps);
        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            lineaRastro.SetPosition(i, position);
            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;
        }
    }
    #endregion
}