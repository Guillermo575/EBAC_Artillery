using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstaculo : _StructureElement
{
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
        if (gameObject.tag == "Explosion" || gameObject.tag == "Bala")
        {
            _DamageElement dam = gameObject.GetComponent<_DamageElement>();
            if (dam == null) return;
            ReceiveDamage(dam);
            if (resistence <= 0)
            {
                DestroyObject();
            }
        }
    }
}