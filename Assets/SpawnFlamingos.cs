using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFlamingos : MonoBehaviour {
	public int playerColumn = 4;
	public int columnTotal = 10;
	public float columnWidth = 1.0f;
	public float laneWidth = 1.0f;

	//public List<GameObject> listOfFlamingos = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < columnTotal; i++)
        {
			GameObject clone = Instantiate(Resources.Load("Flamingo"), new Vector3(i * columnWidth, 0, (i % 2) * laneWidth), Quaternion.identity) as GameObject;
			if (i == playerColumn)
				clone.AddComponent<Player>().setPosition(i, i % 2);
			else
				clone.AddComponent<Dummy>().setPosition(i, i % 2);

            //listOfFlamingos.Add(clone);
        }

		//Destroy(listOfFlamingos[columnTotal / 2].GetComponent<Dummy>());
		//listOfFlamingos[columnTotal / 2 - 1].AddComponent<Player>().goPosition(columnTotal / 2 - 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
