using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{


	public float slowfactor= 0.05f;
	public float slowlenght= 3f;

	public Transform player;
	public Vector3	 offset;
	public Vector3	 offRotation;
	public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

	void Update(){
		Time.timeScale += (1f/slowlenght) * Time.unscaledDeltaTime;
	}

	void slowDown(){
			Time.timeScale = slowfactor;
			Time.fixedDeltaTime = Time.timeScale * 0.2f;
	}

    void FixedUpdate()
    {
        
		//Vector3 SmoothPositon = Vector3.Lerp(transform.position, (player.position + offset), smoothSpeed );

		//transform.position = SmoothPositon ;

		transform.position = player.position + offset ;

		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

		transform.Rotate(24.557f * Time.deltaTime, 24.7f, 23.77f);

		transform.LookAt(player);
    }
}
