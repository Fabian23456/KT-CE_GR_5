using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQualle : MonoBehaviour
{
    public float speed;
    public float XMoveDirection;
    
    // Update is called once per frame
    void Update()
    {   
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (XMoveDirection, 0) * speed;
        if ( hit.distance < 0.4f){
            Flip();
            if (hit.collider.tag == "Player"){
                Rigidbody2D playerRigidbody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null) {
                    playerRigidbody.AddForce(Vector2.left * 200);
                    playerRigidbody.gravityScale = 1;
                    playerRigidbody.freezeRotation = false;
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    float rotationSpeed = 100000f;
                    hit.collider.gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                }
            }
        }

        if (gameObject.transform.position.y < -20) {
            Destroy (gameObject);
        }
        
    }

    void Flip (){
        if (XMoveDirection > 0f){
            XMoveDirection = -1f;
        }else{
            XMoveDirection = 1f; 
        }
    }
}
