using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraMoveSpeed;

    PlayerController playerController;
   [SerializeField] Vector3 wantedPosition;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        wantedPosition.x = playerTransform.position.x;


        if(playerController.isGrounded == true)
        {
            Debug.Log("The player is on the ground, i know it");
            wantedPosition.y = playerTransform.position.y;
        }

        //transform.position = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, wantedPosition + offset, cameraMoveSpeed);

    }

    
    
}
