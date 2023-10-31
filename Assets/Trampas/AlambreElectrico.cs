using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlambreElectrico : MonoBehaviour
{
    public zombieHealth dañoaZombie;
    public int dañoTrampa = 10; // Daño que la trampa inflige a los zombies

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zombie")
        {
            if (dañoaZombie != null)
            {
                dañoaZombie.TakeDamage(dañoTrampa);

            }
        }
    }
}
