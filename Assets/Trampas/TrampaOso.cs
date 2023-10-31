using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaOso : MonoBehaviour
{
    public zombieHealth dañoaZombie;
    public float slowFactor = 0f; // Factor de ralentización
    public int dañoTrampa = 10; // Daño que la trampa inflige a los zombies

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            ControladorZombie zombie = other.gameObject.GetComponent<ControladorZombie>();
            if (zombie != null)
            {
                zombie.ApplySlowEffect(slowFactor);
                dañoaZombie.TakeDamage(dañoTrampa);
            }
        }
    }
}
