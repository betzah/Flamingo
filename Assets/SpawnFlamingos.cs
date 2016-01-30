using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFlamingos : MonoBehaviour {

	public int columnTotal = 10;
	public float columnWidth = 1.0f;
	public float laneWidth = 1.0f;

	public List<GameObject> listOfFlamingos = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < columnTotal; i++)
        {
			GameObject clone = Instantiate(Resources.Load("Flamingo"), new Vector3(i * 2, 0, (i % 2) * laneWidth), Quaternion.identity) as GameObject;
            listOfFlamingos.Add(clone);
        }

		Destroy(listOfFlamingos[columnTotal / 2].GetComponent<Dummy>());
		listOfFlamingos[columnTotal / 2].AddComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
