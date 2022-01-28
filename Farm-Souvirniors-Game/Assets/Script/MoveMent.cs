using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveMent : MonoBehaviour
{
    [SerializeField] float walkSpeed = 8f;
    Vector2 moveInput;
    Rigidbody2D myRigidBody2D;
    Animator myAnimator;



    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {   
        run();
        flipMovement();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        // Debug.Log(moveInput.x);
    }

     void run(){
        Vector2 playerVelocity = new Vector2(moveInput.x * walkSpeed,moveInput.y * walkSpeed);
        myRigidBody2D.velocity = playerVelocity;
        
        bool walkSide = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
        bool walkBack = myRigidBody2D.velocity.y > 0;
        bool walkFront = myRigidBody2D.velocity.y < 0;
        myAnimator.SetBool("walkSide" , walkSide);
        myAnimator.SetBool("walkBack" , walkBack);
        myAnimator.SetBool("walkFront" , walkFront);
    }

    void flipMovement(){
        bool walkSide = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidBody2D.velocity.y) > Mathf.Epsilon;
        
        if(walkSide){
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody2D.velocity.x) , 1f);
        }

        
 
    }
}
