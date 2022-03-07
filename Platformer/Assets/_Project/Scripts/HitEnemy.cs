using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    [SerializeField] Skeleton skeletonSkript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
        {
            skeletonSkript.ChangeAnimation("attack");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
        {
            skeletonSkript.ChangeAnimation("Walk");
        }
    }
    

}
