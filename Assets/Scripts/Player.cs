using UnityEngine;
using System.Collections;
//using System.IO.Ports;

public class Player : Flamingo
{

	public int comPortNumber = 3;
	public int baudRate = 38400;
	/*
	string serialInput = "";
	SerialPort sp; // */

	// Use this for initialization
	public override void Start()
	{
		base.Start();
		SetMovementSpeed(1.0f);
		/*
		sp = new SerialPort("COM" + comPortNumber, baudRate);
		sp.Open();
		sp.ReadTimeout = 1; // */

	}

	// Update is called once per frame
	void Update()
	{
		if (!isAlive) return;
		/*
		serialInput = sp.ReadLine();
		int keys;
		int.TryParse(serialInput, out keys);

		Debug.Log(keys); // */

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
