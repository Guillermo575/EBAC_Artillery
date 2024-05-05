using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstaculo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explosion" || other.tag == "Bala")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Explosion" || collision.gameObject.tag == "Bala")
        {
            Destroy(this.gameObject);
        }
    }
}