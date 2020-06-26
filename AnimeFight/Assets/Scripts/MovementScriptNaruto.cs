using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class MovementScriptNaruto : MonoBehaviour {

    public float speed = 5;
    private bool facingRight = true;
    public float jumpForce;
    
    private bool isGrounded;
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

        
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            GetComponent<Animator>().SetBool("IsFalling", false);
            GetComponent<Animator>().SetBool("IsRunningNaruto", false);
            GetComponent<Animator>().SetBool("IsJumping", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }

        else if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            extraJumps--;
            GetComponent<Animator>().SetBool("IsFalling", false);
            GetComponent<Animator>().SetBool("IsRunningNaruto", false);
            GetComponent<Animator>().SetBool("IsJumping", true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if(rb2d.velocity.y < 0)
        {
            GetComponent<Animator>().SetBool("IsFalling", true);
            GetComponent<Animator>().SetBool("IsJumping", false);
        }

        xInput = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkradius, whatIsGround);
        if (isGrounded)
        {
            GetComponent<Animator>().SetBool("IsRunningNaruto", xInput != 0);
            GetComponent<Animator>().SetBool("IsJumping", false);
            GetComponent<Animator>().SetBool("IsFalling", false);
        }

        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);


        if (facingRight==false && xInput > 0)
        {
            Flip();
        }
        else if (facingRight ==true && xInput < 0)
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

