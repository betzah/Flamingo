using UnityEngine;
using System.Collections;

public class Player : Flamingo {

	// Use this for initialization
	public override void Start ()
	{
		base.Start();
		Debug.Log("Player.cs");
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ||
			Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			DoSwitchLane();
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GoBackward();
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			GoForward();
		}

		movementProcess();
	}
}
