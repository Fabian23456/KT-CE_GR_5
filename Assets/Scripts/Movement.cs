using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10000000;
    public bool facingRight = true;
    public float moveX;

    private Rigidbody2D rb;
    public bool isGrounded;

    public GameObject coinPrefab;
    public GameObject pfannwenderPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        PlayerMove();
        PlayerRaycast();
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
        
    }

    void PlayerRaycast (){
        
        RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
        //Breakable Blox
        if (rayUp != null && rayUp.collider != null && rayUp.distance < 1f && rayUp.collider.tag == "bubble"){
            
            // Speichere die Position des zu zerstoerenden GameObjects
             Vector3 destroyedObjectPosition = rayUp.collider.gameObject.transform.position;
            // Zerstoere das GameObject
            Destroy(rayUp.collider.gameObject);
            float randomValue = Random.Range(0f, 1f);
            // Erzeuge ein neues Coin-GameObject mit 50% Wahrscheinlichkeit
            if (randomValue <= 0.5f && coinPrefab != null)
            {
                Instantiate(coinPrefab, destroyedObjectPosition, Quaternion.identity);
            }
            if (randomValue > 0.5f && pfannwenderPrefab != null)
            {
                Instantiate(pfannwenderPrefab, destroyedObjectPosition, Quaternion.identity);
            }
        }
        
        //Enemy kill
        RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 1f && rayDown.collider.tag == "qualle")
        {   
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyQualle>().enabled = false;
        }
        if (rayDown.collider != null && rayDown.distance < 1f && rayDown.collider.tag != "qualle")
        {
             isGrounded = true;
        }
    }
} 


    
