using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using System;
public class _StructureElement : MonoBehaviour
{
    #region Public Variables
    public int resistence = 2;
    public BloqueTexturaRuptura objTexturaRuptura;
    public bool DamageOnMagnitude;
    public int MagnitudeForDamage = 10;
    public ParticleSystemRenderer particleDeath;
    public List<string> DamageTag;
    public List<string> DestroyTag;
    #endregion

    #region Private Variables
    internal event EventHandler OnDestroyObject;
    internal int resistenceMax = 2;
    List<string> damageLog = new List<string>();
    protected GameManager gameManager;
    Renderer m_Renderer;
    #endregion

    #region Start & Update
    protected virtual void Start()
    {
        gameManager = GameManager.GetManager();
        gameManager.OnRoundStart += delegate { damageLog = new List<string>(); };
        m_Renderer = this.gameObject.GetComponent<Renderer>();
        resistenceMax = resistence;
    }
    void Update()
    {
        if (DamageOnMagnitude)
        {
            var objDamage = this.gameObject.GetComponent<_DamageElement>();
            if (objDamage == null) return;
            objDamage.enabled = GetMagnitude() >= MagnitudeForDamage;
        }
    }
    #endregion

    #region Collisions
    private void OnTriggerEnter(Collider other)
    {
        CheckCollision(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        CheckCollision(collision.gameObject);
    }
    private void CheckCollision(GameObject gameObject)
    {
        var lstDamageTag = (from x in DamageTag where x == gameObject.tag select x).Count();
        if (lstDamageTag > 0)
        {
            _DamageElement dam = gameObject.GetComponent<_DamageElement>();
            if (dam == null) return;
            ReceiveDamage(dam);
            if (resistence <= 0)
            {
                DestroyObject();
            }
        }
        var lstDestroyTag = (from x in DestroyTag where x == gameObject.tag select x).Count();
        if (lstDestroyTag > 0)
        {
            DestroyObject();
        }
    }
    public void ReceiveDamage(_DamageElement damage)
    {
        var Damagedbefore = (from x in damageLog where x == damage.gameObject.GetInstanceID().ToString() select x).Count();
        if (Damagedbefore > 0) return;
        resistence -= damage.damage;
        resistence = resistence < 0 ? 0 : resistence;
        damageLog.Add(damage.gameObject.GetInstanceID().ToString());
        ChangeTexture();
    }
    public void DestroyObject()
    {
        OnDestroyObject?.Invoke(this, EventArgs.Empty);
        var obj = this.gameObject;
        var particleSpawned = Instantiate(particleDeath.gameObject) as GameObject;
        particleSpawned.transform.position = obj.transform.position;
        particleSpawned.GetComponent<ParticleSystemRenderer>().material = m_Renderer.material;
        Destroy(particleSpawned, particleSpawned.GetComponent<ParticleSystem>().main.duration);
        Destroy(this.gameObject);
    }
    public void ChangeTexture()
    {
        if (objTexturaRuptura == null || objTexturaRuptura.texturasGrietas == null || objTexturaRuptura.texturasGrietas.Length == 0) return;
        int indextexture = (int)((resistence * objTexturaRuptura.texturasGrietas.Length) / resistenceMax);
        indextexture = indextexture == 0 ? 1 : indextexture;
        indextexture = objTexturaRuptura.texturasGrietas.Length - indextexture;
        var texturaObj = objTexturaRuptura.texturasGrietas[indextexture];
        var materialObj = m_Renderer.material;
        materialObj.SetTexture("_BaseMap", texturaObj);
    }
    #endregion

    #region get
    public bool IsSleep()
    {
        var objVelocityAvg = GetMagnitude();
        bool sleeping = objVelocityAvg < 1;
        return sleeping;
    }
    public float GetMagnitude()
    {
        var objrigid = this.gameObject.GetComponent<Rigidbody>();
        var objVel = objrigid.velocity;
        var objVelocityAvg = objVel.magnitude;
        return objVelocityAvg;
    }
    #endregion
}