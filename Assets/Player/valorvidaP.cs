using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valorvidaP : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    bool isDead;
    bool damage;
    public Slider slider;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount){
        if (isDead == true)return;
        damage = true;
        currentHealth -= amount;
        slider.value = currentHealth;
        if(currentHealth <= 0)Dead();}
    private void Dead(){
        isDead = true;
        anim.SetTrigger("deaht");
    }
}
