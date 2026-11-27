using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D enemyRb;
    [SerializeField] GameObject slimeDestroyedEffect;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.GetComponent<Rigidbody2D>().linearVelocityY < -0.1f)
            {
                Instantiate(slimeDestroyedEffect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
                Destroy(gameObject);
            }
        }
    }
}
