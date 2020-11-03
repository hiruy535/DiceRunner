using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCreator : MonoBehaviour
{
    public GameObject[] obscales;
    public GameObject ground;
    public Vector3 spawnValue;
    public Vector3	 offset;
    public float spawnTime,colorTime;
    private IEnumerator coroutine;
    float yposition = 0f;
    bool is_objectCollied = false , objCheck = false;
    float xPositoinValue, randomRotationX, randomRotationY, randomRotationZ;
    float XPosition=0f, YPosition=0f, ZPosition=0f;
    int randomPosition;
    public Material[] materials;
    GameObject objs;

    // Start is called before the first frame update
    void Start()
    {
        //waitSpaner();
        //coroutine = WaitAndPrint(2.0f);
        StartCoroutine(ObstacleWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void waitSpaner(){
      int randobc = Random.Range(0,4);
      randomPosition = Random.Range(0, 3);
      if (obscales[randobc].name == "cube001" || obscales[randobc].name == "cube002" || obscales[randobc].name == "UpDomino")
        {
            xPositoinValue = 1.5f;
            objCheck = true;
            randomRotationX = 0f;
            randomRotationY = 0f;
            randomRotationZ = 0f;
        }
        else if(obscales[randobc].name == "SideDomino")
        {
            xPositoinValue = 3f;
            
        }
        else
        {
            xPositoinValue = 1.5f;
        }

            if (obscales[randobc].name == "RealDomino")
        {
            if (randomPosition == 0)
            {
                randomRotationX = 90f;
                randomRotationY = 0f;
                randomRotationZ = 90f;
            }
            else if (randomPosition == 1)
            {
                randomRotationX = 0f;
                randomRotationY = 0f;
                randomRotationZ = 90f;
            }
            else if (randomPosition == 2)
            {
                randomRotationX = 0f;
                randomRotationY = 90f;
                randomRotationZ = 0f;
            }

            //Debug.Log(randomPosition + "--> ");
        }
            //Debug.Log(obscales[randobc].name + " -> " + xPositoinValue);
        Vector3 swapPosition = new Vector3(Random.Range(-spawnValue.x + xPositoinValue, spawnValue.x - xPositoinValue),1, yposition);
        Debug.Log("SwapPos ---->  " + swapPosition.x +"------> Y"+ swapPosition.y +" -----> Z " + swapPosition.z);
        //VectorE groungPosition = new Vector3(Random.Range(-spawnValue.x + xPositoinValue, spawnValue.x - xPositoinValue));
    if( is_objectCollied == false )
        {
            //if(objCheck == false)
            //{
                objs =    Instantiate(obscales[randobc], swapPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation = Quaternion.Euler(new Vector3(randomRotationX, randomRotationY, randomRotationZ)));
                gameObject.transform.position += offset * Time.deltaTime;
                StartCoroutine(ColorChanger());
            //}
            //else
            //{
            //    Instantiate(obscales[randobc], swapPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation = Quaternion.Euler(new Vector3(randomRotationX, randomRotationY, randomRotationZ)));
            //    transform.position += offset * Time.deltaTime;
            //}


            yposition += 10f;
            
        }
    }

    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            waitSpaner();
        }
        
    }

    IEnumerator ColorChanger()
    {
        while (true)
        {
            int materlialNum = Random.Range(0, 4);
            yield return new WaitForSeconds(colorTime);
            objs.GetComponent<MeshRenderer>().material = materials[materlialNum];
        }

    }

    void OnTriggerEnter(Collider obj)
    {
        is_objectCollied = true;
    }
}
