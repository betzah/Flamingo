using UnityEngine;
using System.Collections;

public class Flamingo : MonoBehaviour {


	public int columnTotal = 10;
	public float columnWidth = 1.0f;
	public float columnSpeed = 0.1f;
	public float laneWidth = 1.0f;
	public float laneSpeed = 0.1f;

	bool laneNow = false; // true is backwards
	int colomnNow = 0;
	int counter = 0;


	float timer1 = 0.0f;
	float timer2 = 0.0f;
	bool a = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//Test Code
		timer1 += Time.deltaTime;
		if (timer1 >= 1.0f)
		{
			timer1 -= 1.0f;
			DoSwitchLane();
		}

		timer2 += Time.deltaTime;
		if (timer2 >= 2.0f)
		{
			timer2 -= 2.0f;
			if (a)
				GoForward();
			else
				goBackward();

			a = !a;
		}


		// Read current position
		Vector3 posNew = this.transform.position;

		// Lanes
		if (laneNow)
		{
			posNew.z = Mathf.Clamp(posNew.z + laneSpeed, 0.0f, laneWidth);
		}
		else
		{
			posNew.z = Mathf.Clamp(posNew.z - laneSpeed, 0.0f, laneWidth);
		}

		// Colomns
		float afwijking = posNew.x - (columnWidth * (float)colomnNow);
		posNew.x -= Mathf.Clamp(afwijking, -columnSpeed, columnSpeed);

		// Save new position
		this.transform.position = posNew;
	}



	public void DoSwitchLane()
	{
		laneNow = !laneNow;
	}


	public void GoForward()
	{
		if (colomnNow < columnTotal)
		{
			colomnNow += 1;
		}
		else
		{
			// flamingo dead
		}
	}



	public void GoBackward()
	{
		if (colomnNow > 0)
		{
			colomnNow -= 1;
		}
		else
		{
			// flamingo dead
		}
	}
}
