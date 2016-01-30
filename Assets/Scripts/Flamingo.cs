using UnityEngine;
using System.Collections;

public class Flamingo : MonoBehaviour {


	public int columnTotal = 10;
	public float columnWidth = 1.0f;
	public float columnSpeed = 0.1f;
	public float laneWidth = 1.0f;
	public float laneSpeed = 0.1f;

	bool laneNow = false; // true is backwards
	int columnNow = 0;
	int counter = 0;


	// Use this for initialization
	public virtual void Start()
	{
		columnNow = columnTotal / 2;
		//Debug.Log("Flamingo.cs");
	}
	

	public void movementProcess()
	{
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
		float afwijking = posNew.x - (columnWidth * (float)columnNow);
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
		if (columnNow < columnTotal)
		{
			columnNow += 1;
		}
		else
		{
			// flamingo dead
		}
	}



	public void GoBackward()
	{
		if (columnNow > 0)
		{
			columnNow -= 1;
		}
		else
		{
			// flamingo dead
		}
	}
}
