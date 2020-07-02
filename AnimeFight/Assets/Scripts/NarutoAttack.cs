using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutoAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 5;
    public int attackDamage2 = 7;
    public float attackRate = 3f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
                
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
        
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D Goku in hitEnemies)
        {
            Goku.GetComponent<GokuHP>().TakeDamage(attackDamage);
        }
        
    }
    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null) 
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    void Attack2()
    {
        animator.SetTrigger("Attack2");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D Goku in hitEnemies)
        {
            Goku.GetComponent<GokuHP>().TakeDamage(attackDamage2);
        }

    }
    
}
