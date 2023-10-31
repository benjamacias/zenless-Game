using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moneda es un componente de el gameObject moneda
public class moneda : MonoBehaviour
{
    public int valorMoneda = 5;
    public GameObject itemPrefab;

   
    public void itemDropped(){
     Instantiate (itemPrefab, transform.position, Quaternion.identity);
        }
    public void OnCollisionEnter(Collision collision)
    {
        GameObject objeto = collision.gameObject;
        if (objeto.tag == "Player")
        {
            objeto.GetComponent<Control>().incremento(valorMoneda);
            Destroy(gameObject);
        }
    }
    
}
