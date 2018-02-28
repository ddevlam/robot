using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    bool facingRight = true;

    public float topSpeed = 10f;
    public float jumpForce = 700f;
    public bool disabled = false;

    bool grounded = false;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private float groundRadius = 0.2f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (disabled)
        {
            return;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        animator.SetBool("grounded", grounded);

        float move = Input.GetAxis("Horizontal");


        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        animator.SetFloat("speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (!disabled && grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("grounded", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    public void Win()
    {
        animator.SetBool("win", true);
        disabled = true;
    }

    public void Lose()
    {
        animator.SetBool("dead", true);
        disabled = true;
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
