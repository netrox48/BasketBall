using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        Destroy(other.gameObject);
    }
}
