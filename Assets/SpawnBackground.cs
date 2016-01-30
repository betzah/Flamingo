using UnityEngine;
using System.Collections;

public class SpawnBackground : MonoBehaviour {

	public float backgroundSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            float randomNum = Random.Range(0f, 1f);
            int randomObj = Random.Range(0, 2);
            if (randomNum > 0.5f)
            {
              GameObject clone = Instantiate(Resources.Load("BackGround/" + randomObj), this.gameObject.transform.GetChild(i).transform.position, new Quaternion(0,Random.Range(0,180),0,0)) as GameObject;
                clone.transform.SetParent(this.transform);
            }
            else
            {
               
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3(backgroundSpeed, 0, 0) * Time.deltaTime;
        if(this.transform.position.x <= -29)
        {
			Instantiate(Resources.Load("Ground"), new Vector3(31, -0.5f, 3), Quaternion.identity);
            Destroy(this.gameObject);
        }
	}

}
