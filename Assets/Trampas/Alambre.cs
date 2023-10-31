using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alambre : MonoBehaviour
{
    public int dañoTrampa = 10; // Daño que la trampa inflige a los zombies
    public float slowFactor = 0.5f; // Factor de ralentización
    public int bleedDamage = 1; // Daño por sangrado
    public float bleedDuration = 10.0f; // Duración del sangrado

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            ControladorZombie zombie = other.gameObject.GetComponent<ControladorZombie>();
            if (zombie != null)
            {
                zombie.ApplySlowEffect(slowFactor);
                zombie.ApplyBleedEffect(bleedDamage, bleedDuration);
            }
        }
    }
}