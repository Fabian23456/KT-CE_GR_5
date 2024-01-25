using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player_Score : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    
    // Update is called once per frame
    void Update()
    {
      timeLeft -= Time.deltaTime;
      
      timeLeftUI.GetComponent<TextMeshProUGUI>().text = "Time Left: " + timeLeft.ToString("F2");
      playerScoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + playerScore;
      
      if (timeLeft < 0.1f){
        SceneManager.LoadScene ("SampleScene");
      }  
    }

    void OnTriggerEnter2D (Collider2D trig){
      if (trig.gameObject.tag == "end"){
        CountScore();
        //Hier neues Level laden und timeleft ändern.
        SceneManager.LoadScene ("SampleScene");
      }
      if (trig.gameObject.tag == "coin"){
        playerScore += 10;
        Destroy(trig.gameObject);
      }
      if (trig.gameObject.tag == "pfannenwender"){
        playerScore += 50;
        Destroy(trig.gameObject);
      }
    }


    void CountScore (){
      Debug.Log(DataManagement.datamanagement.score);
      playerScore = playerScore + (int)(timeLeft * 10);
      DataManagement.datamanagement.score = playerScore;
      DataManagement.datamanagement.SaveData();
      Debug.Log(DataManagement.datamanagement.score);
    }
}
