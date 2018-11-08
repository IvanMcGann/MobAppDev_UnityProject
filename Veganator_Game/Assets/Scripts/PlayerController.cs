using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;


    public float jumpTime;
    private float jumpTimeCounter;


    public bool grounded;
    public LayerMask isGrounded;

    private Collider2D myCollider;

    private Animator myAnimator;

    private Rigidbody2D myRigidbody2D;

    
    // Use this for initialization
	void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, isGrounded);

        myRigidbody2D.velocity = new Vector2(moveSpeed, myRigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
            }
        }


        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(jumpTimeCounter > 0)
            {
                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        //allows for multiple jumps
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }


        myAnimator.SetFloat("Speed", myRigidbody2D.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}




}
