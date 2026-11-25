using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraMoveSpeed;

    PlayerController playerController;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {

        if(playerController.isGrounded == true)
        {
            Debug.Log("The player is on the ground, i know it");
        }

        //transform.position = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, cameraMoveSpeed);

    }
}
