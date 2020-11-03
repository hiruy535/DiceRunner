using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour
{
	public float slowfactor = 0.05f;
	public float slowlenght = 5f;
	bool is_offGround = false;
	bool is_start = true;


	// Update is called once per frame
	void Update()
	{
		Time.timeScale += (1f/slowlenght) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
		//GetComponent<player>().rb.AddForce(0, 0, 1200 * Time.deltaTime);

	}

	public void slowDown()
	{
		Time.timeScale = slowfactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}
}
