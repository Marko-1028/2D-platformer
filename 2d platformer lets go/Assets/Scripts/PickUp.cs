using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsTextDisplay;
    [SerializeField] int coinsValue = 0;
    [SerializeField] GameObject PickUpEffect;


    void Update()
    {
        coinsTextDisplay.text = coinsValue.ToString();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(PickUpEffect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            coinsValue += 1;
            Destroy(gameObject);
        }
    }
}
