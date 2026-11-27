using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    public bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] bool isDashing;

    Vector2 moveVector;
    Rigidbody2D playerRb;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump");
            Jump();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if(isDashing == false)
        {
            playerRb.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerRb.linearVelocity.y);
        }
        
        CheckForGround();

        if (moveVector.x > 0)
        {
            //Player is going to the right (input-wise)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (moveVector.x < 0)
        {
            //left
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Jump()
    {
        if (!isGrounded) return;
        playerRb.linearVelocityY = 0;
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckForGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }   else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawWireSphere(groundCheckPosition.position, 0.2f);
    }


    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && isDashing == false)
        {
            Debug.Log("Dash");
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        //spelaren frysa på plats i luften
        isDashing = true;
        playerRb.linearVelocityY = 0;
        playerRb.gravityScale = 0;

        yield return new WaitForSeconds(0.1f);
        //Dasha snabbt framåt
        playerRb.linearVelocityX = transform.right.x * 24;
        //Vänta en kort sekund
        yield return new WaitForSeconds(0.075f);
        //Sätt tillbaks gravityScale och igen nolla min velocityY
        playerRb.linearVelocityY = 0;
        playerRb.gravityScale = 0;
        yield return new WaitForSeconds(0.1f);

        playerRb.gravityScale = 5;
        isDashing = false;

    }
}