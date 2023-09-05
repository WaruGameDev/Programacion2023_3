using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    public List<Transform> groundChecks;
    public float groundRadiusDetect = .2f;
    public Rigidbody2D rb;
    public bool isGround;
    public float speedPlayer = 10, jumpPlayer=10;
    public LayerMask ground;
    public float lowMultiplierJump = 2, fallMultiplierJump = 2.5f;

    private void Update()
    {
        isGround = IsGrounded(groundChecks[0]) || IsGrounded(groundChecks[1]) ||
            IsGrounded(groundChecks[2]);
        
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speedPlayer, rb.velocity.y);
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierJump - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplierJump - 1) * Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump") && isGround)
        {
            rb.velocity = Vector2.zero;
            rb.velocity += Vector2.up * jumpPlayer;
        }
    }
    private bool IsGrounded(Transform check)
    {
        return Physics2D.OverlapCircle(check.position, groundRadiusDetect, ground);
    }
    private void OnDrawGizmos()
    {
        foreach(Transform g in groundChecks)
        {
            Gizmos.DrawWireSphere(g.position, groundRadiusDetect);
        }
    }
}
