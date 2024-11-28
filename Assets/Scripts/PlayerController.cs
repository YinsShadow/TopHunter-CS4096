using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
//---Imports---
//Controls/physics
    [SerializeField] private float moveSpeed = 1f;
    public static PlayerController Instance;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
//Graphics
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
//Player facing direction
    
    private bool facingLeft = false;

//---Work being done!---
    private void Awake() { //Go!
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() { // Enable input
        playerControls.Enable();
    }

    private void Update() { //Check for player input
        PlayerInput();
    }

    private void FixedUpdate() { //Do the things the player said to do!
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() { //Where they goin?
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() { // Moves the player!
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() { //Change direction based on mouse position! (If needed)
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRender.flipX = true;
            FacingLeft = true;
        } else {
            mySpriteRender.flipX = false;
            FacingLeft = false;
        }
    }
}
