using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarTrampa : MonoBehaviour
{
    public GameObject trampa1; // Trampa de Oso
    public GameObject trampa2; // Trampa de Alambre
    public GameObject trampa3; // Trampa Eléctrica
    public GameObject trampa4; // Trampa de Fuego
    public GameObject trampa5; // Trampa Explosiva
    public GameObject interfazColocacion;
    public bool interfazColocacionActiva;
    private GameObject trampaSeleccionada; // Muestra la trampa seleccionada
    private GameObject trampaColocada; // Coloca la trampa seleccionada

    public void Start()
    {
        DesactivarTodasLasTrampas();
        interfazColocacion.SetActive(false);
    }

    // Desactivar todas las trampas
    public void DesactivarTodasLasTrampas()
    {
        trampa1.SetActive(false);
        trampa2.SetActive(false);
        trampa3.SetActive(false);
        trampa4.SetActive(false);
        trampa5.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (interfazColocacion.activeSelf)
            {
                Debug.Log("Modo Colocación Desactivado");
                interfazColocacion.SetActive(false);
                DesactivarTodasLasTrampas();
            }
            else
            {
                Debug.Log("Modo Colocación Activado");
                interfazColocacion.SetActive(true);
            }
        }

        if (interfazColocacion.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DesactivarTodasLasTrampas();
                trampa1.SetActive(true);
                trampaSeleccionada = trampa1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DesactivarTodasLasTrampas();
                trampa2.SetActive(true);
                trampaSeleccionada = trampa2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                DesactivarTodasLasTrampas();
                trampa3.SetActive(true);
                trampaSeleccionada = trampa3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                DesactivarTodasLasTrampas();
                trampa4.SetActive(true);
                trampaSeleccionada = trampa4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                DesactivarTodasLasTrampas();
                trampa5.SetActive(true);
                trampaSeleccionada = trampa5;
            }

            if (Input.GetKeyDown(KeyCode.E) && trampaSeleccionada != null)
            {
                ColocarTrampaSeleccionada();
            }
        }
    }

    public void ColocarTrampaSeleccionada()
    {
        if (trampaSeleccionada != null)
        {
            Vector3 posicionTrampa = transform.position + transform.forward * 2f; 
            Quaternion rotacionTrampa = trampaSeleccionada.transform.rotation; 
            trampaColocada = Instantiate(trampaSeleccionada, posicionTrampa, rotacionTrampa);
        }
    }

}
