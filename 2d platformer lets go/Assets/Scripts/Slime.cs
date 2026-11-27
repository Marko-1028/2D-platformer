using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D enemyRb;
    [SerializeField] float enemyMoveSpeed;
    [SerializeField] Transform ledgeCheckTransform;
    [SerializeField] bool ledgeCheck;
    [SerializeField] LayerMask groundLayer;
    void Start()
    {
        //ta in rigidbody för att använda
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemyRb.linearVelocityX = transform.right.x * enemyMoveSpeed;

        ledgeCheck = Physics2D.OverlapCircle(ledgeCheckTransform.position, 0.2f, groundLayer);

        if (ledgeCheck == false)
        {
            transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }
}
