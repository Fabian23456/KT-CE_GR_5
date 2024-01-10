using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void LateUpdate()
    {
      /*  Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition; */

        float x = Mathf.Clamp (player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp (player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
    }
}
