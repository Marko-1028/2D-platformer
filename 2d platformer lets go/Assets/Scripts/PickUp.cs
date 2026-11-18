using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject PickUpEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(PickUpEffect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
