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
                if (coinBlockActive)
                {
                    
                    Instantiate(coin, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                    coinBlockActive = false;
                    
                }



                Instantiate(emptyBlock, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        
    }
}
