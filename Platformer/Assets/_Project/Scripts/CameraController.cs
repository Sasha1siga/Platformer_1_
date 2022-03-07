using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Camera cameras;


    private float yDistanceCorrector; // чтобы при изменении размера камеры не было проблем с захватом земли в игре 
    private void Start()
    {
        yDistanceCorrector = cameras.orthographicSize - 5;
    }
    private void Update()
    {
        if (playerTransform.position.y < yDistanceCorrector - 1f)
        {
            transform.position = new Vector3(playerTransform.position.x, yDistanceCorrector, transform.position.z);

        }
        else transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, transform.position.z) ;
        
    }
}
