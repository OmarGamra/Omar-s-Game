using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class MovementScriptGoku : MonoBehaviour {

    public float speed = 5;
    private bool facingRight = true;
    public float jumpForce;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkradius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;
    private Rigidbody2D rb2d;

    private float xInput;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {

        if (Input.GetButtonDown("Jump2") && isGrounded)
        {
           
            GetComponent<Animator>().SetBool("IsRunning", false);
            GetComponent<Animator>().SetBool("IsJumping", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }

        else if (Input.GetButtonDown("Jump2") && extraJumps > 0)
        {
            extraJumps--;
            GetComponent<Animator>().SetBool("IsRunning", false);
            GetComponent<Animator>().SetBool("IsJumping", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
        xInput = Input.GetAxisRaw("Horizontal2");
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkradius, whatIsGround);
        if (isGrounded)
        {
            GetComponent<Animator>().SetBool("IsJumping", false);

        }
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);
        if (xInput != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else 
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (facingRight==true && xInput > 0)
        {
            Flip();
        }
        else if (facingRight ==false && xInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
