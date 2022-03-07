using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 20;
    [SerializeField] int maxHealth = 100;

    private int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void AttackButtonDown()
    {
        if (!m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !m_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            Attack();
        }
    }
   

    private void Attack()
    {
        //Play an attack animation
        m_animator.SetTrigger("Attack");

        // Detectenemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Skeleton>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        m_animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        m_animator.SetTrigger("Death");


        // restart level
    }
}
