using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameManager;

public class Canon : MonoBehaviour
{
    #region Variables
    [SerializeField] private Bala BalaPrefab;
    public List<Bala> lstBalas;
    public LineRenderer lineaRastro;
    public GameObject particulaDisparo;
    AudioManager audioManager;
    public AudioClip clipDisparo;
    #endregion

    #region privado
    [SerializeField] private float rotacion;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;
    private GameObject puntaCanon;
    private GameManager gameManager;
    public Bala GetBalaPrefab(){ return BalaPrefab; }
    private int IndexBala = 0;
    #endregion

    #region Controles
    private InputManager inputManager;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;
    private InputAction cambiarBala;
    #endregion

    #region Start & Update
    private void Awake()
    {
    }
    private void OnEnable()
    {
    }
    void Start()
    {
        gameManager = GameManager.GetManager();
        audioManager = AudioManager.GetManager();
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("Sonido_Disparo");
        SourceDisparo = audioManager.SFX;
        lineaRastro.positionCount = 0;
        inputManager = InputManager.GetManager();
        apuntar = inputManager.GetAction("Apuntar");
        modificarFuerza = inputManager.GetAction("Modificar_Fuerza");
        disparar = inputManager.GetAction("Disparar");
        cambiarBala = inputManager.GetAction("Cambiar_Bala");
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        cambiarBala.Enable();
        disparar.performed += ShotBullet;
        cambiarBala.performed += ChangeBullet;
    }
    void Update()
    {
        switch (gameManager.ActualRound)
        {
            case RoundState.Preparation:
                ChangeAngle();
                break;
            default:
                lineaRastro.positionCount = 0;
                break;
        }
    }
    #endregion

    #region Controles
    public void ChangeAngle()
    {
        if (gameManager.IsGameConstrolsDisabled) return;
        var ValorFuerza = modificarFuerza.ReadValue<float>();
        gameManager.VelocidadBala += ValorFuerza * 0.1f;
        if (gameManager.VelocidadBala > BalaPrefab.FuerzaMaximo) gameManager.VelocidadBala = BalaPrefab.FuerzaMaximo;
        if (gameManager.VelocidadBala < BalaPrefab.FuerzaMinimo) gameManager.VelocidadBala = BalaPrefab.FuerzaMinimo;
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
        if (gameManager.IsGameConstrolsDisabled || gameManager.DisparosPorJuego == 0) return;
        GameObject temp = Instantiate(BalaPrefab.gameObject, puntaCanon.transform.position, transform.rotation);
        Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        SeguirCamara.objetivo = temp;
        Vector3 direccionDisparo = transform.rotation.eulerAngles;
        direccionDisparo.y = 90 - direccionDisparo.x;
        Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
        GameObject particulas = Instantiate(particulaDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
        tempRB.velocity = direccionDisparo.normalized * gameManager.VelocidadBala;
        if (!gameManager.BalasInfinitas) gameManager.DisparosPorJuego--;
        SourceDisparo.clip = clipDisparo;
        SourceDisparo.Play();
        gameManager.ActionRound();
    }
    public void ChangeBullet(InputAction.CallbackContext context)
    {
        IndexBala++;
        IndexBala = IndexBala >= lstBalas.Count() ? 0 : IndexBala;
        BalaPrefab = lstBalas[IndexBala];
        gameManager.VelocidadBala = (BalaPrefab.FuerzaMaximo + BalaPrefab.FuerzaMinimo) / 2;
        Vector3 direccionDisparo = transform.rotation.eulerAngles;
        direccionDisparo.y = 90 - direccionDisparo.x;
        UpdateTrajectory(puntaCanon.transform.position, (direccionDisparo.normalized * gameManager.VelocidadBala), Physics.gravity);
    }
    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        if (gameManager.IsGameConstrolsDisabled) return;
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