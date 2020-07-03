using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutoHP : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    public NarutoHealthBarScript healthBar;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Ennemy died !");
        animator.SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().simulated = false;
       

        this.enabled = false;
    }

}
