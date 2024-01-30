using System.Collections;
using UnityEngine;

public class Annanas : MonoBehaviour
{
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;
    public bool lastLevel = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!lastLevel)
            {
                GameManager.Instance.LoadLevel(nextWorld, nextStage);
            }
            else
            {
                if(GameManager.Instance.score > GameManager.Instance.highScore) {
                    GameManager.Instance.highScore = GameManager.Instance.score;
                }
                GameManager.Instance.NewGame();
            }

            
        }
    }

}