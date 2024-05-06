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
    [SerializeField] private float rotacion;
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
        gameManager.OnGameStart += delegate { Bloqueado = false; };
        gameManager.OnGamePause += delegate { Bloqueado = true; };
        gameManager.OnGameResume += delegate { Bloqueado = false; };
        gameManager.OnGameEnd += delegate { Bloqueado = true; };
        gameManager.OnGameOver += delegate { Bloqueado = true; };
        gameManager.OnGameLevelCleared += delegate { Bloqueado = true; };
        Bloqueado = false;
        lineaRastro.positionCount = 0;
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
        if (Bloqueado) return;
        var ValorFuerza = modificarFuerza.ReadValue<float>();
        gameManager.VelocidadBala += ValorFuerza * 0.1f;
        if (gameManager.VelocidadBala > 40) gameManager.VelocidadBala = 40;
        if (gameManager.VelocidadBala < 10) gameManager.VelocidadBala = 10;
        var ValorApuntar = apuntar.ReadValue<float>();
        rotacion += ValorApuntar * gameManager.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
        if (ValorFuerza != 0 || ValorApuntar != 0 || lineaRastro.positionCount == 0)
        {
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            UpdateTrajectory(puntaCanon.transform.position, (direccionDisparo.normalized * gameManager.VelocidadBala), Physics.gravity);
        }
    }
    public void ShotBullet(InputAction.CallbackContext context)
    {
        if (gameManager.IsGamePause() || Bloqueado || gameManager.DisparosPorJuego == 0) return;
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
    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        if (Bloqueado) return;
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