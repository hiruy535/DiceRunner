using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerSpawmMaker : MonoBehaviour
{
    public Transform player;
    public Vector3	 offset;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z) + offset;
      transform.LookAt(player);
    }
}
