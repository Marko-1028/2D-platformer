using UnityEngine;

public class powerUpMove : MonoBehaviour
{
    [SerializeField] float powerupMoveSpeed;
    Rigidbody2D powerRb;

    void Start()
    {
        powerRb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        powerRb.linearVelocityX = transform.right.x * powerupMoveSpeed;
    }
}
