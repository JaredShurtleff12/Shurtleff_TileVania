using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float flRunSpeed = 10f;
    [SerializeField] float fljumpSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void OnJump(InputValue value)
    {
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        if(value.isPressed){
            myRigidbody.velocity += new Vector2(0f, fljumpSpeed);
        }
    }
    void Run(){
        Vector2 playerVelocity = 
                        new Vector2(moveInput.x * flRunSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        
        bool blplayerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", blplayerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool blplayerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (blplayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);

        }
    }
}
