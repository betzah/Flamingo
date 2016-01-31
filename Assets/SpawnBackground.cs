using UnityEngine;
using System.Collections;

public class SpawnBackground : MonoBehaviour {

	float backgroundSpeed = 1.0f;
    public GameObject planeHolder;
    // Use this for initialization
    void Start()
    {
        planeHolder = GameObject.FindGameObjectWithTag("holder");
        for (int i = 0; i < 9; i++)
        {
            float randomNum = Random.Range(0f, 1f);
            int randomObj = Random.Range(1, 7);
            if (randomNum > 0.2f)
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
        if(this.transform.position.x <= -10)
        {
			GameObject clone = Instantiate(Resources.Load("WaterPlane"), new Vector3(40, -0.01f, 3), Quaternion.identity) as GameObject;
            clone.transform.parent = planeHolder.transform;
            Destroy(this.gameObject);
            Debug.Log("destroy myself");
        }
	}

}
