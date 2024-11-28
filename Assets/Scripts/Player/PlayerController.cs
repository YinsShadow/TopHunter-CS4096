//---------------------- NOT THE AUTO GENERATED FILE FORM UNITY -------------------------//
//----------------------           This one is mine!            -------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
//---Imports---
//Controls/physics
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer myTrailRenderer;

    public static PlayerController Instance;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

//Graphics
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
//Player Controls

    private bool facingLeft = false;
    private bool isDashing = false;

//---Work being done!---
    private void Awake() { //Go!
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        playerControls.Combat.Dash.performed += _ => Dash();
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

    private void Dash() { // Is as described!
        if (!isDashing) {
            isDashing = true;
            moveSpeed *= dashSpeed;
            myTrailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    private IEnumerator EndDashRoutine() { // Stop doing the thing!
        float dashTime = .2f;
        float dashCD = .25f;
        yield return new WaitForSeconds(dashTime);
        myTrailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    } 
}
