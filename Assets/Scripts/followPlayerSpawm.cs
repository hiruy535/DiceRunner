using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerSpawm : MonoBehaviour
{

    public Transform player;
	  public Vector3	 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.position = player.position + offset ;
      transform.LookAt(player);
    }

    void OnTriggerEnter(Collider tagName){
        Destroy(tagName.gameObject);
        //transform.localScale += Vector3(0.1,0,0); #Scale GameObject in Runtime
    }
}
