using UnityEngine;
using System.Collections;

public class SpawnBackground : MonoBehaviour {

	float backgroundSpeed = 2.0f;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            float randomNum = Random.Range(0f, 1f);
            int randomObj = Random.Range(1, 7);
            if (randomNum > 0.5f)
            {
              GameObject clone = Instantiate(Resources.Load("BackGround/" + randomObj), this.gameObject.transform.GetChild(i).transform.position, Quaternion.Euler(0,-90,0)) as GameObject;
                clone.transform.SetParent(this.transform);
            }
            else
            {
                continue;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3(backgroundSpeed, 0, 0) * Time.deltaTime;
        if(this.transform.position.x <= -29)
        {
			Instantiate(Resources.Load("Ground"), new Vector3(61, -0.01f, 3), Quaternion.identity);
            Destroy(this.gameObject);
        }
	}

}
