using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaOso : MonoBehaviour
{
    public zombieHealth dañoaZombie;
    public float stunFactor = 0f; // Factor de ralentización
    public int dañoTrampa = 10; // Daño que la trampa inflige a los zombies

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            ControladorZombie zombie = other.gameObject.GetComponent<ControladorZombie>();
            if (zombie != null)
            {
                zombie.ApplyStunEffect(stunFactor);
                dañoaZombie.TakeDamage(dañoTrampa);
            }
        }
    }
}
