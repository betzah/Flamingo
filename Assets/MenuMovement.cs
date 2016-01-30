using UnityEngine;
using System.Collections;

public class MenuMovement : MonoBehaviour {
	public Transform Target1;
	public Transform Target2;
	public string Target;
	public float WalkSpeed;
	// Use this for initialization
	void Start () {
		Target = ("Target1");
	}
	
	// Update is called once per frame
	void Update () {
		



		if (transform.position == Target1.position) {
			Target = ("Target2");

		}

		if (transform.position == Target2.position) {
			Target = ("Target1");

		}

		if (Target == ("Target1")) {
			transform.position = Vector3.MoveTowards (transform.position, Target1.position, WalkSpeed* Time.deltaTime);
			transform.LookAt(Target1.position);

		}

		if (Target == ("Target2")) {
			transform.position = Vector3.MoveTowards(transform.position, Target2.position, WalkSpeed*Time.deltaTime);
			transform.LookAt(Target2.position);
		}
	}
}
