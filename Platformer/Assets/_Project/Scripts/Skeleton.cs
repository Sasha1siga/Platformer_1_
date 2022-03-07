using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] Rigidbody2D skeletonRigitBody;
    [SerializeField] SpriteRenderer skeletonSpriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] PlayerCombat PlayerCombatSkript;


    [SerializeField] float distance;
    [SerializeField] float step;
    [SerializeField] float run;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int damage = 10;

    private int currentHealth;
    private bool switchAttack_A6 = true;
    private string currentAnimation;
    private float posPlayerX;
    private bool seePlayer = false;
    private bool isDead= false;
    private float spavnPoint;
    void Start()
    {
        spavnPoint = transform.position.x;
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (seePlayer)
        {
            if (Mathf.Abs(posPlayerX - transform.position.x) <= 1f)
            {
                skeletonRigitBody.velocity = Vector2.zero;
                if (posPlayerX - transform.position.x < 0) //игрок слева
                {
                    skeletonSpriteRenderer.flipX = true;
                }
                else skeletonSpriteRenderer.flipX = false;
            }
            /*else if (currentAnimation == "Hit")
            {
                skeletonRigitBody.velocity = new Vector2(skeletonRigitBody.velocity.x /2f, skeletonRigitBody.velocity.y)  ;
            }
            */
            
            
            else if (posPlayerX - transform.position.x < 0) //игрок слева
            {
                StepOnLeft(run);
                skeletonSpriteRenderer.flipX = true;
            }
            else
            {
                StepOnRight(run);// игрок справа
                skeletonSpriteRenderer.flipX = false;
            }


            // урон по герою
            if (skeletonSpriteRenderer.sprite.name == "attack-A6" && switchAttack_A6)
            {
                PlayerCombatSkript.TakeDamage(damage);
                switchAttack_A6 = false;
                skeletonSpriteRenderer.sortingOrder = 5;
            }
            if (skeletonSpriteRenderer.sprite.name != "attack-A6" && !switchAttack_A6)
            {
                switchAttack_A6 = true;
            }


        }
        else if (transform.position.x <= spavnPoint   )
        {
            StepOnRight(step);
            skeletonSpriteRenderer.flipX = false;
        }
        else if (transform.position.x > spavnPoint + distance)
        {
            StepOnLeft(step);
            skeletonSpriteRenderer.flipX = true;
            
        } 
    }



    private void StepOnRight(float speed)
    {
        skeletonRigitBody.velocity = ( new Vector2(speed, 0));
    }
    private void StepOnLeft(float speed)
    {
        skeletonRigitBody.velocity = (new Vector2(-speed, 0));
    }



    public void PlayerHere(float posPlayer)
    {
        seePlayer = true;
        posPlayerX = posPlayer;
    }
    public void PlayerLost()
    {
        seePlayer = false;
    }

    public void ChangeAnimation(string NewAnimation)
    {
        if (currentAnimation != NewAnimation && !isDead)
        {

            animator.Play(NewAnimation);
            currentAnimation = NewAnimation;
            
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.Play("Dead");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
