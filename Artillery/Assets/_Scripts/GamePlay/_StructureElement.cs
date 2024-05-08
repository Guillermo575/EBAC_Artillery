using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class _StructureElement : MonoBehaviour
{
    #region Variables

    #region Public
    public int resistence = 2;
    public BloqueTexturaRuptura objTexturaRuptura;
    #endregion

    #region Private
    internal int resistenceMax = 2;
    bool damaged = false;
    protected GameManager gameManager;
    Renderer m_Renderer;
    #endregion

    #endregion

    void Start()
    {
        gameManager = GameManager.GetManager();
        m_Renderer = this.gameObject.GetComponent<Renderer>();
        resistenceMax = resistence;
    }
    public void ReceiveDamage(_DamageElement damage)
    {
        if (damaged) return;
        resistence -= damage.damage;
        int indextexture = (int)((resistence * objTexturaRuptura.texturasGrietas.Length) / resistenceMax);
        indextexture = indextexture < 0 ? 0 : indextexture;
        var texturaObj = objTexturaRuptura.texturasGrietas[indextexture];
        var materialObj = m_Renderer.material;
        materialObj.SetTexture("_BaseMap", texturaObj);
        damaged = true;
    }
}