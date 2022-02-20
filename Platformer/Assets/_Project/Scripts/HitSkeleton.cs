using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSkeleton : MonoBehaviour
{
    public Skeleton skeletonSkript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
        {
            skeletonSkript.ChangeAnimation("Hit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
        {
            skeletonSkript.ChangeAnimation("ForSkelet");
        }
    }
}
