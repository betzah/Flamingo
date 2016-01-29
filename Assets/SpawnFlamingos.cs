using UnityEngine;
using System.Collections;

public class SpawnFlamingos : MonoBehaviour {

    public int numberOfEnemies; 

	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            if ( i % 2 == 0)
            {
                Instantiate(Resources.Load("Flamingo"), new Vector3(i * 2, 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(Resources.Load("Flamingo"), new Vector3(i * 2, 0, 1), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
