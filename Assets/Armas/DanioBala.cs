using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioBala : MonoBehaviour
{
    public GameObject[] zombiePrefab;
    public int danioBala;

    void OnCollisionEnter(Collision other)
    { 
        Debug.Log("1");
        if (other.gameObject.CompareTag("zombie"))
        {
            foreach (GameObject tipozombie in zombiePrefab)
            {
                Debug.Log("si le toy pegando");
                ControladorZombie zombie = other.gameObject.GetComponent<ControladorZombie>();
                if (zombie != null)
                {
                    Debug.Log("aplicando danio");
                    zombie.TakeDamage(danioBala);
                }
            }

            Destroy(gameObject); // Esto se ejecuta fuera del bucle foreach para destruir el objeto una vez que se ha aplicado el daño a todos los zombies
        }
    }
}



