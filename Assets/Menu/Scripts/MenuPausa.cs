using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    public ThirdPersonControllerMovement thirdPerson;
    private bool juegoPausado = false;
   // private ThirdPersonControllerMovement camara;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();               
            }
        }
    }

    public void Pausa()
    {
        thirdPerson = GetComponent<ThirdPersonControllerMovement>();
        thirdPerson.UnlockCursor();
        Debug.Log("se unlockea la camara");
        //juegoPausado = true;
        //Time.timeScale = 0f;
        menuPausa.SetActive(true);
        //pepe camara = GetComponent("ThirdPersonCameraMovement") as pepe;
        //Debug.Log(camara.CursorEnable());
    }
    
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        thirdPerson = GetComponent<ThirdPersonControllerMovement>();
        thirdPerson.LockCursor();
    }

    public void Controles()
    {
        juegoPausado = false;
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
