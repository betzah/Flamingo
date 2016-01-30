using UnityEngine;
using System.Collections;
//using System.IO.Ports.SerialPort class


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
		DoDie();
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
