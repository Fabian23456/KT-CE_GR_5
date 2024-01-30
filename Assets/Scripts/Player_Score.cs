using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player_Score : MonoBehaviour
{
    private float timeLeft = 40;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject livesUI;
    public GameObject highScoreUI;


    // Update is called once per frame
    void Update()
    {
      timeLeft -= Time.deltaTime;

      timeLeftUI.GetComponent<TextMeshProUGUI>().text = "Time Left: " + timeLeft.ToString("F2");
      playerScoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + GameManager.Instance.score;
      livesUI.GetComponent<TextMeshProUGUI>().text = "Lives: " + GameManager.Instance.lives;
      highScoreUI.GetComponent<TextMeshProUGUI>().text = "current Highscore: " + GameManager.Instance.highScore;

        if (timeLeft < 0.1){
        GameManager.Instance.ResetLevel();
      }  
    }

    void OnTriggerEnter2D (Collider2D trig){
      if (trig.gameObject.tag == "end"){
        //Hier neues Level laden und timeleft ändern.
        GameManager.Instance.NextLevel();
            CountScore();
            ResetTimeLeft();
       
      }
      if (trig.gameObject.tag == "coin"){
            GameManager.Instance.score += 10;
        Destroy(trig.gameObject);
      }
      if (trig.gameObject.tag == "pfannenwender"){
        GameManager.Instance.score += 50;
        Destroy(trig.gameObject);
      }
    }


    void CountScore (){
      Debug.Log(DataManagement.datamanagement.score);
      GameManager.Instance.score = GameManager.Instance.score + (int)(timeLeft * 10);
      GameManager.Instance.score= GameManager.Instance.score;
      DataManagement.datamanagement.score = GameManager.Instance.score;
      DataManagement.datamanagement.SaveData();
      Debug.Log(DataManagement.datamanagement.score);
    }
    void ResetTimeLeft()
    {
        timeLeft = 40;
    }
}
