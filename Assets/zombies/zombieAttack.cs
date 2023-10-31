using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage;
    GameObject player;
    valorvidaP playerHealth;
    zombieHealth zombieHealth;
    bool playerInRage;
    float timer;
    Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<valorvidaP>();
        zombieHealth = GetComponent<zombieHealth>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject == player){
            playerInRage = true;
        }
    }
    private void OnCollisionExit(Collision other){
        if (other.gameObject == player){
            playerInRage = false;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks && playerInRage && zombieHealth.isDead == false){
            attack();
        }
    }
    void attack(){
        timer = 0;
        playerHealth.TakeDamage(attackDamage);
        anim.SetTrigger("attack");

    }
}
