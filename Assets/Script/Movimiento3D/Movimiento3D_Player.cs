using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento3D_Player : MonoBehaviour
{
    public float gravity = 9;
    public Transform checkGround;
    public LayerMask ground;
    public float speedPlayer = 5;
    public float jumpForce = 10;
    public bool jumping;
    public float timerJumping = 5;
    private float actualJumping;
    public float fallMultiplier = 4;
    public float deacceleration = 5;
    public float actualDeacceleration;
    
    [SerializeField] Vector3 sizeBoxCast = new Vector3(.5f, .5f, .5f);
    private void Start()
    {
        actualJumping = timerJumping;
    }
    private void Update()
    {
        if (!IsGround())
        {
            transform.Translate(Vector3.down * gravity * Time.deltaTime);
        }    
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * x * speedPlayer * Time.deltaTime);
        transform.Translate(Vector3.forward * y * speedPlayer * Time.deltaTime);
        if(Input.GetButton("Jump"))
        {
            Jump();
        }
        if(Input.GetButtonUp("Jump"))
        {
            AbortJump();
        }
        if(actualJumping < timerJumping)
        {
            actualJumping += 1 * Time.deltaTime;
            jumping = true;           
        }
        if (actualJumping >= timerJumping)
        {
            jumping = false;
            AbortJump();
        }
        if(jumping)
        {
            gravity = 0;
            actualDeacceleration = Mathf.MoveTowards(actualDeacceleration, 0, .2f);
            transform.Translate(Vector3.up * (jumpForce * Time.deltaTime) / deacceleration);
        }
        if(gravity < 9 && !jumping)
        {
            gravity = Mathf.MoveTowards(gravity, 9, Time.deltaTime * fallMultiplier);
        }
    }
    private void Jump()
    {
        if(IsGround())
        {
            actualDeacceleration = deacceleration;
            actualJumping = 0;
        }
    }
    private void AbortJump()
    {
        actualJumping = timerJumping;
        actualDeacceleration = 0;
    }
    bool IsGround()
    {
        Ray ray = new Ray(checkGround.position, Vector3.down);
        return Physics.Raycast(ray, 1,ground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(checkGround.position, sizeBoxCast);
    }
}
