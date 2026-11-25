using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject emptyBlock;
    [SerializeField] bool coinBlock;
    [SerializeField] bool coinBlockActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<Rigidbody2D>().linearVelocityY > -0.1f)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
                Instantiate(coin, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(emptyBlock, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        
    }
}
