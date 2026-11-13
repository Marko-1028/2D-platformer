using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPosition;

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
        playerRb.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerRb.linearVelocity.y);
        CheckForGround();
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
}