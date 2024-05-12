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
    public void ReceiveDamage(_DamageElement damage)
    {
        var Damagedbefore = (from x in damageLog where x == damage.gameObject.GetInstanceID().ToString() select x).Count();
        if (Damagedbefore > 0) return;
        resistence -= damage.damage;
        resistence = resistence < 0 ? 0 : resistence;
        damageLog.Add(damage.gameObject.GetInstanceID().ToString());
        ChangeTexture();
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
        var objrigid = this.gameObject.GetComponent<Rigidbody>();
        var objVel = objrigid.velocity;
        bool sleeping = objrigid.IsSleeping();
        var objVelocityAvg = objVel.magnitude;
        sleeping = objVelocityAvg < 1;
        return sleeping;
    }
}