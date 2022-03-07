using UnityEngine;

public class DetectorSkeleton : MonoBehaviour
{
    [SerializeField] Skeleton skeletonSkript;
    [SerializeField] SpriteRenderer spriteRendererrigidSkeleton;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
            skeletonSkript.PlayerHere(collision.transform.position.x);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
        {
            skeletonSkript.PlayerLost();
            spriteRendererrigidSkeleton.sortingOrder = 3;

        }
    }

}