using UnityEngine;
using System.Collections;
//using System.IO.Ports;

public class Player : Flamingo
{
	public GameObject gameManager;
	Beats beatsScript;

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

		gameManager = GameObject.Find("GameManager"); 
		beatsScript = gameManager.GetComponent<Beats>();

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

		bool keyUp =	Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ||
						Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
		bool keyLeft =	Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
		bool keyRight =	Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
		bool keyJump =	Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space);
		bool keyKick =	Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftControl);

		if (keyUp)
		{
			DoSwitchLane();
		}

		if (keyLeft)
		{
			GoBackward();
			//beatsScript.BeatHit(false);
		}
		if (keyRight)
		{
			GoForward();
			//beatsScript.BeatHit(true);
		}

		if (keyJump)
		{
			doJump();
		}

		if (keyKick)
		{

		}

		if (beatsScript.BeatGetCount() >= 4)
		{
			float score = beatsScript.BeatGetAverageAccuracy();
			Debug.Log(score);
			if (score < 0.3f)
			{
				GoBackward();
				Debug.Log("BACKWARDS");
			}
			else if (score > 0.6f)
			{
				GoForward();
				Debug.Log("FORWARDS");
			}
			else
				Debug.Log("ERROR??");
		}

		movementProcess();
	}
}
