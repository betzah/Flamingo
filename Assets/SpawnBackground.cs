using UnityEngine;
using System.Collections;

public class SpawnBackground : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            float randomNum = Random.Range(0f, 1f);
            int randomObj = Random.Range(0, 2);
            if (randomNum > 0.5f)
            {
                Instantiate(Resources.Load("BackGround/" + randomObj), this.gameObject.transform.GetChild(i).transform.position, new Quaternion(0,Random.Range(0,180),0,0));
            }
            else
            {
               
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(1, 0, 0) * Time.deltaTime;
	}

}
