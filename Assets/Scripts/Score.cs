using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float time = 0;
    public int score = 3000;
    
   
   
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //timeUI.gameObject.GetComponent<Text>().text = ("Time:  "+ (int)time);
        //scoreUI.gameObject.GetComponent<Text>().text = ("Score:  "+ score);

        if (time > 300f){
            SceneManager.LoadScene ("SampleScene");
        }
    }

    void OnTriggerEnter2D (Collider2D trigger){
        CountScore();
    }

    void CountScore(){
        score = score - (int)(time*10);
    }
}
