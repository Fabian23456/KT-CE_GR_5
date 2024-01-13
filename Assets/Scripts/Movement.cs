using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10000000;
    public bool facingRight = true;
    public float moveX;

    private Rigidbody2D rb;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        PlayerMove();
    }
    
    void PlayerMove(){
        // Move
        moveX = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(moveX, 0);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded ==true){
            PlayerJump();
        }

        //Direction
        if (moveX < 0.0f && facingRight == false){
            FLipPlayer();
        }else if (moveX > 0.0f && facingRight == true){
            FLipPlayer();
        }
        
    }

    void FLipPlayer(){
        facingRight =! facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void PlayerJump(){
        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D (Collision2D col){
        if (col.gameObject.tag == "ground"){
            isGrounded = true;
        }
    }
} 


    
