using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float magicNumber;
    public Camera cameras;
    private void Start()
    {
        magicNumber = cameras.orthographicSize - 5;
    }
    private void Update()
    {
        if (player.position.y < magicNumber - 1f)
        {
            transform.position = new Vector3(player.position.x, magicNumber, transform.position.z);

        }
        else transform.position = new Vector3(player.position.x, player.position.y + 1f, transform.position.z) ;
        
    }
}
