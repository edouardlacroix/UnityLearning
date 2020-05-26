using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovements : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    public bool isGrounded;
    private float horizontalMovement;

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float groundCheckRadius;
    public LayerMask collisionLayer;
    public CapsuleCollider2D capsuleCollider;

    public Transform groundCheck1;
    public Transform groundCheck2;






    private void Update()
    {

        if (Input.GetKeyDown("up") && isGrounded == true)
        {
            isJumping = true;
            // animator.SetBool("IsJumping", true);    

        }
        if (Input.GetKeyDown("down") && isGrounded == true)
        {

            StartCoroutine(DisableCollider());
        }

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Flip(rb.velocity.x);

        // Send speed to animator to change movement animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


    }

    private IEnumerator DisableCollider()
    {
        capsuleCollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        capsuleCollider.enabled = true;
    }


    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        // Check if one of the foot is on the floor
        isGrounded = Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, collisionLayer) || Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, collisionLayer);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;

        }
    }


    // Flip sprite if movement is negative
    void Flip(float _velocity)
    {

        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;

        }
    }

    //Draw visual help to see the object in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck1.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheck2.position, groundCheckRadius);
    }
}
