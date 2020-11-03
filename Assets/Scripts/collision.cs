using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
	public player playerScript;
	string score;
	int highscore;
	public bool stopScore = false;
	public int scores;

   void OnCollisionEnter(Collision collision){
   	   if(collision.collider.tag == "obstacle"){
			playerScript.enabled = false;
			stopScore = true;
			Invoke("scoreBoard", 2f);
			
		}
   }

	public void RunAgain()
    {
		FindObjectOfType<GameManager>().GameOver();
	}
	public void scoreBoard()
    {
		GameManager.Instance.isGameRunning = false;
		score = GameManager.Instance.scoreBoardText.text;
		GameManager.Instance.scoreBoard.SetActive(false);
		this.scores = int.Parse(this.score);
		scoreSaveLoad(this.scores);
		GameManager.Instance.finalScoreBoardText.text = this.scores + "";
		GameManager.Instance.HighScoreText.text = highscore + "";
		GameManager.Instance.finalScoreBoard.SetActive(true);

	}

	void scoreSaveLoad(int score)
    {
		PlayerData pld = SaveData.LoadPlayerData();
		if (pld != null)
        {
			if(score < pld.scores)
            {
				//this.scores = pld.scores;
				highscore = pld.scores;
			}
            else
            {
				SaveData.SavePlayerData(this);
				highscore = score;
			}
        }
        else
        {
			SaveData.SavePlayerData(this);
			highscore = score;
		}

	}
}
