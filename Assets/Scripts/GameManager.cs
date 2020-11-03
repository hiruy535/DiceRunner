using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	bool isgameover = false;
	public float restartTime = 0.06f;
	public static GameManager Instance;
	public Text scoreBoardText,finalScoreBoardText, HighScoreText;
	public GameObject scoreBoard, finalScoreBoard,Player;
	public bool isGameRunning;
	public void Awake()
	{
		Instance = this;
		scoreBoard = scoreBoard;
		//GameObject.Find("ScoreBoard");
		finalScoreBoard = finalScoreBoard;
		scoreBoardText = scoreBoardText;
		finalScoreBoardText = finalScoreBoardText;
		HighScoreText = HighScoreText;
		Player = Player;
		isGameRunning = true;
	}


public void GameOver(){

		if(isgameover == false){
			isgameover = true;
			//
			Restart();
		}

	}

	void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
