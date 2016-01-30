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
			StartCoroutine (Animation ());
			;
		}
	}

	IEnumerator Animation() {
		GetComponent<Animation>().Play();
		yield return new WaitForSeconds(GetComponent<Animation>().clip.length);
		SceneManager.LoadScene (1);
}      
}