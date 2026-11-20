using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D enemyRb;
    [SerializeField] float enemyMoveSpeed;

    void Start()
    {
        //ta in rigidbody för att använda
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemyRb.linearVelocityX = transform.right.x * enemyMoveSpeed;
    }
}
