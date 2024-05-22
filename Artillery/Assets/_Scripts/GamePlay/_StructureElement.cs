using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
public class _StructureElement : MonoBehaviour
{
    #region Variables

    #region Public
    public int resistence = 2;
    public BloqueTexturaRuptura objTexturaRuptura;
    public bool DamageOnMagnitude;
    public int MagnitudeForDamage = 10;
    public ParticleSystemRenderer particleDeath;
    #endregion

    #region Private
    internal int resistenceMax = 2;
    List<string> damageLog = new List<string>();
    protected GameManager gameManager;
    Renderer m_Renderer;
    #endregion

    #endregion

    void Start()
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
}