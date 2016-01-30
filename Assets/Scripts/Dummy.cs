using UnityEngine;
using System.Collections;

public class Dummy : Flamingo {

	public float switchChance = 0.2f;
	public float moveChance = 0.05f;
	public float moveForwardChance = 0.2f;

	float switchTimer = 0.0f;
	float moveTimer = 0.0f;


	// Use this for initialization
	public override void Start()
	{
		base.Start();
		SetMovementSpeed(0.1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isAlive) return;

		switchTimer += Time.deltaTime;
		if (switchTimer > 0.5f)
		{
			switchTimer = 0.0f;
			if (Random.value < switchChance)
			{
				//DoSwitchLane();
			}
		}


		moveTimer += Time.deltaTime;
		if (moveTimer > 0.5f)
		{
			moveTimer = 0.0f;
			if (Random.value < moveChance)
			{
				if (Random.value < moveForwardChance)
				{
					//GoForward();
				}
				else
				{
					GoBackward();
				}
			}
		}

		movementProcess();
	}
}
