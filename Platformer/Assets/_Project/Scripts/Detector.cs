using UnityEngine;

public class Detector : MonoBehaviour
{
    public Skeleton skript;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
            skript.EnemyHere(collision.transform.position.x);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LightBandit")
            skript.EnemyLost();
    }

}