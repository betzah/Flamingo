using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {

			GetComponent<Animation>().Play();

			SceneManager.LoadScene (1);
		}
	}



}      
