using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float maxSpeed = 8;
    public float jumpForce;
    public bool onGround;
    public LayerMask whatIsGround;

    private Rigidbody2D myRidgidBody;
    private Collider2D myCollider;
    private WinLevel winLevel;
    private Immobilise immobilise;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        myRidgidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        winLevel = FindObjectOfType<WinLevel>();
        immobilise = FindObjectOfType<Immobilise>();
    }
	
	// Update is called once per frame
	void Update () {
        // collider on player? if yes then grounded = true
        onGround = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRidgidBody.velocity = new Vector2(moveSpeed,myRidgidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (onGround)
            {
                myRidgidBody.velocity = new Vector2(myRidgidBody.velocity.x, jumpForce);
            }
        }

        myAnimator.SetFloat("Speed", myRidgidBody.velocity.x);
        myAnimator.SetBool("WonLevel", winLevel.wonLevel);
        myAnimator.SetBool("Immobilised", immobilise.immobilised);

    }
}
