using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float slowfactor= 0.5f;
	public float slowlenght= 5f;
	bool is_offGround = false;
	bool is_start = true;
	
	public	Rigidbody	rb;
	private	bool		moveLeft = false;
	private	bool		moveRight= false;
	public	float		LeftandRihtSpeed;
	public	float		ForwardSpeed;
	public GameObject ground;
	public GameObject scoreBr;
	int scoreUpdater = 0;
	public int score=0;
	public slowMotion timeManager;


	// Start is called before the first frame update
	void Start()
    {
		rb.AddForce(0, 0, ForwardSpeed * Time.deltaTime);
		GameManager.Instance.scoreBoard.SetActive(true);
		//Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update()
    {

		if( (int.Parse(scoreBr.GetComponent<scoreUpdate>().scoreBoared.text) - scoreUpdater) == 90)
        {
			scoreUpdater = int.Parse(scoreBr.GetComponent<scoreUpdate>().scoreBoared.text);
			ForwardSpeed *= 1.25f;

		}
		


		if ((rb.position.z - ground.transform.position.z < 50f))
        {
			ground.transform.localScale += new Vector3(0f, 0f, 50f); 
        }

        rb.AddForce(0,0,ForwardSpeed * Time.deltaTime);

		if(Input.GetKey("d")){
		is_start = false ;
			moveRight = true;
			if(rb.position.x < 15.4){	
				rb.AddForce(LeftandRihtSpeed * Time.deltaTime,0,0, ForceMode.VelocityChange);
				
			}
			//moveLeftRight();
		}

		if(Input.GetKey("a")){
			moveLeft = true;
			is_start = false ;
			if(rb.position.x > -15.4){
				rb.AddForce(-LeftandRihtSpeed * Time.deltaTime,0,0 ,ForceMode.VelocityChange);
				
			}
			
			//moveLeftRight();
		}

		if ( rb.position.y < 0f){
			gameObject.GetComponent<collision>().scoreBoard();
		}

	/*	if(rb.position.y > 2f){
			if (is_offGround == false){
				slowMotion slow =GetComponent<slowMotion>();
				slow.slowDown();
				rb.AddForce(0, 0, ForwardSpeed * Time.deltaTime);
			}
			is_offGround = true;
			//rb.AddForce(0,0,ForwardSpeed * Time.deltaTime);
			//Time.timeScale += (1f/slowlenght) * Time.unscaledDeltaTime;
			//Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
		}
	*/

		if ( rb.velocity.magnitude < 0.01 )
			  {
					//Debug.Log("unity answers saves the day!");
				if(is_start == false){
					//rb.AddForce(0,0,ForwardSpeed * Time.deltaTime);
					//rb.velocity = new Vector3(0f,0f,10f);
				}
				
			  }

		
    }

	void moveLeftRight(){
		if(moveRight == true){
			rb.AddForce(LeftandRihtSpeed * Time.deltaTime,0,0 );
		}

		if(moveLeft == true){
			rb.AddForce(-LeftandRihtSpeed * Time.deltaTime,0,0);
		}
	}

	void OnTriggerEnter(Collider col) {

		if(col.tag == "PowerUp")
        {
			Destroy(col.gameObject);
			//slowMotion slow = GetComponent<slowMotion>();
			timeManager.slowDown();
			//rb.velocity = new Vector3(0, 0, 100f);

		}
		
	}

	
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float slowfactor= 0.05f;
	public float slowlenght= 5f;
	bool is_offGround = false;
	bool is_start = true;
	
	public	Rigidbody	rb;
	private	bool		moveLeft = false;
	private	bool		moveRight= false;
	public	float		LeftandRihtSpeed;
	public	float		ForwardSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


			Time.timeScale += (1f/slowlenght) * Time.unscaledDeltaTime;
			Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);


        rb.AddForce(0,0,ForwardSpeed * Time.deltaTime);
		if(Input.GetKey("d") && rb.position.x < 29.4){
		is_start = false ;
			moveRight = true;
			if(rb.position.x < 15.4){	
				rb.AddForce(LeftandRihtSpeed * Time.deltaTime,0,0, ForceMode.VelocityChange);
				Debug.Log(rb.position.x);
			}
			//moveLeftRight();
		}

		if(Input.GetKey("a")){
			moveLeft = true;
			is_start = false ;
			if(rb.position.x > -15.4){
				rb.AddForce(-LeftandRihtSpeed * Time.deltaTime,0,0 ,ForceMode.VelocityChange);
				Debug.Log(rb.position.x);
			}
			
			//moveLeftRight();
		}

		if(rb.position.y < -1f){
			FindObjectOfType<GameManager>().GameOver();
		}

		if(rb.position.y > 2f){
			if (is_offGround == false){
				slowDown();
			}
			is_offGround = true;
			rb.AddForce(0,0,ForwardSpeed * Time.deltaTime);
			//Time.timeScale += (1f/slowlenght) * Time.unscaledDeltaTime;
			//Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
		}


		if ( rb.velocity.magnitude < 0.01 )
			  {
				Debug.Log("unity answers saves the day!");
				if(is_start == false){
					rb.AddForce(0,0,ForwardSpeed * Time.deltaTime);
					//rb.velocity = new Vector3(0f,0f,10f);
				}
				
			  }

		
    }

	void moveLeftRight(){
		if(moveRight == true){
			rb.AddForce(LeftandRihtSpeed * Time.deltaTime,0,0 );
		}

		if(moveLeft == true){
			rb.AddForce(-LeftandRihtSpeed * Time.deltaTime,0,0);
		}
	}

	void slowDown(){
			Time.timeScale = slowfactor;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
*/