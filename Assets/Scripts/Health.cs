using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{   
    public int health;
    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10){
           Die ();
        }
    }

    void Die () {
        GameManager.Instance.ResetLevel();
    }
}
