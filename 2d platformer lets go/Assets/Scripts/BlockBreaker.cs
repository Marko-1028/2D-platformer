using UnityEngine;

public class BlockBreaker : MonoBehaviour
{
    [SerializeField] GameObject blockBreakerParticleEffect;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject powerup;
    [SerializeField] bool coinBlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<Rigidbody2D>().linearVelocityY > -0.1f)
            {
                if (coinBlock)
                {
                    Instantiate(coin, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                }

                Instantiate(blockBreakerParticleEffect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
                Destroy(gameObject);
                if(Random.Range(1, 6) == 1)
                {
                    Instantiate(powerup, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                }
            }
        }
    }
}
