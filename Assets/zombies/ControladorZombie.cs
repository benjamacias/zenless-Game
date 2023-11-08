using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ControladorZombie : MonoBehaviour
{
    public int maxHealth; // Vida máxima del zombie
    public int currentHealth; // Vida actual del zombie
    public bool isDead; 
    private bool damage;
    private Animator anim;
    private float originalSpeed;
    private float slowTimer;
    private float stunTimer;
    private float bleedTimer;
    private float burnTimer;
    private int burnDamagePerSecond = 5;
    private float burnDuration = 5.0f;

    private void Start()
    {
        originalSpeed = GetComponent<NavMeshAgent>().speed;
        slowTimer = 0.0f;
        bleedTimer = 0.0f;
        burnTimer = 0.0f;
        isDead = false;

        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead)return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("death");
        Destroy(gameObject, 2);
    }

    public void ApplySlowEffect(float factor)
    {
        float duration = 5.0f;
        GetComponent<NavMeshAgent>().speed = originalSpeed * factor;
        slowTimer = duration;
        StartCoroutine(RestoreSpeedAfterDelay(duration));
    }

    public void ApplyStunEffect(float factor)
    {
        float duration = 5.0f;
        GetComponent<NavMeshAgent>().speed = factor;
        stunTimer = duration;
        StartCoroutine(RestoreSpeedAfterDelay(duration));
    }

    public void ApplyBleedEffect(int damage, float duration)
    {
        bleedTimer = duration;
        StartCoroutine(BleedEffect(damage));
    }

    public void ApplyBurnEffect(int damage, float duration)
    {
        burnTimer = duration;
        StartCoroutine(BurnEffect(damage));
    }

    private IEnumerator BleedEffect(int damage)
    {
        while (bleedTimer > 0)
        {
            TakeDamage(damage);
            yield return new WaitForSeconds(1.0f);
            bleedTimer -= 1.0f;
        }
    }

    private IEnumerator BurnEffect(int damage)
    {
        while (burnTimer > 0)
        {
            TakeDamage(damage);
            yield return new WaitForSeconds(1.0f);
            burnTimer -= 1.0f;
        }
    }

    public IEnumerator RestoreSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<NavMeshAgent>().speed = originalSpeed;
    }
}
