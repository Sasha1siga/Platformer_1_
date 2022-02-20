using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float            distance;
    public float            step;
    public float            run;
    public Rigidbody2D      rb;
    public SpriteRenderer   sr;
    public BoxCollider2D    Reacted;
    public Animator         animator;
    public Hero             SkriptHero;

    private bool            SwitchAttack_A6 = true;
    private float           DPS = 1;
    private string          CurrentAnimation;
    private float           HP_Scelets = 3;
    private float           posEnemyX;
    private bool            SeeEnemy = false;
    private float           spavnPoint;
    void Start()
    {
          spavnPoint = transform.position.x;
    }

    void FixedUpdate()
    {
        if (SeeEnemy)
        {
            if (Mathf.Abs(posEnemyX - transform.position.x) <= 1f)
            {
                rb.velocity = Vector2.zero;
                if (posEnemyX - transform.position.x < 0) //игрок слева
                {
                    sr.flipX = true;
                }
                else sr.flipX = false;
            }
            /*else if (CurrentAnimation == "Hit")
            {
                rb.velocity = new Vector2(rb.velocity.x /2f, rb.velocity.y)  ;
            }
            */
            
            
            else if (posEnemyX - transform.position.x < 0) //игрок слева
            {
                StepOnLeft(run);
                sr.flipX = true;
            }
            else
            {
                StepOnRight(run);// игрок справа
                sr.flipX = false;
            }


            // урон по герою
            if (sr.sprite.name == "attack-A6" && SwitchAttack_A6)
            {
                SkriptHero.GetDamage(DPS);
                SwitchAttack_A6 = false;
            }
            if (sr.sprite.name != "attack-A6" && !SwitchAttack_A6)
            {
                SwitchAttack_A6 = true;
            }


        }
        else if (transform.position.x <= spavnPoint   )
        {
            StepOnRight(step);
            sr.flipX = false;
        }
        else if (transform.position.x > spavnPoint + distance)
        {
            StepOnLeft(step);
            sr.flipX = true;
            
        } 
    }



    private void StepOnRight(float speed)
    {
        rb.velocity = ( new Vector2(speed, 0));
    }
    private void StepOnLeft(float speed)
    {
        rb.velocity = (new Vector2(-speed, 0));
    }



    public void EnemyHere(float posEnemy)
    {
        SeeEnemy = true;
        posEnemyX = posEnemy;
    }
    public void EnemyLost()
    {
        SeeEnemy = false;
    }
    
    public void ChangeAnimation(string NewAnimation)
    {
        if (CurrentAnimation != NewAnimation)
        {

            animator.Play(NewAnimation);
            CurrentAnimation = NewAnimation;
            
        }
    }
}
