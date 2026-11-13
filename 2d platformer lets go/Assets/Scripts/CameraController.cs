using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] Vector3 offset;
    void Start()
    {
        playerTransform = FindAnyObjectByType<PlayerController>().transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
