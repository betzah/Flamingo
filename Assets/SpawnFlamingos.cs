using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFlamingos : MonoBehaviour {

    List<GameObject> listOfFlamingos = new List<GameObject>();

    public int numberOfEnemies;
    public float depth;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfEnemies; i++)
        {
                GameObject clone = Instantiate(Resources.Load("Flamingo"), new Vector3(i * 2, 0, (i % 2) * depth), Quaternion.identity) as GameObject;
            listOfFlamingos.Add(clone);
        }

        Destroy(listOfFlamingos[numberOfEnemies / 2].GetComponent<Dummy>());
        listOfFlamingos[numberOfEnemies / 2].AddComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
