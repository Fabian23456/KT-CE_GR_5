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
