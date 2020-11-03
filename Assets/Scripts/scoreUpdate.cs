using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour
{
	
	public Text scoreBoared;
	public Transform player;
    bool checkScoreStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkScoreStop = GameManager.Instance.Player.GetComponent<collision>().stopScore;
        if(checkScoreStop != true)
        {
            scoreBoared.text = (player.position.z / 30).ToString("0");
        }
        
    }
}
