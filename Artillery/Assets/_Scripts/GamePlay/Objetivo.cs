using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Objetivo : MonoBehaviour
{
    public UnityEvent GameWon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explosion")
        {
            GameManager.GetManager().RemoverObjetivo(this.gameObject);
            Destroy(this.gameObject);
            GameWon.Invoke();
        }
    }
}