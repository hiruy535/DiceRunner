using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooling : MonoBehaviour
{
	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject pref;
		public int size;

	}

	public static objectPooling Instance;

	public void Awake()
	{
		Instance = this;
	}

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;
	public Material[] materials;
	int beforeRandom = 6;
	// Use this for initialization
	void Start()
	{
		poolDictionary = new Dictionary<string, Queue<GameObject>>();
		foreach (Pool pool in pools)
		{
			Queue<GameObject> poolGameojects = new Queue<GameObject>();

			for (int i = 0; i < pool.size; i++)
			{
				GameObject obj = Instantiate(pool.pref);
				obj.SetActive(false);
				int materlialNum = Random.Range(0, 4);
				obj.GetComponent<MeshRenderer>().material = materials[materlialNum];
				poolGameojects.Enqueue(obj);

			}
			poolDictionary.Add(pool.tag, poolGameojects);
		}
	}

	public GameObject spawnGameObjects(string tags, Vector3 position, Quaternion rotation)
	{
		if (!poolDictionary.ContainsKey(tags))
		{

			return null;
		}

		GameObject objs = poolDictionary[tags].Dequeue();
		objs.SetActive(true);
		objs.transform.position = position;
		objs.transform.rotation = rotation;

		/*if(GameManager.Instance.Player.transform.position.z - objs.transform.position.z > 20f)
        {
			poolDictionary[tags].Enqueue(objs);
		}*/
		poolDictionary[tags].Enqueue(objs);

		return objs;
	}
}
