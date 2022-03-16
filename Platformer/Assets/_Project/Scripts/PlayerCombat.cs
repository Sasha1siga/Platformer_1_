using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animatorPlayer;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] HealthBar healthBarSkript;

    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 20;
    [SerializeField] int maxHealth = 100;

    private int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBarSkript.SetMaxHealth(maxHealth);
    }
    public void AttackButtonDown()
    {
        if (!animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            Attack();
        }
    }
   

    private void Attack()
    {
        //Play an attack animation
        animatorPlayer.SetTrigger("Attack");

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
        animatorPlayer.SetTrigger("Hurt");
        healthBarSkript.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animatorPlayer.SetTrigger("Death");


        // restart level
    }

    
      
}
