using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Objetivo : _StructureElement
{
    protected override void Start()
    {
        base.Start();
        OnDestroyObject += delegate { GameManager.GetManager().RemoverObjetivo(); };
    }
}