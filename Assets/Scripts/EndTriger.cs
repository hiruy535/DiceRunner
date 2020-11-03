using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriger : MonoBehaviour
{
    public GameManager gameManager;
	public GameObject gameObject;

	public void OnTriggerEnter(){
		//gameManager.GameOver();
		gameObject.SetActive(true);

	}

}
